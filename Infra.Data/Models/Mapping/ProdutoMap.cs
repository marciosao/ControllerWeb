using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Infra.Data.Models.Mapping
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            // Primary Key
            this.HasKey(t => t.IdProduto);

            // Properties
            this.Property(t => t.Codigo)
                .HasMaxLength(20);

            this.Property(t => t.Nome)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("PRODUTO");
            this.Property(t => t.IdProduto).HasColumnName("IDE_PRODUTO");
            this.Property(t => t.Codigo).HasColumnName("COD_PRODUTO");
            this.Property(t => t.Nome).HasColumnName("NOM_PRODUTO");
            this.Property(t => t.IdFabricante).HasColumnName("IDE_FABRICANTE");
            this.Property(t => t.IdModelo).HasColumnName("IDE_MODELO");
            this.Property(t => t.QtdEstoque).HasColumnName("QTD_ESTOQUE");
            this.Property(t => t.QtdMinimaEstoque).HasColumnName("QTD_MINIMA_ESTOQUE");
            this.Property(t => t.AvisaEstoqueMinimo).HasColumnName("STS_AVISA_ESTOQUE_MINIMO");

            // Relationships
            this.HasOptional(t => t.Fabricante)
                                .WithMany(t => t.Produto)
                .HasForeignKey(d => d.IdFabricante);
            this.HasOptional(t => t.Modelo)
                                .WithMany(t => t.Produto)
                .HasForeignKey(d => d.IdModelo);

        }
    }
}
