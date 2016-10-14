using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Venda
    {
        public Venda()
        {
            this.Devolucao = new List<Devolucao>();
            this.VendasProduto = new List<VendasProduto>();
        }

        [Key]
        public int IdVenda { get; set; }

        public string Codigo { get; set; }
        public DateTime DataVenda { get; set; }
        public int? IdVendedor { get; set; }
        public decimal? QtdVendida { get; set; }
        public DateTime DataModificacao { get; set; }
        public string IdUsuario { get; set; }
        public int? IdProduto { get; set; }
        public virtual ICollection<Devolucao> Devolucao { get; set; }
        public virtual ICollection<VendasProduto> VendasProduto { get; set; }
        public virtual Vendedor Vendedor { get; set; }
    }
}
