using Domain.Entities;
using PagedList;
using System.Collections.Generic;

namespace ControllerWeb.ViewModels
{
    public class FabricanteViewModel
    {
        public int IdFabricante { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }

        public PagedList<Fabricante> FabricantesPaginados { get; set; }
    }

    //public class Fabricantes
    //{
    //    public int IdFabricante { get; set; }
    //    public string Nome { get; set; }
    //    public bool Ativo { get; set; }
    //}
}
