using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Infra.Data.Models.Mapping
{
    public class DevolucaoMap : EntityTypeConfiguration<Devolucao>
    {
        public DevolucaoMap()
        {
            // Primary Key
            this.HasKey(t => t.IdDevolucao);

            // Properties
            // Table & Column Mappings
            this.ToTable("DEVOLUCAO");
            this.Property(t => t.IdDevolucao).HasColumnName("IDE_DEVOLUCAO");
            this.Property(t => t.IdVendas).HasColumnName("IDE_VENDAS");
            this.Property(t => t.IdVendedor).HasColumnName("IDE_VENDEDOR");
            this.Property(t => t.DataDevolucao).HasColumnName("DTC_DEVOLUCAO");
            this.Property(t => t.IdUsuario).HasColumnName("IDE_USU_RESPONS");
            this.Property(t => t.DataModificacao).HasColumnName("DTC_MODIFICACAO");

            // Relationships
            this.HasOptional(t => t.Venda)
                                .WithMany(t => t.Devolucao)
                .HasForeignKey(d => d.IdVendas);
            this.HasOptional(t => t.Vendedor)
                                .WithMany(t => t.Devolucao)
                .HasForeignKey(d => d.IdVendedor);

        }
    }
}
