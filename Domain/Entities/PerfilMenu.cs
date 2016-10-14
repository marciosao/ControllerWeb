using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class PerfilMenu
    {
        [Key]
        public int IdPerfilMenu { get; set; }

        public int? IdPerfil { get; set; }
        public int? IdMenu { get; set; }
        public virtual Menu Menu { get; set; }
        public virtual Perfil Perfil { get; set; }
    }
}
