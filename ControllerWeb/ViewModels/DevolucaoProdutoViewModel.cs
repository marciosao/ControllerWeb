namespace ControllerWeb.ViewModels
{
    public class DevolucaoProdutoViewModel
    {
        public int IdDevolucaoProduto { get; set; }
        public int IdProduto { get; set; }
        public int IdDevolucao { get; set; }
        public decimal QtdDevolvida { get; set; }
        public virtual DevolucaoViewModel Devolucao { get; set; }
        public virtual ProdutoViewModel Produto { get; set; }
    }
}
