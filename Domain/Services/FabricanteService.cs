using System;
using System.Collections;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class FabricanteService : ServiceBase<Fabricante>,IFabricanteService
    {
        private readonly IFabricanteRepository _fabricanteRepository;

        public FabricanteService(IFabricanteRepository fabricanteRepository) : base(fabricanteRepository)
        {
            _fabricanteRepository = fabricanteRepository;
        }

        public IEnumerable ObtemFabricantePorFiltro(Fabricante pFabricante)
        {
            return _fabricanteRepository.ObtemFabricantePorFiltro(pFabricante);
        }

        public IEnumerable ObtemFabricantePorNome(string pFabricante)
        {
            return _fabricanteRepository.ObtemFabricantePorNome(pFabricante);
        }
    }
}
