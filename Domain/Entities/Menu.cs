using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Menu
    {
        public Menu()
        {
            this.PerfilMenu = new List<PerfilMenu>();
        }

        [Key]
        public int IdMenu { get; set; }

        public string NomeMenuInterno { get; set; }
        public string NomeMenuExterno { get; set; }
        public virtual ICollection<PerfilMenu> PerfilMenu { get; set; }
    }
}
