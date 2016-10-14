using System;
using System.Collections.Generic;

namespace ControllerWeb.ViewModels
{
    public class VendaViewModel
    {
        public int IdVenda { get; set; }
        public string Codigo { get; set; }
        public DateTime DataVenda { get; set; }
        public int IdVendedor { get; set; }
        public decimal QtdVendida { get; set; }
        public DateTime DataModificacao { get; set; }
        public string IdUsuario { get; set; }
        public int IdProduto { get; set; }
        public virtual ICollection<ProdutoViewModel> ProdutoSelecionado { get; set; }
        public virtual VendedorViewModel Vendedor { get; set; }
    }
}
