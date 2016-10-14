using Domain.Entities;
using PagedList;
using System;
using System.Collections.Generic;

namespace ControllerWeb.ViewModels
{
    public class DevolucaoViewModel
    {
        public int IdDevolucao { get; set; }
        public int IdVendedor { get; set; }
        public string Vendedor { get; set; }
        public string Produto { get; set; }
        public DateTime DataDevolucao { get; set; }

        public PagedList<Devolucao> DevolucaoPaginada { get; set; }
    }
}
