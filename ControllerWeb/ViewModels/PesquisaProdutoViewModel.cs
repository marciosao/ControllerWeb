using Domain.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControllerWeb.ViewModels
{
    public class PesquisaProdutoViewModel
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public int IdFabricante { get; set; }
        public string Fabricante { get; set; }
        public int IdModelo { get; set; }

        public string Modelo { get; set; }

        public string FiltroQtdEstoque { get; set; }

        public Produto Produto { get; set; }

        public IEnumerable<Produto> Produtos { get; set; }

        public IEnumerable<PesquisaProdutos> ListaProdutos { get; set; }

        public PagedList<Produto> ListaProdutosPaginado { get; set; }

    }

    public class PesquisaProdutos
    {
        public int IdProduto { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public int IdFabricante { get; set; }
        public int IdModelo { get; set; }
        public decimal QtdEstoque { get; set; }
        public decimal QtdMinimaEstoque { get; set; }
        public bool AvisaEstoqueMinimo { get; set; }
        public string Fabricante { get; set; }
        public string Modelo { get; set; }
    }
}