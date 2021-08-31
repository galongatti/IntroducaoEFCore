using System;
using System.Collections.Generic;
using System.Linq;
using IntroducaoEFCore.Data;
using IntroducaoEFCore.Domain;
using IntroducaoEFCore.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace IntroducaoEFCore
{
   class Program
   {
      static void Main(string[] args)
      {
         //Verificar se existe alguma migração pentende
         //using var db = new Data.ApplicationContext();
         //var existe = db.Database.GetPendingMigrations().Any();
         //if(existe)
         //{
         //   //fazer algo(regra de negocio)
         //}

         //InserirDados();
         //InserirDadosEmMassa();
         //ConsultarDados();
         //AdicionarPedidos();
         //ConsultarPedidoCarregamentoAdiatado();
         //AtualizarDados();
         RemoverDados();
      }

      private static void InserirDados()
      {
         Produtos produto = new Produtos
         {
            Descricao = "Produto Teste",
            CodigoBarras = "123456789",
            Valor = 10m,
            TipoProduto = TipoProduto.MercadoriaRevenda,
            Ativo = true
         };

         ApplicationContext db = new ApplicationContext();
         db.Produtos.Add(produto);
         int inserts = db.SaveChanges();
         Console.WriteLine("Registros inseridos: " + inserts);
      }

      private static void InserirDadosEmMassa()
      {
         Produtos produtos = new Produtos
         {
            Descricao = "Produto Teste 2",
            CodigoBarras = "123456789",
            Valor = 10m,
            TipoProduto = TipoProduto.MercadoriaRevenda,
            Ativo = true
         };

         Clientes clientes = new Clientes
         {
            CEP = "13456875",
            Cidade = "Piracicaba",
            Email = "teste@teste.com.br",
            Estado = "SP",
            Nome = "Gabriel",
            Telefone = "19999999999"
         };

         ApplicationContext db = new ApplicationContext();
         db.AddRange(produtos, clientes);
         int registros = db.SaveChanges();
         Console.WriteLine("Registros inseridos: " + registros);
      }

      private static void ConsultarDados()
      {
         ApplicationContext db = new ApplicationContext();
         //List<Clientes> consultaPorSintaxe =
         //   (
         //      from c in db.Clientes where c.Id > 0 select c
         //   ).ToList();

         //List<Clientes> consultaPorMetodo = db.Clientes.AsNoTracking().Where(x => x.Id > 0).ToList();
         List<Clientes> consultaPorMetodo = db.Clientes.Where(x => x.Id > 0).ToList();

         consultaPorMetodo.ForEach(x =>
         {
            Console.WriteLine("Consultando cliente: " + x.Id);
            //db.Clientes.Find(x.Id);
            db.Clientes.FirstOrDefault(x => x.Id > 0);
         });
      }

      private static void AdicionarPedidos()
      {
         ApplicationContext db = new ApplicationContext();
         Clientes clientes = db.Clientes.FirstOrDefault();
         Produtos produtos = db.Produtos.FirstOrDefault();

         Pedidos pedidos = new Pedidos
         {
            ClienteId = clientes.Id,
            Inicio = DateTime.Now,
            Fim = DateTime.Now,
            Observacao = "Pedido teste",
            Status = StatusPedido.Analise,
            TipoFrente = TipoFrente.SemFrete,
            PedidoItems = new List<PedidoItens>
            {
               new PedidoItens
               {
                  ProdutoID = produtos.Id,
                  Desconto = 0,
                  Quantidade = 1,
                  Valor = 10,
               }
            }
         };

         db.Pedidos.Add(pedidos);
         db.SaveChanges();
      }

      private static void ConsultarPedidoCarregamentoAdiatado()
      {
         ApplicationContext db = new ApplicationContext();
         List<Pedidos> pedidos = 
            db.Pedidos.Include(p => p.PedidoItems )
               .ThenInclude(p => p.Produto)
            .Include(p => p.Cliente).ToList();
         Console.WriteLine(pedidos.Count);
      }

      private static void AtualizarDados()
      {
         ApplicationContext db = new ApplicationContext();
         Clientes cliente = db.Clientes.FirstOrDefault(p => p.Id == 2);
         cliente.Telefone = "19992965447";
         //db.Clientes.Update(cliente);
         db.SaveChanges();
      }

      private static void RemoverDados()
      {
         ApplicationContext db = new ApplicationContext();
         Clientes cliente = db.Clientes.FirstOrDefault(x => x.Id == 3);
         db.Clientes.Remove(cliente);
         db.SaveChanges();
      }
   }
}
