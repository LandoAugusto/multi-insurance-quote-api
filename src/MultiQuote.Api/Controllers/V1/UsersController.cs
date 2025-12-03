using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiQuote.Api.Controllers.V1.Base;
using MultiQuoteApi.Application.Interfaces;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Core.Infrastructure.Exceptions;
using MultiQuoteApi.Core.Models;
using MultiQuoteApi.Infra.Identity.Context;
using MultiQuoteApi.Infra.Identity.Interfaces;
using MultiQuoteApi.Infra.Identity.Models;

namespace MultiQuote.Api.Controllers.V1
{
    /// <summary>
    /// 
    /// </summary>
    public class UsersController(IUser user,
            IUserAppService userAppService,            
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> rolemanager,
            IdentityDbContext dbContext) : BaseController(user)
    {
        private readonly IdentityDbContext _dbContext = dbContext;
        private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly RoleManager<ApplicationRole> _roleManager = rolemanager;
        private readonly IUserAppService _userAppService = userAppService;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetAsync([FromQuery] string? id, [FromQuery] string? login, [FromQuery] string? email)
        {
            try
            {
                ApplicationUser? existentUser = null;
                if (!string.IsNullOrWhiteSpace(id))
                {
                    existentUser = await _userManager.FindByIdAsync(id);
                }
                if (existentUser == null && !string.IsNullOrWhiteSpace(login))
                {
                    existentUser = await _userManager.FindByNameAsync(login);
                }
                if (existentUser == null && !string.IsNullOrWhiteSpace(email))
                {
                    existentUser = await _userManager.FindByEmailAsync(email);
                }
                if (existentUser == null) ReturnNotFound();

                var users = await userManager.Users.Select(u => new
                {
                    existentUser.Id,
                    Name = existentUser.UserName,
                    existentUser.Email,
                    Roles = new List<RoleResponse>(),
                }).ToListAsync();


                var roles = await _roleManager.Roles.Select(r => new { r.Id, r.Name, r.Description }).ToListAsync();

                foreach (var role in roles)
                {
                    var usersInRole = await userManager.GetUsersInRoleAsync(role.Name);
                    var toUpdate = users.Where(u => usersInRole.Any(ur => ur.Id == existentUser.Id));

                    foreach (var user in toUpdate)
                    {
                        user.Roles.Add(new RoleResponse(role.Id, role.Name, role.Description));
                    }
                }

                return base.ReturnSuccess(users);

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<ActionResult> GetUserAsync(string userId)
        {
            try
            {
                var existentUser = await _userManager.FindByIdAsync(userId);

                var users = await _userManager.Users.Select(u => new
                {
                    existentUser.Id,
                    Name = existentUser.UserName,
                    existentUser.Email,
                    Roles = new List<RoleResponse>(),
                }).ToListAsync();


                var roles = await _roleManager.Roles.Select(r => new { r.Id, r.Name, r.Description }).ToListAsync();

                foreach (var role in roles)
                {
                    var usersInRole = await _userManager.GetUsersInRoleAsync(role.Name);
                    var toUpdate = users.Where(u => usersInRole.Any(ur => ur.Id == existentUser?.Id));

                    foreach (var user in toUpdate)
                    {
                        user.Roles.Add(new RoleResponse(role.Id, role.Name, role.Description));
                    }
                }

                return base.ReturnSuccess(users.FirstOrDefault());
            }
            catch (Exception)
            {
                throw;
            }
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="BusinessException"></exception>
        [HttpPut("user")]
        public async Task<ActionResult> UpdateAsync(UpdateUserRequest model)
        {
            try
            {
                var existentUser = await userManager.FindByIdAsync(model.Id)
                    ?? throw new BusinessException($"Usuário com identificador '{model.Id}' não localizado.");

                var users = await userManager.Users.Select(u => new
                {
                    existentUser.Id,
                    Name = existentUser.UserName,
                    existentUser.Email,
                    Roles = new List<RoleResponse>()
                }).ToListAsync();

                var roles = await _roleManager.Roles.Select(r => new { r.Id, r.Name, r.Description }).ToListAsync();
                foreach (var role in roles)
                {
                    var usersInRole = await userManager.GetUsersInRoleAsync(role.Name);
                    var toUpdate = users.Where(u => usersInRole.Any(ur => ur.Id == existentUser.Id)).ToList();

                    foreach (var userRole in toUpdate)
                    {
                        userRole.Roles.Add(new RoleResponse(role.Id, role.Name, role.Description));
                    }
                }

                var roleNames = await _roleManager.FindByIdAsync(model.RoleId.ToString())
                    ?? throw new BusinessException($"Role '{model.RoleId}' não foi lozalizada.");

                existentUser.Email = model.Email;

                var x = users.FirstOrDefault();

                var result = await userManager.UpdateAsync(existentUser);
                if (result.Succeeded)
                {
                    var oldRoleId = existentUser.UserRoles.Select(x => x.RoleId).FirstOrDefault();
                    var oldRoleName = await _dbContext.Roles.SingleOrDefaultAsync(r => r.Id == oldRoleId);
                    await userManager.RemoveFromRoleAsync(existentUser, x.Roles.FirstOrDefault().Name);
                    await userManager.AddToRoleAsync(existentUser, roleNames.Name);
                }

                return base.ReturnSuccess(true);

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="BusinessException"></exception>
        [HttpPut("password")]
        public async Task<ActionResult> UpdatePasswordAsync(UpdatePasswordUserRequest model)
        {
            try
            {
                var existentUser = await userManager.FindByIdAsync(model.Id.ToString())
                    ?? throw new BusinessException($"Usuário com identificador '{model.Id}' não localizado.");

                var result = await userManager.ChangePasswordAsync(existentUser, model.OldPassword, model.NewPassword);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        throw new Exception(error.Description);
                    }
                }

                return base.ReturnSuccess(true);

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="BusinessException"></exception>

        [HttpPut("status")]
        public async Task<ActionResult> UpdateStatusAsync(UpdateStatusUserRequest model)
        {

            try
            {
                var existentUser = await userManager.FindByIdAsync(model.Id) ?? throw new BusinessException($"Usuário com identificador '{model.Id}' não localizado.");

                var result = await userManager.SetLockoutEnabledAsync(existentUser, true);
                if (result.Succeeded)
                {
                    result = await userManager.SetLockoutEndDateAsync(existentUser, DateTime.MaxValue.Date);
                }
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        throw new Exception(error.Description);
                    }
                }

                return base.ReturnSuccess(true);

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>

        [HttpGet("get-role-by-id/{roleId}")]
        public async Task<ActionResult> ListRoles(int roleId)
        {
            var role = await _roleManager.Roles
                        .Where(item => item.Id == roleId)
                        .Include(item => item.RoleMenus)
                        .FirstOrDefaultAsync();

            var MenuIds = new List<int>();

            foreach (var roleMenu in role.RoleMenus)
                MenuIds.Add(roleMenu.MenuId);

            return base.ReturnSuccess(new RoleResponse(role.Id, role.Name, role.Description, MenuIds));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("roles")]
        public async Task<ActionResult> GetRolesAsync([FromQuery] int? roleId, [FromQuery] string? name)
        {
            var role = await _roleManager.Roles
                         .Where(item => (roleId == null || item.Id == roleId)
                         && (string.IsNullOrEmpty(name) || item.Name == name)).ToListAsync();

            return base.ReturnSuccess(role.Select(item =>
            {
                return new RoleResponse(item.Id, item.Name, item.Description);
            }).ToList());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="BusinessException"></exception>

        [HttpPost("role")]
        public async Task<ActionResult> CreateRoles(SaveRoleRequest request)
        {
            IdentityResult roleResult;

            if (request.Id is not null)
            {
                var role = await _roleManager.Roles.Where(item => item.Id == request.Id).FirstOrDefaultAsync() ??
                    throw new BusinessException($"Perfil com identificador '{request.Id}' não localizado.");

                role.Name = request.Name;
                role.Description = request.Description;

                roleResult = await _roleManager.UpdateAsync(role);
            }
            else
            {
                var isExists = await _roleManager.RoleExistsAsync(request.Name);
                if (isExists)
                    throw new BusinessException($"Já existe role '{request.Name}' cadastrada.");

                roleResult = await _roleManager.CreateAsync(new ApplicationRole(request.Name, request.Description));
            }

            return base.ReturnSuccess(request.Name);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="BusinessException"></exception>
        [HttpPost("save-user")]
        public async Task<ActionResult> SaveAsync(SaveUserRequest model)
        {
            try
            {
                var existentUser = await userManager.FindByNameAsync(model.Login);
                if (existentUser != null)
                {
                    throw new BusinessException($"Já existe outro usuário cadastrado com o login '{model.Login}'.");
                }

                var roleNames = await _roleManager.FindByIdAsync(model.RoleId.ToString())
                    ?? throw new BusinessException($"Role '{model.RoleId}' não foi lozalizada.");

                var user = new ApplicationUser
                {
                    UserName = model.Login,
                    Email = model.Email,
                    EmailConfirmed = true,
                };

                var createdUser = await userManager.CreateAsync(user, model.Password);
                if (createdUser.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    var roleResult = await userManager.AddToRoleAsync(user, roleNames.Name);
                }

                await _userAppService.InsertAsync(user.Id, new UserModel
                {
                    UserId = user.Id,
                    ProfileId = model.ProfileId.Equals((int)ProfileEnum.Admin) ? model.ProfileId : (int)ProfileEnum.Broker,
                });

                return base.ReturnSuccess(user.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
