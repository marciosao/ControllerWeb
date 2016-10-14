using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Produto
    {
        public Produto()
        {
            this.DevolucaoProduto = new List<DevolucaoProduto>();
            this.VendasProduto = new List<VendasProduto>();
        }

        [Key]
        public int IdProduto { get; set; }

        public string Codigo { get; set; }
        public string Nome { get; set; }
        public int? IdFabricante { get; set; }
        public int? IdModelo { get; set; }
        public decimal QtdEstoque { get; set; }
        public decimal QtdMinimaEstoque { get; set; }
        public bool AvisaEstoqueMinimo { get; set; }
        public virtual ICollection<DevolucaoProduto> DevolucaoProduto { get; set; }
        public virtual Fabricante Fabricante { get; set; }
        public virtual Modelo Modelo { get; set; }
        public virtual ICollection<VendasProduto> VendasProduto { get; set; }
    }
}
