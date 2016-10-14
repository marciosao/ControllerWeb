using Domain.Entities;
using Domain.Interfaces.Services;
using Application.Interfaces;
using System;
using PagedList;
using System.Collections.Generic;

namespace Application
{
    public class VendaAppService : AppServiceBase<Venda>, IVendaAppService
    {
        private readonly IVendaService _vendaService;

        public VendaAppService(IVendaService vendaService) : base(vendaService)
        {
            _vendaService = vendaService;

        }

        public void GravarVenda(Venda lVenda)
        {
            _vendaService.GravarVenda(lVenda);
         }

        public IEnumerable<Venda> ObtemPorFiltro(Venda lVenda)
        {
            return _vendaService.ObtemPorFiltro(lVenda);
        }

        public IEnumerable<Venda> ObtemVendasOrdenado()
        {
            return _vendaService.ObtemVendasOrdenado();
        }
    }
}
