using Domain.Entities;
using Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System;
using Infra.Data.Models;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Infra.Data.Repositories
{
    public class VendaProdutoRepository : RepositoryBase<VendasProduto>,IVendaProdutoRepository
    {

        public IEnumerable<VendasProduto> ObtemPorFiltro(VendasProduto pVendasProduto)
        {
            int? lIdVenda = null;
            if (pVendasProduto.IdVendas > 0)
            {
                lIdVenda = pVendasProduto.IdVendas;
            }

            int? lIdProduto = null;
            if (pVendasProduto.IdProduto > 0)
            {
                lIdProduto = pVendasProduto.IdProduto;
            }


            var lListaVendasProduto = (from vend in Db.VENDAS_PRODUTO
                                       where (vend.IdVendas == lIdVenda || lIdVenda == null) &&
                                             (vend.IdProduto == lIdProduto || lIdProduto == null)
                                       select vend).ToList();

            return lListaVendasProduto;
        }
    }
}
