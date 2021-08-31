using IntroducaoEFCore.Data.Configurations;
using IntroducaoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroducaoEFCore.Data
{
   public class ApplicationContext : DbContext
   {
      private static readonly ILoggerFactory logger = LoggerFactory.Create(x => x.AddConsole());
    
      public DbSet<Clientes> Clientes { get; set; }
      public DbSet<Pedidos> Pedidos { get; set; }
      public DbSet<PedidoItens> PedidoItens { get; set; }
      public DbSet<Produtos> Produtos { get; set; }


      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
         optionsBuilder
            .UseLoggerFactory(logger)
            .EnableSensitiveDataLogging()
            .UseSqlServer("Server=localhost; Database=CursoEFCore; Trusted_Connection=True;", x => x.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(5), errorNumbersToAdd: null).MigrationsHistoryTable("curso_ef_core_Migrations"));
      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.ApplyConfiguration(new ClientesConfiguration());
         modelBuilder.ApplyConfiguration(new PedidosConfiguration());
         modelBuilder.ApplyConfiguration(new PedidosItensConfiguration());
         modelBuilder.ApplyConfiguration(new ProdutosConfiguration());
         //MapearPropiedadesEsquecidas(modelBuilder);
      }

      private void MapearPropiedadesEsquecidas(ModelBuilder model)
      {
         foreach(IMutableEntityType entity in model.Model.GetEntityTypes())
         {
            IEnumerable<IMutableProperty> properties = entity.GetProperties().Where(p => p.ClrType == typeof(string));
            
            foreach(IMutableProperty p in properties)
            {
               if(string.IsNullOrEmpty(p.GetColumnType()) && !p.GetMaxLength().HasValue)
               {
                  p.SetMaxLength(100);
                  p.SetColumnType("VARCHAR(100)");
               }
            }

         }
      }
   }
}
