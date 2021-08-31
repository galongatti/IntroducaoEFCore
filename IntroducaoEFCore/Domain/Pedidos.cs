using IntroducaoEFCore.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroducaoEFCore.Domain
{
   public class Pedidos
   {
      public int Id { get; set; }
      public int ClienteId { get; set; }
      public Clientes Cliente { get; set; }
      public DateTime Inicio { get; set; }
      public DateTime Fim { get; set; }
      public TipoFrente TipoFrente { get; set; }
      public StatusPedido Status { get; set; }
      public string Observacao { get; set; }
      public ICollection<PedidoItens> PedidoItems { get; set; }
   }
}
