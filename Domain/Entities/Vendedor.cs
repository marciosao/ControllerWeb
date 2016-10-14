using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Vendedor
    {
        public Vendedor()
        {
            this.Devolucao = new List<Devolucao>();
            this.Venda = new List<Venda>();
        }

        [Key]
        public int IdVendedor { get; set; }

        public string Nome { get; set; }
        public string Matricula { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public int? IdPerfil { get; set; }
        public virtual ICollection<Devolucao> Devolucao { get; set; }
        public virtual Perfil Perfil { get; set; }
        public virtual ICollection<Venda> Venda { get; set; }
    }
}
