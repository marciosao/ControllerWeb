using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class VendasProduto
    {
        [Key]
        public int IdVendasProduto { get; set; }

        public int? IdVendas { get; set; }
        public int? IdProduto { get; set; }
        public decimal QtdVendida { get; set; }
        public DateTime DataModificacao { get; set; }
        public string IdUsuario { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual Venda Venda { get; set; }
    }
}
