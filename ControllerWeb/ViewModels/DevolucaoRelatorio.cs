using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControllerWeb.ViewModels
{
    public class DevolucaoRelatorio
    {
        public int Id { get; set; }
        public int IdVenda { get; set; }
        public string Vendedor { get; set; }
        public DateTime DataDevolucao { get; set; }
        public string Produto { get; set; }
        public string Fabricante { get; set; }
        public string Modelo { get; set; }
        public string QuantidadeDevolvida { get; set; }
        public string Venda { get; set; }
    }

    public class FiltrosDevolucaoRelatorio
    {
        public string ftDataDevolucao { get; set; }
        public string ftCodigoVenda { get; set; }
        public string ftVendedor { get; set; }
        public string ftProduto { get; set; }
    }
}