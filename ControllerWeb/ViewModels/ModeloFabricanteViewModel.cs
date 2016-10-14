namespace ControllerWeb.ViewModels
{
    public partial class ModeloFabricanteViewModel
    {
        public int IdModeloFabricante { get; set; }
        public int IdFabricante { get; set; }
        public int IdModelo { get; set; }
        public virtual FabricanteViewModel Fabricante { get; set; }
        public virtual ModeloViewModel Modelo { get; set; }
    }
}
