using IntroducaoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroducaoEFCore.Data.Configurations
{
   public class PedidosConfiguration : IEntityTypeConfiguration<Pedidos>
   {
      public void Configure(EntityTypeBuilder<Pedidos> builder)
      {
         builder.ToTable("Pedidos");
         builder.HasKey(p => p.Id);
         builder.Property(p => p.Inicio).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
         builder.Property(p => p.Status).HasConversion<string>();
         builder.Property(p => p.TipoFrente).HasConversion<int>();
         builder.Property(p => p.Observacao).HasColumnType("VARCHAR(512)");
         builder.HasMany(p => p.PedidoItems)
            .WithOne(p => p.Pedido)
            .OnDelete(DeleteBehavior.Cascade);
      }
   }
}
