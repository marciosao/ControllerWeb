using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class DevolucaoProduto
    {
        [Key]
        public int IdDevolucaoProduto { get; set; }

        public int? IdProduto { get; set; }
        public int? IdDevolucao { get; set; }
        public decimal QtdDevolvida { get; set; }
        public virtual Devolucao Devolucao { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
