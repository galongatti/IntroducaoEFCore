﻿using IntroducaoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroducaoEFCore.Data.Configurations
{
   public class PedidosItensConfiguration : IEntityTypeConfiguration<PedidoItens>
   {
      public void Configure(EntityTypeBuilder<PedidoItens> builder)
      {
         builder.ToTable("PedidoItens");
         builder.HasKey(p => p.Id);
         builder.Property(p => p.Quantidade).HasDefaultValue(1).IsRequired();
         builder.Property(p => p.Valor).HasColumnType("DECIMAL").IsRequired();
         builder.Property(p => p.Desconto).HasColumnType("DECIMAL").IsRequired();
      }
   }
}
