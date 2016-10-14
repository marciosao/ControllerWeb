using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControllerWeb.ViewModels
{
    public class ProdutoRelatorio
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string CodFabricante { get; set; }
        public string CodModelo { get; set; }
        public string QuantidadeEstoque { get; set; }
        public string QuantidadeMinimaEstoque { get; set; }
        public string AvisaQuantidadeMinima { get; set; }
        public string Fabricante { get; set; }
        public string Modelo { get; set; }
    }

    public class FiltrosProdutoRelatorio
    {
        public string ftFabricante { get; set; }
        public string ftModelo { get; set; }
        public string ftSituacaoEstoque { get; set; }
        public string ftProduto { get; set; }
    }
}