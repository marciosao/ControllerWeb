using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Infra.Data.Models.Mapping
{
    public class FabricanteMap : EntityTypeConfiguration<Fabricante>
    {
        public FabricanteMap()
        {
            // Primary Key
            this.HasKey(t => t.IdFabricante);

            // Properties
            this.Property(t => t.Nome)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("FABRICANTE");
            this.Property(t => t.IdFabricante).HasColumnName("IDE_FABRICANTE");
            this.Property(t => t.Nome).HasColumnName("NOM_FABRICANTE");
            this.Property(t => t.Ativo).HasColumnName("STS_ATIVO");
        }
    }
}
