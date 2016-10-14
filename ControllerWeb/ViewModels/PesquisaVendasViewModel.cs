using Domain.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControllerWeb.ViewModels
{
    public class PesquisaVendasViewModel
    {
        public string Codigo { get; set; }
        public DateTime DataVenda { get; set; }
        public int? IdVendedor { get; set; }
        public int? IdProduto { get; set; }

        public IEnumerable<Venda> Vendas { get; set; }

        public PagedList<Venda> VendasPaginadas { get; set; }
    }
}