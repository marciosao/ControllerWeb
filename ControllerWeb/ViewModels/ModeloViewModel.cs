using System.Collections.Generic;

namespace ControllerWeb.ViewModels
{
    public class ModeloViewModel
    {
        public ModeloViewModel()
        {
            this.ModeloFabricante = new List<ModeloFabricanteViewModel>();
            this.Produto = new List<ProdutoViewModel>();
        }

        public int IdModelo { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public virtual ICollection<ModeloFabricanteViewModel> ModeloFabricante { get; set; }
        public virtual ICollection<ProdutoViewModel> Produto { get; set; }
    }
}
