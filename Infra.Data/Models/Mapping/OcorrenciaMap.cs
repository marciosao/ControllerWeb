using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Infra.Data.Models.Mapping
{
    public class OcorrenciaMap : EntityTypeConfiguration<Ocorrencia>
    {
        public OcorrenciaMap()
        {
            // Primary Key
            this.HasKey(t => t.IdOcorrencia);

            // Properties
            this.Property(t => t.TipoEvento)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("OCORRENCIA");
            this.Property(t => t.IdOcorrencia).HasColumnName("IDE_OCORRENCIA");
            this.Property(t => t.TipoEvento).HasColumnName("TIPO_EVENTO");
            this.Property(t => t.IdVenda).HasColumnName("IDE_VENDA");
            this.Property(t => t.IdDevolucao).HasColumnName("IDE_DEVOLUCAO");
            this.Property(t => t.IdProduto).HasColumnName("IDE_PRODUTO");
            this.Property(t => t.QtdProduto).HasColumnName("QTD_PRODUTO");
            this.Property(t => t.DataOcorrencia).HasColumnName("DTC_OCORRENCIA");
            this.Property(t => t.IdUsuario).HasColumnName("IDE_USU_RESPONS");
        }
    }
}
