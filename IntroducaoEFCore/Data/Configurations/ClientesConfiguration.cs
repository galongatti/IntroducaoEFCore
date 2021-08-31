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
   public class ClientesConfiguration : IEntityTypeConfiguration<Clientes>
   {
      public void Configure(EntityTypeBuilder<Clientes> builder)
      {       
         builder.ToTable("Clientes");
         builder.HasKey(c => c.Id);
         builder.Property(c => c.Nome).HasColumnType("VARCHAR(80)").IsRequired();
         builder.Property(c => c.Telefone).HasColumnType("CHAR(11)").IsRequired();
         builder.Property(c => c.CEP).HasColumnType("CHAR(8)").IsRequired();
         builder.Property(c => c.Estado).HasColumnType("CHAR(2)").IsRequired();
         builder.Property(c => c.Cidade).HasMaxLength(60).IsRequired();
         builder.HasIndex(i => i.Telefone).HasDatabaseName("idx_cliente_telefone");        
      }
   }
}
