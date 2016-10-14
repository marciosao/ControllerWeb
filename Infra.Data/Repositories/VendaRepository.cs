using System;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System.Collections.Generic;
using Infra.Data.Models;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;


namespace Infra.Data.Repositories
{
    public class VendaRepository : RepositoryBase<Venda>, IVendaRepository
    {
        public void GravarVenda(Venda lVenda)
        {
            AddWithReturn(lVenda);
        }

        public IEnumerable<Venda> ObterPorFiltro(Venda pVenda)
        {
            string lCodigo = null;
            if (!string.IsNullOrEmpty(pVenda.Codigo))
            {
                lCodigo = pVenda.Codigo;
            }

            int? lIdVendedor = null;
            if (pVenda.IdVendedor > 0)
            {
                lIdVendedor = pVenda.IdVendedor;
            }

            DateTime? lDataVenda = null;
            if (pVenda.DataVenda != null && !pVenda.DataVenda.Date.ToShortDateString().Equals("01/01/0001"))
            {
                lDataVenda = pVenda.DataVenda;
            }


            ////////var lListaProdutos = (from vend in Db.VENDA
            ////////                      join vendProd in Db.VENDAS_PRODUTO on vend.IdVenda equals vendProd.IdVendas
            ////////                      where (vend.Codigo.Contains(lCodigo) || lCodigo == null) &&
            ////////                      (vend.IdVendedor == lIdVendedor || lIdVendedor == null) &&
            ////////                             (vend.DataVenda == lDataVenda || lDataVenda == null)
            ////////                      select vend).Distinct().ToList();

            var lListaProdutos = Db.VENDA.Where(v => (v.Codigo.Contains(lCodigo) || lCodigo == null) && 
                                                      (v.IdVendedor == lIdVendedor || lIdVendedor == null) &&
                                                      (v.DataVenda == lDataVenda || lDataVenda == null)).ToList();

            return lListaProdutos;
        }
    }
}
