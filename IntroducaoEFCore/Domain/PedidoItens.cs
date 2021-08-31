namespace IntroducaoEFCore.Domain
{
   public class PedidoItens
   {
      public int Id { get; set; }
      public int PedidoId { get; set; }
      public Pedidos Pedido { get; set; }
      public int ProdutoID { get; set; }
      public Produtos Produto { get; set; }
      public int Quantidade { get; set; }
      public decimal Valor { get; set; }
      public decimal Desconto { get; set; }

   }
}