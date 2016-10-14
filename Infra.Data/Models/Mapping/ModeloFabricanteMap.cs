using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Infra.Data.Models.Mapping
{
    public class ModeloFabricanteMap : EntityTypeConfiguration<ModeloFabricante>
    {
        public ModeloFabricanteMap()
        {
            // Primary Key
            this.HasKey(t => t.IdModeloFabricante);

            // Properties
            // Table & Column Mappings
            this.ToTable("MODELO_FABRICANTE");
            this.Property(t => t.IdModeloFabricante).HasColumnName("IDE_MODELO_FABRICANTE");
            this.Property(t => t.IdFabricante).HasColumnName("IDE_FABRICANTE");
            this.Property(t => t.IdModelo).HasColumnName("IDE_MODELO");

            // Relationships
            this.HasOptional(t => t.Fabricante)
                                .WithMany(t => t.ModeloFabricante)
                .HasForeignKey(d => d.IdFabricante);
            this.HasOptional(t => t.Modelo)
                                .WithMany(t => t.ModeloFabricante)
                .HasForeignKey(d => d.IdModelo);

        }
    }
}
