using Domain.Entities;
using Domain.Interfaces.Services;
using Application.Interfaces;

namespace Application
{
    public class PerfilMenuAppService : AppServiceBase<PerfilMenu>,IPerfilMenuAppService
    {
        private readonly IPerfilMenuService _perfilMenuService;

        public PerfilMenuAppService(IPerfilMenuService perfilMenuService) : base(perfilMenuService)
        {
            _perfilMenuService = perfilMenuService;

        }
    }
}
