using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Infra.Data.Models.Mapping
{
    public class DevolucaoProdutoMap : EntityTypeConfiguration<DevolucaoProduto>
    {
        public DevolucaoProdutoMap()
        {
            // Primary Key
            this.HasKey(t => t.IdDevolucaoProduto);

            // Properties
            // Table & Column Mappings
            this.ToTable("DEVOLUCAO_PRODUTO");
            this.Property(t => t.IdDevolucaoProduto).HasColumnName("IDE_DEVOLUCAO_PRODUTO");
            this.Property(t => t.IdProduto).HasColumnName("IDE_PRODUTO");
            this.Property(t => t.IdDevolucao).HasColumnName("IDE_DEVOLUCAO");
            this.Property(t => t.QtdDevolvida).HasColumnName("QTD_DEVOLVIDA");

            // Relationships
            this.HasOptional(t => t.Devolucao)
                                .WithMany(t => t.DevolucaoProduto)
                .HasForeignKey(d => d.IdDevolucao);
            this.HasOptional(t => t.Produto)
                                .WithMany(t => t.DevolucaoProduto)
                .HasForeignKey(d => d.IdProduto);

        }
    }
}
