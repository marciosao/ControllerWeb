using System.Collections.Generic;

namespace ControllerWeb.ViewModels
{
    public class MenuViewModel
    {
        public MenuViewModel()
        {
            this.PerfilMenu = new List<PerfilMenuViewModel>();
        }

        public int IdMenu { get; set; }
        public string NomeMenuInterno { get; set; }
        public string NomeMenuExterno { get; set; }
        public virtual ICollection<PerfilMenuViewModel> PerfilMenu { get; set; }
    }
}
