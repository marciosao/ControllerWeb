using System;

namespace ControllerWeb.ViewModels
{
    public class OcorrenciaViewModel
    {
        public int IdOcorrencia { get; set; }
        public string TipoEvento { get; set; }
        public int IdVenda { get; set; }
        public int IdDevolucao { get; set; }
        public int IdProduto { get; set; }
        public decimal QtdProduto { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public int IdUsuario { get; set; }
    }
}
