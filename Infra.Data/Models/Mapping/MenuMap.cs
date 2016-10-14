using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Infra.Data.Models.Mapping
{
    public class MenuMap : EntityTypeConfiguration<Menu>
    {
        public MenuMap()
        {
            // Primary Key
            this.HasKey(t => t.IdMenu);

            // Properties
            this.Property(t => t.NomeMenuInterno)
                .HasMaxLength(100);

            this.Property(t => t.NomeMenuExterno)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("MENU");
            this.Property(t => t.IdMenu).HasColumnName("IDE_MENU");
            this.Property(t => t.NomeMenuInterno).HasColumnName("DES_MENU_INTERNO");
            this.Property(t => t.NomeMenuExterno).HasColumnName("DES_MENU_EXTERNO");
        }
    }
}
