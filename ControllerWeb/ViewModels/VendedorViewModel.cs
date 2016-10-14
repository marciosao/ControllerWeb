using System.Collections.Generic;

namespace ControllerWeb.ViewModels
{
    public class VendedorViewModel
    {
        ////////public VendedorViewModel()
        ////////{
        ////////    this.Devolucao = new List<DevolucaoViewModel>();
        ////////    this.Venda = new List<VendaViewModel>();
        ////////}

        public int IdVendedor { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public int IdPerfil { get; set; }
        ////////public virtual ICollection<DevolucaoViewModel> Devolucao { get; set; }
        ////////public virtual PerfilViewModel Perfil { get; set; }
        ////////public virtual ICollection<VendaViewModel> Venda { get; set; }

        public string Perfil { get; set; }
        
    }
}
