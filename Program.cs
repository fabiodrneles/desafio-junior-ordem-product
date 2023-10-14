using System;
using DesafioJuniors.Models;

namespace DesafioJuniors
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define os caminhos dos arquivos de ordens e materiais
            string ordersFilePath = "orders.json";
            string materialsFilePath = "materials.json";

            // Inicializa o gerenciador de ordens e o serviço de gerenciamento de ordens
            OrderManager orderManager = new OrderManager(ordersFilePath, materialsFilePath);
            OrderManagementService orderService = new OrderManagementService(orderManager);

            while (true)
            {
                Console.WriteLine("Sistema de Gerenciamento de Ordens de Produção");
                Console.WriteLine("1. Registrar uma nova ordem de produção");
                Console.WriteLine("2. Listar todas as ordens de produção");
                Console.WriteLine("3. Verificar materiais disponíveis");
                Console.WriteLine("4. Atualizar o status de uma ordem de produção");
                Console.WriteLine("5. Visualizar relatórios de produção");
                Console.WriteLine("6. Remover uma ordem de produção"); // Opção de remoção de ordem
                Console.WriteLine("7. Cadastrar material");
                Console.WriteLine("8. Sair");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Produto: ");
                        string product = Console.ReadLine();
                        Console.Write("Quantidade: ");
                        int quantity = int.Parse(Console.ReadLine());
                        Console.Write("Data de Entrega (opcional, no formato dd/MM/yyyy): ");
                        if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime deliveryDate))
                        {
                            // Cria uma nova ordem e a adiciona
                            orderService.CreateNewOrder(product, quantity, deliveryDate.Date);
                            orderManager.SaveOrdersToFile();
                        }
                        else
                        {
                            Console.WriteLine("Data de entrega inválida. Use o formato dd/MM/yyyy.");
                        }
                        break;

                    case "2":
                        // Lista todas as ordens de produção
                        var orders = orderService.ListAllOrders();
                        Console.WriteLine("Ordens de Produção:");
                        foreach (var order in orders)
                        {
                            Console.WriteLine($"ID: {order.Id}, Produto: {order.Product}, Quantidade: {order.Quantity}, Data de Entrega: {order.DeliveryDate:dd/MM/yyyy}, Status: {order.Status}");
                        }
                        break;

                    case "3":
                        Console.Write("Produto: ");
                        string materialProduct = Console.ReadLine();
                        Console.Write("Quantidade necessária: ");
                        int requiredQuantity = int.Parse(Console.ReadLine());

                        // Verifica se a produção é possível com base nos materiais disponíveis
                        bool isAvailable = orderService.CheckIfProductIsAvailable(materialProduct, requiredQuantity);

                        if (isAvailable)
                        {
                            Console.WriteLine("Produção possível. Materiais disponíveis.");
                        }
                        else
                        {
                            Console.WriteLine("Produção não é possível devido à falta de materiais.");
                        }
                        break;

                    case "4":
                        Console.Write("ID da Ordem: ");
                        int orderId = int.Parse(Console.ReadLine());
                        Console.Write("Novo Status (Em andamento/Concluída): ");
                        string newStatus = Console.ReadLine();

                        // Atualiza o status de uma ordem de produção
                        orderService.UpdateOrderStatus(orderId, newStatus);
                        orderManager.SaveOrdersToFile();
                        break;

                    case "5":
                        // Gera um relatório de produção
                        Console.WriteLine("Relatório de Produção:");
                        var productionReport = orderService.ListProductionReports(false);
                        foreach (var order in productionReport)
                        {
                            Console.WriteLine($"ID: {order.Id}, Produto: {order.Product}, Quantidade: {order.Quantity}, Data de Entrega: {order.DeliveryDate:dd/MM/yyyy}, Status: {order.Status}");
                        }
                        break;

                    case "6":
                        Console.Write("ID da Ordem a ser removida: ");
                        int orderIdToRemove = int.Parse(Console.ReadLine());

                        // Remove uma ordem de produção
                        bool removed = orderService.RemoveOrder(orderIdToRemove);

                        if (removed)
                        {
                            Console.WriteLine("Ordem removida com sucesso.");
                            orderManager.SaveOrdersToFile();
                        }
                        else
                        {
                            Console.WriteLine("Não foi possível remover a ordem. Verifique o ID da ordem.");
                        }
                        break;

                    case "7":
                        Console.Write("Nome do Material: ");
                        string materialName = Console.ReadLine();
                        Console.Write("Quantidade: ");
                        int materialQuantity = int.Parse(Console.ReadLine());

                        // Cadastra um novo material
                        orderService.CreateNewMaterial(materialName, materialQuantity);
                        orderManager.SaveMaterialsToFile();
                        break;

                    case "8":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                        break;
                }
            }
        }
    }
}