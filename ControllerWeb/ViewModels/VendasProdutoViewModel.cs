using System;

namespace ControllerWeb.ViewModels
{
    public class VendasProdutoViewModel
    {
        public int IdVendasProduto { get; set; }
        public int IdVendas { get; set; }
        public int IdProduto { get; set; }
        public decimal QtdVendida { get; set; }
        public DateTime DataModificacao { get; set; }
        public string IdUsuario { get; set; }
        public virtual ProdutoViewModel Produto { get; set; }
        public virtual VendaViewModel Venda { get; set; }
    }
}
