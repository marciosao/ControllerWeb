using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System.Linq;

namespace Infra.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public IEnumerable<Produto> ObterPorFiltro(Produto pProduto)
        {
            string lNome = null;
            if (!string.IsNullOrEmpty(pProduto.Nome))
            {
                lNome = pProduto.Nome;
            }

            string lCodigo = null;
            if (!string.IsNullOrEmpty(pProduto.Codigo))
            {
                lCodigo = pProduto.Codigo;
            }

            int? lIdFabricante = null;
            if (pProduto.IdFabricante>0)
            {
                lIdFabricante = pProduto.IdFabricante;
            }

            int? lIdModelo = null;
            if (pProduto.IdModelo > 0)
            {
                lIdModelo = pProduto.IdModelo;
            }

            var lListaProdutos = (from prod in Db.PRODUTO
                                  where (prod.Codigo.Contains(lCodigo) || lCodigo == null) &&
                                  (prod.Nome.Contains(lNome) || lNome == null) &&
                                         (prod.IdFabricante == lIdFabricante || lIdFabricante == null) &&
                                         (prod.IdModelo == lIdModelo || lIdModelo == null)
                                  select prod).ToList();

            return lListaProdutos;
        }

        public IEnumerable<Produto> ObterProdutosEstoqueZerado()
        {
            var lListaProdutos = (from prod in Db.PRODUTO
                                  where prod.QtdEstoque == 0
                                  select prod).OrderBy(x=>x.Nome).ToList();

            return lListaProdutos;
        }

        public Produto Salvar(Produto pProduto)
        {
            Add(pProduto);

            return pProduto;
        }

        public IEnumerable<Produto> ObtemPorFiltro(string pCodigo, string pNome, int pIdFabricante, int pIdModelo, int pFiltroQtdEstoque)
        {
            string lNome = null;
            if (!string.IsNullOrEmpty(pNome))
            {
                lNome = pNome;
            }

            string lCodigo = null;
            if (!string.IsNullOrEmpty(pCodigo))
            {
                lCodigo = pCodigo;
            }

            int? lIdFabricante = null;
            if (pIdFabricante > 0)
            {
                lIdFabricante = pIdFabricante;
            }

            int? lIdModelo = null;
            if (pIdModelo > 0)
            {
                lIdModelo = pIdModelo;
            }

            var lListaProdutos = (from prod in Db.PRODUTO
                                  where (prod.Codigo.Contains(lCodigo) || lCodigo == null) &&
                                  (prod.Nome.Contains(lNome) || lNome == null) &&
                                         (prod.IdFabricante == lIdFabricante || lIdFabricante == null) &&
                                         (prod.IdModelo == lIdModelo || lIdModelo == null)
                                  select prod).AsQueryable();
            
            if (pFiltroQtdEstoque == 1)
            {
                lListaProdutos = lListaProdutos.Where(x => x.QtdEstoque == 0).AsQueryable();
            }
            else if (pFiltroQtdEstoque == 2)
            {
                lListaProdutos = lListaProdutos.Where(x => x.QtdEstoque > 0).AsQueryable();
            }
            else if (pFiltroQtdEstoque == 3)
            {
                lListaProdutos = lListaProdutos.Where(x => x.QtdEstoque < x.QtdMinimaEstoque).AsQueryable();
            }
            return lListaProdutos;
        }
    }
}
