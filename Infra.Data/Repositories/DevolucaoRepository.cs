using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System.Linq;


namespace Infra.Data.Repositories
{
    public class DevolucaoRepository : RepositoryBase<Devolucao>, IDevolucaoRepository
    {
        public void GravarDevolucao(Devolucao lDevolucao)
        {
            AddWithReturn(lDevolucao);
        }

        public IEnumerable<Devolucao> ObtemDevolucoesPorFiltro(Devolucao pDevolucao)
        {
            DateTime? lDataDevolucao = null;
            if (pDevolucao.DataDevolucao != null && !pDevolucao.DataDevolucao.ToString().Equals("01/01/0001 00:00:00"))
            {
                lDataDevolucao = pDevolucao.DataDevolucao;
            }

            int? lVendedor = null;
            if (pDevolucao.IdVendedor > 0)
            {
                lVendedor = pDevolucao.IdVendedor;
            }

            string NomeProduto = null;
            if (pDevolucao.DevolucaoProduto.Any())
            {
                if (pDevolucao.DevolucaoProduto.FirstOrDefault().Produto != null)
                {
                    NomeProduto = pDevolucao.DevolucaoProduto.FirstOrDefault().Produto.Nome;
                }
            }

            ////////var lListaDevolucoes = (from dev in Db.DEVOLUCAO
            ////////                        join DevProd in Db.DEVOLUCAO_PRODUTO on dev.IdDevolucao equals DevProd.IdDevolucao
            ////////                        join Prod in Db.PRODUTO on DevProd.IdProduto equals Prod.IdProduto
            ////////                        where (dev.DataDevolucao == pDevolucao.DataDevolucao || lDataDevolucao == null) &&
            ////////                        (dev.IdVendedor == pDevolucao.IdVendedor || lVendedor == null) &&
            ////////                        (Prod.Nome.Contains(NomeProduto) || NomeProduto == null)
            ////////                        select dev).Distinct().ToList();

            var lListaDevolucoes = Db.DEVOLUCAO.Where(x => (x.DataDevolucao == pDevolucao.DataDevolucao || lDataDevolucao == null) &&
                                                    (x.IdVendedor == pDevolucao.IdVendedor || lVendedor == null)).Distinct().ToList();


            return lListaDevolucoes;
        }
    }
}
