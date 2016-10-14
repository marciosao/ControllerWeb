using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Infra.Data.Models.Mapping
{
    public class VendaMap : EntityTypeConfiguration<Venda>
    {
        public VendaMap()
        {
            // Primary Key
            this.HasKey(t => t.IdVenda);

            // Properties
            this.Property(t => t.Codigo)
                .HasMaxLength(30);

            this.Property(t => t.IdUsuario)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("VENDAS");
            this.Property(t => t.IdVenda).HasColumnName("IDE_VENDAS");
            this.Property(t => t.Codigo).HasColumnName("COD_VENDA");
            this.Property(t => t.DataVenda).HasColumnName("DTC_VENDA");
            this.Property(t => t.IdVendedor).HasColumnName("IDE_VENDEDOR");
            this.Property(t => t.QtdVendida).HasColumnName("QTD_VENDIDA");
            this.Property(t => t.DataModificacao).HasColumnName("DTC_MODIFICACAO");
            this.Property(t => t.IdUsuario).HasColumnName("IDE_USU_RESPONS");
            this.Property(t => t.IdProduto).HasColumnName("IDE_PRODUTO");

            // Relationships
            this.HasOptional(t => t.Vendedor)
                                .WithMany(t => t.Venda)
                .HasForeignKey(d => d.IdVendedor);

        }
    }
}
