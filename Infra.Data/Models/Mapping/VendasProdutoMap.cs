using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Infra.Data.Models.Mapping
{
    public class VendasProdutoMap : EntityTypeConfiguration<VendasProduto>
    {
        public VendasProdutoMap()
        {
            // Primary Key
            this.HasKey(t => t.IdVendasProduto);

            // Properties
            this.Property(t => t.IdUsuario)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("VENDAS_PRODUTO");
            this.Property(t => t.IdVendasProduto).HasColumnName("IDE_VENDAS_PRODUTO");
            this.Property(t => t.IdVendas).HasColumnName("IDE_VENDAS");
            this.Property(t => t.IdProduto).HasColumnName("IDE_PRODUTO");
            this.Property(t => t.QtdVendida).HasColumnName("QTD_VENDIDA");
            this.Property(t => t.DataModificacao).HasColumnName("DTC_MODIFICACAO");
            this.Property(t => t.IdUsuario).HasColumnName("IDE_USU_RESPONS");

            // Relationships
            this.HasOptional(t => t.Produto)
                                .WithMany(t => t.VendasProduto)
                .HasForeignKey(d => d.IdProduto);
            this.HasOptional(t => t.Venda)
                                .WithMany(t => t.VendasProduto)
                .HasForeignKey(d => d.IdVendas);

        }
    }
}
