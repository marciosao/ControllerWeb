using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public partial class ModeloFabricante
    {
        [Key]
        public int IdModeloFabricante { get; set; }

        public int? IdFabricante { get; set; }
        public int? IdModelo { get; set; }
        public virtual Fabricante Fabricante { get; set; }
        public virtual Modelo Modelo { get; set; }
    }
}
