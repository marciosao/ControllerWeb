using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Perfil
    {
        public Perfil()
        {
            this.PerfilMenu = new List<PerfilMenu>();
            this.Vendedor = new List<Vendedor>();
        }

        [Key]
        public int IdPerfil { get; set; }

        public string Nome { get; set; }
        public string FlagTipoPerfil { get; set; }
        public bool SuperUsuario { get; set; }
        public virtual ICollection<PerfilMenu> PerfilMenu { get; set; }
        public virtual ICollection<Vendedor> Vendedor { get; set; }
    }
}
