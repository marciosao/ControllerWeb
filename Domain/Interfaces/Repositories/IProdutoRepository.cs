using Domain.Entities;
using System.Collections;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        Produto Salvar(Produto pProduto);

        IEnumerable<Produto> ObterPorFiltro(Produto pProduto);

        IEnumerable<Produto> ObterProdutosEstoqueZerado();

        IEnumerable<Produto> ObtemPorFiltro(string pCodigo, string pNome, int pIdFabricante, int pIdModelo, int pFiltroQtdEstoque);

    }
}
