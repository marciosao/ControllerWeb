using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Infra.Data.Models.Mapping
{
    public class VendedorMap : EntityTypeConfiguration<Vendedor>
    {
        public VendedorMap()
        {
            // Primary Key
            this.HasKey(t => t.IdVendedor);

            // Properties
            this.Property(t => t.Nome)
                .HasMaxLength(100);

            this.Property(t => t.Matricula)
                .HasMaxLength(20);

            this.Property(t => t.Senha)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("VENDEDOR");
            this.Property(t => t.IdVendedor).HasColumnName("IDE_VENDEDOR");
            this.Property(t => t.Nome).HasColumnName("NOM_VENDEDOR");
            this.Property(t => t.Matricula).HasColumnName("NUM_MATRICULA");
            this.Property(t => t.Senha).HasColumnName("DES_SENHA");
            this.Property(t => t.Ativo).HasColumnName("STS_ATIVO");
            this.Property(t => t.IdPerfil).HasColumnName("IDE_PERFIL");

            // Relationships
            this.HasOptional(t => t.Perfil)
                .WithMany(t => t.Vendedor)
                .HasForeignKey(d => d.IdPerfil);

        }
    }
}
