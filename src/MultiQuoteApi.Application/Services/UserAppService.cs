using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MultiQuoteApi.Application.Interfaces;
using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Core.Infrastructure.Exceptions;
using MultiQuoteApi.Core.Models;
using MultiQuoteApi.Infra.Data.Interfaces;
using MultiQuoteApi.Infra.Identity.Models;

namespace MultiQuoteApi.Application.Services
{
    internal class UserAppService(
        IMapper mapper,
        IUserRepository userRepository,
        SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRole> rolemanager)
        : IUserAppService
    {
        private readonly IMapper _mapper = mapper;
        private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager = rolemanager;
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<UserModel?> GetAsync(int userId, RecordStatusEnum recordStatus)
        {
            var entity = await _userRepository.GetAsync(userId, recordStatus);
            if (entity == null) return null;

            return _mapper.Map<UserModel>(entity);
        }
        public async Task ValidateUserAsync(string login)
        {
            var existentUser = await userManager.FindByNameAsync(login);
            if (existentUser != null)
            {
                throw new BusinessException($"Já existe outro usuário cadastrado com o login '{login}'.");
            }
        }

        public async Task CreateUserAsync(UserPersonModel user)
        {
            var applicationUser = new ApplicationUser
            {
                UserName = user.Credencial.Login,
                Email = user.Credencial.Email,
                EmailConfirmed = true,
            };

            var createdUser = await userManager.CreateAsync(applicationUser, user.Credencial.Password);
            if (createdUser.Succeeded)
            {
                var roleNames = await _roleManager.FindByIdAsync(user.RoleId.ToString())
                    ?? throw new BusinessException($"Role '{user.RoleId}' não foi lozalizada.");

                await _signInManager.SignInAsync(applicationUser, false);

                _ = await userManager.AddToRoleAsync(applicationUser, roleNames.Name);

                await _signInManager.SignInAsync(applicationUser, false);
                await InsertAsync(user.InclusionUserId, new UserModel
                {
                    UserId = applicationUser.Id,
                    BrokerId = user.BrokerId,
                    PersonId = user.PersonId,
                    ProfileId = user.ProfileId,
                    IsDefault = user.IsDefault
                });
            }
        }

        public async Task<int> InsertAsync(int inclusionUserId, UserModel model)
        {
            var entity = _mapper.Map<Users>(model);
            entity.InclusionDate = DateTime.UtcNow;
            entity.IsDefault = model.IsDefault;
            entity.InclusionUserId = inclusionUserId;
            entity.Status = (int)RecordStatusEnum.Active;
            var response = await _userRepository.AddAsync(entity);

            return response.Id;
        }
    }
}
