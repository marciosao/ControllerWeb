using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Infra.Data.Models.Mapping
{
    public class ModeloMap : EntityTypeConfiguration<Modelo>
    {
        public ModeloMap()
        {
            // Primary Key
            this.HasKey(t => t.IdModelo);

            // Properties
            this.Property(t => t.Nome)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MODELO");
            this.Property(t => t.IdModelo).HasColumnName("IDE_MODELO");
            this.Property(t => t.Nome).HasColumnName("DES_MODELO");
            this.Property(t => t.Ativo).HasColumnName("STS_ATIVO");
        }
    }
}
