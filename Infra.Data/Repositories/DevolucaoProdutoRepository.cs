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
    public class DevolucaoProdutoRepository : RepositoryBase<DevolucaoProduto>, IDevolucaoProdutoRepository
    {
        public IEnumerable<DevolucaoProduto> ObtemPorFiltro(Devolucao pDevolucao)
        {
            int? lIdDevolucao = null;
            if (pDevolucao.IdDevolucao > 0)
            {
                lIdDevolucao = pDevolucao.IdDevolucao;
            }

            int? lIdVendedor = null;
            if (pDevolucao.IdVendedor > 0)
            {
                lIdVendedor = pDevolucao.IdVendedor;
            }

            DateTime? lDataDevolucao = null;
            if (pDevolucao.DevolucaoProduto !=null && !pDevolucao.DevolucaoProduto.Equals("{01/01/0001 00:00:000}"))
            {
                lDataDevolucao = pDevolucao.DataDevolucao.Date;
            }


            var lListaDevolucaoProduto = (from dev in Db.DEVOLUCAO_PRODUTO
                                       where (dev.Devolucao.IdVendedor == lIdVendedor || lIdVendedor == null) &&
                                             (dev.Devolucao.DataDevolucao == lDataDevolucao || lDataDevolucao == null) &&
                                             (dev.Devolucao.IdDevolucao == lIdDevolucao || lIdDevolucao == null)
                                          select dev).ToList();

            return lListaDevolucaoProduto;
        }
    }
}
