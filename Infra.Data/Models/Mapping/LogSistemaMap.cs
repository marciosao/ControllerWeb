using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Infra.Data.Models.Mapping
{
    public class LogSistemaMap : EntityTypeConfiguration<LogSistema>
    {
        public LogSistemaMap()
        {
            // Primary Key
            this.HasKey(t => t.IdLogSistema);

            // Properties
            // Table & Column Mappings
            this.ToTable("LogSistema");
            this.Property(t => t.IdLogSistema).HasColumnName("Id");
            this.Property(t => t.Erro).HasColumnName("Erro");
            this.Property(t => t.Acao).HasColumnName("Acao");
            this.Property(t => t.Tela).HasColumnName("Tela");
            this.Property(t => t.Usuario).HasColumnName("Usuario");
            this.Property(t => t.DataOcorrencia).HasColumnName("DataOcorrencia");
        }
    }
}
