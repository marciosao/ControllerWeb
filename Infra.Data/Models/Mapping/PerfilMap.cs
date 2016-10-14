using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Infra.Data.Models.Mapping
{
    public class PerfilMap : EntityTypeConfiguration<Perfil>
    {
        public PerfilMap()
        {
            // Primary Key
            this.HasKey(t => t.IdPerfil);

            // Properties
            this.Property(t => t.Nome)
                .HasMaxLength(50);

            this.Property(t => t.FlagTipoPerfil)
                .IsFixedLength()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("PERFIL");
            this.Property(t => t.IdPerfil).HasColumnName("IDE_PERFIL");
            this.Property(t => t.Nome).HasColumnName("NOM_PERFIL");
            this.Property(t => t.FlagTipoPerfil).HasColumnName("FLG_TIPO_PERFIL");
            this.Property(t => t.SuperUsuario).HasColumnName("STS_SUPER_USUARIO");
        }
    }
}
