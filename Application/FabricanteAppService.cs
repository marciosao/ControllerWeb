using Domain.Entities;
using Domain.Interfaces.Services;
using Application.Interfaces;
using System.Collections.Generic;
using System.Collections;
using System;

namespace Application
{
    public class FabricanteAppService : AppServiceBase<Fabricante>,IFabricanteAppService
    {
        private readonly IFabricanteService _fabricanteService;

        public FabricanteAppService(IFabricanteService fabricanteService) : base(fabricanteService)
        {
            _fabricanteService = fabricanteService;
        }

        public IEnumerable ObtemFabricantePorNome(string pFabricante)
        {
            var lFabricante = _fabricanteService.ObtemFabricantePorNome(pFabricante);

            return lFabricante;
        }

        public IEnumerable ObtemFabricantePorFiltro(Fabricante pFabricante)
        {
            var lFabricante = _fabricanteService.ObtemFabricantePorFiltro(pFabricante);

            return lFabricante;
        }
    }
}
