using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiQuote.Api.Controllers.V1.Base;
using MultiQuoteApi.Application.Interfaces;
using MultiQuoteApi.Core.Infrastructure.Exceptions;
using MultiQuoteApi.Core.Models;
using MultiQuoteApi.Infra.Identity.Context;
using MultiQuoteApi.Infra.Identity.Interfaces;
using MultiQuoteApi.Infra.Identity.Models;
using System.ComponentModel.DataAnnotations;

namespace MultiQuote.Api.Controllers.V1
{

    /// <summary>
    /// 
    /// </summary>   
    /// <param name="dbContext"></param>
    /// <param name="rolemanager"></param>
    /// <param name="menuScreenAppService"></param>
    public class MenusController(IUser user, IdentityDbContext dbContext, RoleManager<ApplicationRole> rolemanager, IMenuScreenAppService menuScreenAppService)
        : BaseController(user)
    {
        private readonly IdentityDbContext _dbContext = dbContext;
        private readonly RoleManager<ApplicationRole> _roleManager = rolemanager;
        private readonly IMenuScreenAppService _menuScreenAppService = menuScreenAppService;


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("screen/{code}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListAsync(int code)
        {
            var response = await _menuScreenAppService.GetAsync(code);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        /// <exception cref="BusinessException"></exception>
        [HttpGet]
        [Route("role")]
        [ProducesResponseType(typeof(BaseDataResponseModel<ListMenuModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAsync([FromQuery, Required] string roleName)
        {
            // Recupera a função baseada no nome
            var role = await _roleManager.Roles
                .Where(x => x.Name == roleName)
                .FirstOrDefaultAsync()
                ?? throw new BusinessException($"Role '{roleName}' não foi localizada.");

            // Recupera todos os itens de menu associados à role
            var query = (from a in _dbContext.RoleMenus
                         join b in _dbContext.MenuItems on a.MenuId equals b.Id
                         where a.RoleId == role.Id
                         select b)
                        .OrderBy(c => c.Id)
                        .ToList();

            // Estrutura da resposta
            var response = new ListMenuModel()
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description,
            };

            // Inicia o processo de construção do menu a partir dos itens de nível raiz (ParentId == null)
            var rootItems = query.Where(x => x.ParentId == null).OrderBy(c => c.Id).ToList();

            foreach (var item in rootItems)
            {
                // Chama a função recursiva para montar a árvore do menu
                var menu = BuildMenuTree(item, query);
                response.Menus?.Add(menu);
            }

            return ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="BusinessException"></exception>
        [HttpPost()]
        [Route("role")]
        [ProducesResponseType(typeof(BaseDataResponseModel<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> SaveAsync(SaveMenuModel request)
        {
            var role = await _roleManager.Roles.Where(x => x.Name == request.RoleName).Include(x => x.RoleMenus).FirstOrDefaultAsync()
               ?? throw new BusinessException($"Role '{request.RoleName}' não foi lozalizada.");

            var roleMenus = role.RoleMenus.Where(x => x.RoleId.Equals(role.Id)).ToList();
            foreach (var roleMenu in roleMenus)
            {
                _dbContext.RoleMenus.Remove(roleMenu);
            }

            foreach (var menuId in request.MenuIds)
            {
                await _dbContext.RoleMenus.AddAsync(new ApplicationRoleMenu()
                {
                    RoleId = role.Id,
                    MenuId = menuId,
                });

                await _dbContext.SaveChangesAsync();
            }

            return base.ReturnSuccess(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Route("all")]
        [ProducesResponseType(typeof(BaseDataResponseModel<MenuListModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetMenusAsync()
        {
            var response = new List<MenuListModel>();
            var query = (from b in _dbContext.MenuItems select b).ToList();
            var menuItem = query.Where(x => x.ParentId == null).ToList();
            if (menuItem == null)
            {
                return base.ReturnNotFound();
            }

            foreach (var item in menuItem)
            {
                var menu = new MenuListModel()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Url = item.Url,
                    Icon = item.Icon,
                };

                foreach (var itemMenu in query.Where(x => x.ParentId == item.Id))
                {
                    menu.MenuItem?.Add(new MenuListModel()
                    {
                        Id = itemMenu.Id,
                        Title = itemMenu.Title,
                        Icon = itemMenu.Icon,
                        Url = itemMenu.Url,
                        MenuItem = query.Where(item => item.ParentId == itemMenu.Id).Select(item => new MenuListModel()
                        {
                            Id = item.Id,
                            Title = item.Title,
                            Icon = item.Icon,
                            Url = item.Url,

                        }).ToList()
                    });
                }
                ;
                response.Add(menu);
            }

            return ReturnSuccess(response);
        }


        // Função recursiva para construir a árvore de menu
        private MenuModel BuildMenuTree(ApplicationMenuItem parentItem, List<ApplicationMenuItem> allMenuItems)
        {
            var menu = new MenuModel()
            {
                Id = parentItem.Id,
                Title = parentItem.Title,
                Url = parentItem.Url,
                Icon = parentItem.Icon,
                Code = parentItem.Code,
                MenuItem = [] // Inicializa a lista de itens filhos
            };

            // Encontra todos os filhos do item atual (com base no ParentId)
            var childItems = allMenuItems.Where(x => x.ParentId == parentItem.Id).OrderBy(c => c.Id).ToList();

            foreach (var child in childItems)
            {
                // Chama recursivamente para cada filho e constrói sua árvore de submenu
                var childMenu = BuildMenuTree(child, allMenuItems);
                menu.MenuItem?.Add(childMenu);
            }

            return menu;
        }
    }
}
