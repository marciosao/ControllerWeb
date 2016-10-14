using System.Collections.Generic;

namespace ControllerWeb.ViewModels
{
    public class ProdutoViewModel
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
        public decimal QuantidadeVendida { get; set; }
    }
}
