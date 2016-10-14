using Domain.Entities;
using Domain.Interfaces.Services;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public class DevolucaoAppService : AppServiceBase<Devolucao>,IDevolucaoAppService
    {
        private readonly IDevolucaoService _devolucaoService;

        public DevolucaoAppService(IDevolucaoService devolucaoService) : base(devolucaoService)
        {
            _devolucaoService = devolucaoService;
        }

        public void GravarDevolucao(Devolucao lDevolucao)
        {
            _devolucaoService.GravarDevolucao(lDevolucao);
        }

        public IEnumerable<Devolucao> ObtemDevolucoesOrdenado()
        {
            return _devolucaoService.ObtemDevolucoesOrdenado();
        }

        public IEnumerable<Devolucao> ObtemDevolucoesPorFiltroOrdenado(Devolucao pDevolucao)
        {
            return _devolucaoService.ObtemDevolucoesPorFiltro(pDevolucao).OrderByDescending(x=>x.DataDevolucao);
        }
    }
}
