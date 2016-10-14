using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class MenuService : ServiceBase<Menu>,IMenuService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository) : base(menuRepository)
        {
            _menuRepository = menuRepository;
        }
    }
}
