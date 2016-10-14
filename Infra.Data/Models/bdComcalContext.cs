using System.Data.Entity;
using Infra.Data.Models.Mapping;
using Domain.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;
using System;
using System.Linq;

namespace Infra.Data.Models
{
    public partial class bdComcalContext : DbContext
    {
        static bdComcalContext()
        {
            Database.SetInitializer<bdComcalContext>(null);
        }

        public bdComcalContext()
            : base("Name=bdComcalContext")
        {
        }

        public DbSet<Devolucao> DEVOLUCAO { get; set; }
        public DbSet<DevolucaoProduto> DEVOLUCAO_PRODUTO { get; set; }
        public DbSet<Fabricante> FABRICANTE { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Modelo> MODELO { get; set; }
        public DbSet<ModeloFabricante> MODELO_FABRICANTE { get; set; }
        public DbSet<Ocorrencia> OCORRENCIA { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<PerfilMenu> PerfilMenu { get; set; }
        public DbSet<Produto> PRODUTO { get; set; }
        public DbSet<Venda> VENDA { get; set; }
        public DbSet<VendasProduto> VENDAS_PRODUTO { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }

        public DbSet<LogSistema> LogSistema { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new DevolucaoMap());
            modelBuilder.Configurations.Add(new DevolucaoProdutoMap());
            modelBuilder.Configurations.Add(new FabricanteMap());
            modelBuilder.Configurations.Add(new MenuMap());
            modelBuilder.Configurations.Add(new ModeloMap());
            modelBuilder.Configurations.Add(new ModeloFabricanteMap());
            modelBuilder.Configurations.Add(new OcorrenciaMap());
            modelBuilder.Configurations.Add(new PerfilMap());
            modelBuilder.Configurations.Add(new PerfilMenuMap());
            modelBuilder.Configurations.Add(new ProdutoMap());
            modelBuilder.Configurations.Add(new VendaMap());
            modelBuilder.Configurations.Add(new VendasProdutoMap());
            modelBuilder.Configurations.Add(new VendedorMap());
            modelBuilder.Configurations.Add(new LogSistemaMap());

            modelBuilder.Properties().Where(p => "Id" + p.Name == p.ReflectedType.Name).Configure(p => p.IsKey());

            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            modelBuilder.Properties<String>().Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            //modelBuilder.Entity<Venda>()
            //            .Property(f => f.DataVenda)
            //            .HasColumnType("datetime2")
            //            .HasPrecision(0);

            //modelBuilder.Entity<Venda>()
            //            .Property(f => f.DataModificacao)
            //            .HasColumnType("datetime2")
            //            .HasPrecision(0);

        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataVenda") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataModificacao").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataModificacao").IsModified = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataPagamento") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataVenda").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataVenda").IsModified = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataFaturamento") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataOcorrencia").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataOcorrencia").IsModified = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataEntradaEstoque") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataDevolucao").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataDevolucao").IsModified = false;
                }
            }

            return base.SaveChanges();
        }
    }
}
