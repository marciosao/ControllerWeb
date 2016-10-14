using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControllerWeb.ViewModels
{
    public class PesquisaOcorrenciaViewModel
    {
        public int IdOcorrencia { get; set; }

        public string TipoEvento { get; set; }
        public int? IdVenda { get; set; }
        public int? IdDevolucao { get; set; }
        public int? IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public decimal QtdProduto { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public int? IdVendedor { get; set; }

        public PagedList<ListaOcorrencias> OcorrenciasPaginadas { get; set; }
    }

    public class ListaOcorrencias
    {
        public int IdOcorrencia { get; set; }
        public string TipoEvento { get; set; }
        public int? IdVenda { get; set; }
        public string CodigoVenda { get; set; }
        public int? IdDevolucao { get; set; }
        public int? IdProduto { get; set; }
        public string Produto { get; set; }
        public decimal QtdProduto { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public int? IdUsuario { get; set; }
        public string Usuario { get; set; }
    }
}