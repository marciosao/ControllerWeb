using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Devolucao
    {
        public Devolucao()
        {
            this.DevolucaoProduto = new List<DevolucaoProduto>();
        }

        [Key]
        public int IdDevolucao { get; set; }

        public int? IdVendas { get; set; }
        public int? IdVendedor { get; set; }
        public DateTime DataDevolucao { get; set; }
        public int? IdUsuario { get; set; }
        public DateTime DataModificacao { get; set; }

        public virtual ICollection<DevolucaoProduto> DevolucaoProduto { get; set; }
        public virtual Venda Venda { get; set; }
        public virtual Vendedor Vendedor { get; set; }
    }
}
