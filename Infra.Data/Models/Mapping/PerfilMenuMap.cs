using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Infra.Data.Models.Mapping
{
    public class PerfilMenuMap : EntityTypeConfiguration<PerfilMenu>
    {
        public PerfilMenuMap()
        {
            // Primary Key
            this.HasKey(t => t.IdPerfilMenu);

            // Properties
            // Table & Column Mappings
            this.ToTable("PERFIL_MENU");
            this.Property(t => t.IdPerfilMenu).HasColumnName("IDE_PERFIL_MENU");
            this.Property(t => t.IdPerfil).HasColumnName("IDE_PERFIL");
            this.Property(t => t.IdMenu).HasColumnName("IDE_MENU");

            // Relationships
            this.HasOptional(t => t.Menu)
                                .WithMany(t => t.PerfilMenu)
                .HasForeignKey(d => d.IdMenu);
            this.HasOptional(t => t.Perfil)
                                .WithMany(t => t.PerfilMenu)
                .HasForeignKey(d => d.IdPerfil);

        }
    }
}
