using Domain.Entities;
using Domain.Interfaces.Services;
using Application.Interfaces;

namespace Application
{
    public class MenuAppService : AppServiceBase<Menu>,IMenuAppService
    {
        private readonly IMenuService _menuService;

        public MenuAppService(IMenuService menuService) : base(menuService)
        {
            _menuService = menuService;
        }
    }
}
