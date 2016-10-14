using System.Collections.Generic;
using Domain.Entities;
using PagedList;

namespace Application.Interfaces
{
    public interface IProdutoAppService : IAppServiceBase<Produto>
    {
        Produto Salvar(Produto pProduto);

        IEnumerable<Produto> ObtemPorFiltro(Produto pProduto);
        ////////PagedList<Produto> ObtemPorFiltro(Produto pProduto, int pageNumber, int pageSize);

        PagedList<Produto> ObtemPorFiltroQuantidadeDisponivel(int pageNumber, int pageSize);

        PagedList<Produto> ObtemPorFiltroQuantidadeDisponivel(Produto pProduto, int pageNumber, int pageSize);

        IEnumerable<Produto> ObterProdutosEstoqueZerado();

        IEnumerable<Produto> ObtemPorFiltro(string pCodigo, string pNome, int pIdFabricante, int pIdModelo, int pFiltroQtdEstoque);
    }
}
