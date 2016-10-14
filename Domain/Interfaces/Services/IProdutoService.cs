using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Services
{
    public interface IProdutoService : IServiceBase<Produto>
    {
        Produto Salvar(Produto pProduto);

        IEnumerable<Produto> ObterPorFiltro(Produto pProduto);
        IEnumerable<Produto> ObterProdutosEstoqueZerado();

        IEnumerable<Produto> ObtemPorFiltro(string pCodigo, string pNome, int pIdFabricante, int pIdModelo, int pFiltroQtdEstoque);
    }
}
