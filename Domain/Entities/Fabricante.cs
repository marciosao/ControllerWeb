using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Fabricante
    {
        public Fabricante()
        {
            this.ModeloFabricante = new List<ModeloFabricante>();
            this.Produto = new List<Produto>();
        }

        [Key]
        public int IdFabricante { get; set; }

        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public virtual ICollection<ModeloFabricante> ModeloFabricante { get; set; }
        public virtual ICollection<Produto> Produto { get; set; }
    }
}
