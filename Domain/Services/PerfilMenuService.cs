using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class PerfilMenuService : ServiceBase<PerfilMenu>,IPerfilMenuService
    {
        private readonly IPerfilMenuRepository _perfilMenuRepository;

        public PerfilMenuService(IPerfilMenuRepository perfilMenuRepository) : base(perfilMenuRepository)
        {
            _perfilMenuRepository = perfilMenuRepository;

        }
    }
}
