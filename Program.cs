using System;

namespace CozinhaIndustrial
{
    internal class Program
    {
        static Restaurante restaurante = new Restaurante();

        static Item[] cardapio =
        {
            new Item(1, "Arroz", 8.00),
            new Item(2, "Feijao", 7.00),
            new Item(3, "Bife", 18.00),
            new Item(4, "Frango", 15.00),
            new Item(5, "Batata Frita", 12.00),
            new Item(6, "Salada", 10.00),
            new Item(7, "Suco", 6.00),
            new Item(8, "Refrigerante", 7.00),
            new Item(9, "Sobremesa", 9.00),
            new Item(10, "Cafe", 5.00)
        };

        static void Main(string[] args)
        {
            int opcao;

            do
            {
                Console.Clear();
                Console.WriteLine("======================================");
                Console.WriteLine("       COZINHA INDUSTRIAL");
                Console.WriteLine("======================================");
                Console.WriteLine("1 - Criar novo pedido");
                Console.WriteLine("2 - Adicionar item ao pedido");
                Console.WriteLine("3 - Remover item do pedido");
                Console.WriteLine("4 - Consultar pedido");
                Console.WriteLine("5 - Cancelar pedido");
                Console.WriteLine("6 - Listar todos os pedidos");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("======================================");
                Console.Write("Escolha uma opcao: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                    opcao = -1;

                switch (opcao)
                {
                    case 1: CriarPedido(); break;
                    case 2: AdicionarItem(); break;
                    case 3: RemoverItem(); break;
                    case 4: ConsultarPedido(); break;
                    case 5: CancelarPedido(); break;
                    case 6: ListarPedidos(); break;
                    case 0:
                        Console.WriteLine("\nSistema encerrado.");
                        break;
                    default:
                        Console.WriteLine("\nOpcao invalida.");
                        break;
                }

                if (opcao != 0)
                {
                    Console.WriteLine("\nPressione ENTER para continuar...");
                    Console.ReadLine();
                }

            } while (opcao != 0);
        }

        static void CriarPedido()
        {
            Console.Clear();
            Console.WriteLine("========== NOVO PEDIDO ==========\n");

            if (restaurante.ProxPedido > 50)
            {
                Console.WriteLine("Limite de 50 pedidos atingido.");
                return;
            }

            Console.Write("Nome do cliente: ");
            string cliente = Console.ReadLine() ?? "";

            int id = restaurante.ProxPedido;
            Pedido pedido = new Pedido(id, cliente);

            if (restaurante.novoPedido(pedido))
            {
                Console.WriteLine("\nPedido criado com sucesso!");
                Console.WriteLine("ID do pedido: " + id);
            }
            else
            {
                Console.WriteLine("\nNao foi possivel criar o pedido.");
            }
        }

        static void AdicionarItem()
        {
            Console.Clear();
            Console.WriteLine("========== ADICIONAR ITEM ==========\n");

            Console.Write("Digite o ID do pedido: ");
            if (!int.TryParse(Console.ReadLine(), out int idPedido))
            {
                Console.WriteLine("\nID invalido.");
                return;
            }

            Pedido? pedido = EncontrarPedido(idPedido);

            if (pedido == null)
            {
                Console.WriteLine("\nPedido nao encontrado.");
                return;
            }

            Console.WriteLine("\nPedido: " + pedido.Id);
            Console.WriteLine("Cliente: " + pedido.Cliente);
            Console.WriteLine("\n========== CARDAPIO ==========");

            foreach (Item item in cardapio)
                Console.WriteLine(item);

            Console.Write("\nDigite o ID do item: ");
            if (!int.TryParse(Console.ReadLine(), out int idItem))
            {
                Console.WriteLine("\nID invalido.");
                return;
            }

            Item? itemSelecionado = EncontrarItem(idItem);

            if (itemSelecionado == null)
            {
                Console.WriteLine("\nItem nao encontrado.");
                return;
            }

            if (pedido.adicionarItem(itemSelecionado))
                Console.WriteLine("\nItem adicionado com sucesso!");
            else
                Console.WriteLine("\nO pedido ja possui 10 itens.");
        }

        static void RemoverItem()
        {
            Console.Clear();
            Console.WriteLine("========== REMOVER ITEM ==========\n");

            Console.Write("Digite o ID do pedido: ");
            if (!int.TryParse(Console.ReadLine(), out int idPedido))
            {
                Console.WriteLine("\nID invalido.");
                return;
            }

            Pedido? pedido = EncontrarPedido(idPedido);

            if (pedido == null)
            {
                Console.WriteLine("\nPedido nao encontrado.");
                return;
            }

            Console.WriteLine("\nItens do pedido:");
            bool possuiItens = false;

            foreach (Item? item in pedido.Itens)
            {
                if (item != null)
                {
                    Console.WriteLine(item);
                    possuiItens = true;
                }
            }

            if (!possuiItens)
            {
                Console.WriteLine("O pedido nao possui itens.");
                return;
            }

            Console.Write("\nDigite o ID do item que deseja remover: ");
            if (!int.TryParse(Console.ReadLine(), out int idItem))
            {
                Console.WriteLine("\nID invalido.");
                return;
            }

            Item? itemSelecionado = EncontrarItem(idItem);

            if (itemSelecionado == null)
            {
                Console.WriteLine("\nItem nao encontrado.");
                return;
            }

            if (pedido.removerItem(itemSelecionado))
                Console.WriteLine("\nItem removido com sucesso!");
            else
                Console.WriteLine("\nEsse item nao esta no pedido.");
        }

        static void ConsultarPedido()
        {
            Console.Clear();
            Console.WriteLine("========== CONSULTAR PEDIDO ==========\n");

            Console.Write("Digite o ID do pedido: ");
            if (!int.TryParse(Console.ReadLine(), out int idPedido))
            {
                Console.WriteLine("\nID invalido.");
                return;
            }

            Pedido? pedido = EncontrarPedido(idPedido);

            if (pedido == null)
            {
                Console.WriteLine("\nPedido nao encontrado.");
                return;
            }

            Console.WriteLine("\n" + pedido.dadosDoPedido());
        }

        static void CancelarPedido()
        {
            Console.Clear();
            Console.WriteLine("========== CANCELAR PEDIDO ==========\n");

            Console.Write("Digite o ID do pedido: ");
            if (!int.TryParse(Console.ReadLine(), out int idPedido))
            {
                Console.WriteLine("\nID invalido.");
                return;
            }

            Pedido? pedido = EncontrarPedido(idPedido);

            if (pedido == null)
            {
                Console.WriteLine("\nPedido nao encontrado.");
                return;
            }

            if (restaurante.cancelarPedido(pedido))
                Console.WriteLine("\nPedido cancelado com sucesso!");
            else
                Console.WriteLine("\nNao foi possivel cancelar o pedido.");
        }

        static void ListarPedidos()
        {
            Console.Clear();
            Console.WriteLine("========== PEDIDOS DO DIA ==========\n");

            double somaGeral = 0;
            bool possuiPedidos = false;

            foreach (Pedido? pedido in restaurante.Pedidos)
            {
                if (pedido != null)
                {
                    double total = pedido.calcularTotal();

                    Console.WriteLine(
                        "Pedido: " + pedido.Id +
                        " | Cliente: " + pedido.Cliente +
                        " | Total: R$ " + total.ToString("F2"));

                    somaGeral += total;
                    possuiPedidos = true;
                }
            }

            if (!possuiPedidos)
                Console.WriteLine("Nenhum pedido cadastrado.");

            Console.WriteLine("\n--------------------------------------");
            Console.WriteLine("Soma geral do dia: R$ " + somaGeral.ToString("F2"));
        }

        static Pedido? EncontrarPedido(int id)
        {
            foreach (Pedido? pedido in restaurante.Pedidos)
            {
                if (pedido != null && pedido.Id == id)
                    return pedido;
            }

            return null;
        }

        static Item? EncontrarItem(int id)
        {
            foreach (Item item in cardapio)
            {
                if (item.Id == id)
                    return item;
            }

            return null;
        }
    }
}
