using Domain.Entities;
using Domain.Interfaces.Services;
using Application.Interfaces;

namespace Application
{
    public class PerfilAppService : AppServiceBase<Perfil>,IPerfilAppService
    {
        private readonly IPerfilService _perfilService;

        public PerfilAppService(IPerfilService perfilService) : base(perfilService)
        {
            _perfilService = perfilService;

        }
    }
}
