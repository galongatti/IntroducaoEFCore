using IntroducaoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroducaoEFCore.Data
{
   public class ProdutosConfiguration : IEntityTypeConfiguration<Produtos>
   {
      public void Configure(EntityTypeBuilder<Produtos> builder)
      {
         builder.ToTable("Produtos");
         builder.HasKey(p => p.Id);
         builder.Property(p => p.CodigoBarras).HasColumnType("VARCHAR(14)").IsRequired();
         builder.Property(p => p.Descricao).HasColumnType("VARCHAR(60)").IsRequired();
         builder.Property(p => p.Valor).HasColumnType("DECIMAL").IsRequired();
         builder.Property(p => p.TipoProduto).HasConversion<string>();
      }
   }
}
