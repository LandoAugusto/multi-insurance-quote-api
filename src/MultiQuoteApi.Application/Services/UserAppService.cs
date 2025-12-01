using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

        public async Task CreateUserAsync(int brokerId, int personId, int profileId, CredencialModel credencial)
        {
            var roleNames = await _roleManager.FindByIdAsync("1");
            var user = new ApplicationUser
            {
                UserName = credencial.Login,
                Email = credencial.Email,
                EmailConfirmed = true,
            };

            var createdUser = await userManager.CreateAsync(user, credencial.Password);
            if (createdUser.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                var roleResult = await userManager.AddToRoleAsync(user, roleNames.Name);

                await InsertAsync(user.Id, new UserModel
                {
                    UserId = user.Id,
                    BrokerId = brokerId,
                    PersonId = personId,
                    ProfileId = profileId
                });
            }
        }

        public async Task<int> InsertAsync(int inclusionUserId, UserModel model)
        {
            var entity = _mapper.Map<Users>(model);
            entity.InclusionDate = DateTime.UtcNow;
            entity.InclusionUserId = inclusionUserId;
            entity.Status = 1;
            var response = await _userRepository.AddAsync(entity);

            return response.Id;
        }
    }
}
