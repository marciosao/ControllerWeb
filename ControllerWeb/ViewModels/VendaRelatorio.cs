using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControllerWeb.ViewModels
{
    public class VendaRelatorio
    {
        public int Id { get; set; }
        public DateTime DataVenda { get; set; }
        public string DataModificacao { get; set; }
        public string UsuarioResponsavel { get; set; }
        public string CodigoVenda { get; set; }
        public string CodProduto { get; set; }
        public string Fabricante { get; set; }
        public string CodFabricante { get; set; }
        public string Modelo { get; set; }
        public string CodModelo { get; set; }
        public string Vendedor { get; set; }
        public string CodVendedor { get; set; }
        public string MatriculaVendedor { get; set; }
        public string Produto { get; set; }
        public string QtdVendida { get; set; }
        public string IdProduto { get; set; }

    }

    public class FiltrosVendaRelatorio
    {
        public string ftData { get; set; }
        public string ftVendedor { get; set; }
        public string ftProduto { get; set; }
    }
}