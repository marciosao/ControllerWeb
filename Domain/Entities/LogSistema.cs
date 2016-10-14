using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class LogSistema
    {
        [Key]
        public int IdLogSistema { get; set; }
        public string Erro { get; set; }
        public string Tela { get; set; }
        public string Acao { get; set; }
        public int Usuario { get; set; }
        public DateTime DataOcorrencia { get; set; }

    }
}
