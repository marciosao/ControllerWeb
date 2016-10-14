using System.Collections.Generic;

namespace ControllerWeb.ViewModels
{
    public class PerfilViewModel
    {
        public PerfilViewModel()
        {
            this.PerfilMenu = new List<PerfilMenuViewModel>();
            this.Vendedor = new List<VendedorViewModel>();
        }

        public int IdPerfil { get; set; }
        public string Nome { get; set; }
        public string FlagTipoPerfil { get; set; }
        public bool SuperUsuario { get; set; }
        public virtual ICollection<PerfilMenuViewModel> PerfilMenu { get; set; }
        public virtual ICollection<VendedorViewModel> Vendedor { get; set; }
    }
}
