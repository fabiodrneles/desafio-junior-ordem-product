// Importando os espaços de nomes necessários.
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioJuniors.Models
{
    // Classe OrderManagementService é responsável por gerenciar as operações relacionadas a ordens de produção e materiais.
    public class OrderManagementService
    {
        // Variável privada para armazenar uma instância de OrderManager.
        private readonly OrderManager orderManager;

        // Construtor da classe que recebe uma instância de OrderManager como parâmetro.
        public OrderManagementService(OrderManager manager)
        {
            orderManager = manager;
        }

        // Método para criar uma nova ordem de produção com detalhes como produto, quantidade e data de entrega.
        public void CreateNewOrder(string product, int quantity, DateTime deliveryDate)
        {
            // Gerando um novo ID de ordem com base na contagem atual de ordens.
            int newOrderId = orderManager.GetOrders().Count + 1;

            // Criando uma nova instância de Order com os detalhes fornecidos.
            Order newOrder = new Order
            {
                Id = newOrderId,
                Product = product,
                Quantity = quantity,
                DeliveryDate = deliveryDate,
                Status = "Pending" // A ordem é inicialmente definida como pendente.
            };

            // Adicionando a nova ordem ao gerenciador de ordens (OrderManager).
            orderManager.AddOrder(newOrder);
        }

        // Método para listar todas as ordens de produção existentes.
        public List<Order> ListAllOrders()
        {
            return orderManager.GetOrders();
        }

        // Método para verificar se um produto pode ser produzido com base nos materiais disponíveis.
        public bool CheckIfProductIsAvailable(string product, int requiredQuantity)
        {
            List<Material> materials = orderManager.GetMaterials();

            // Verificando se a quantidade necessária de materiais está disponível.
            bool available = materials
                .Where(material => material.Name == product)
                .Sum(material => material.Quantity) >= requiredQuantity;

            return available;
        }

        // Método para atualizar o status de uma ordem de produção, indicando se foi concluída ou não.
        public void UpdateOrderStatus(int orderId, string newStatus)
        {
            orderManager.UpdateOrderStatus(orderId, newStatus);
        }

        // Método para listar relatórios de produção, mostrando as ordens em andamento ou concluídas.
        public List<Order> ListProductionReports(bool showCompletedOrders)
        {
            List<Order> orders = orderManager.GetOrders();
            if (showCompletedOrders)
            {
                return orders;
            }
            else
            {
                // Filtrando as ordens para mostrar apenas as que não estão concluídas.
                return orders.Where(order => order.Status != "Completed").ToList();
            }
        }

        // Método para criar um novo material com nome e quantidade especificados.
        public void CreateNewMaterial(string materialName, int quantity)
        {
            Material newMaterial = new Material { Name = materialName, Quantity = quantity };
            orderManager.AddMaterial(newMaterial);
        }

        // Método para listar todos os materiais disponíveis.
        public List<Material> ListMaterials()
        {
            return orderManager.GetMaterials();
        }

        // Método para remover uma ordem de produção com base no ID da ordem.
        public bool RemoveOrder(int orderId)
        {
            Order orderToRemove = orderManager.GetOrders().Find(o => o.Id == orderId);
            if (orderToRemove != null)
            {
                // Removendo a ordem da lista de ordens e salvando as alterações no arquivo.
                orderManager.GetOrders().Remove(orderToRemove);
                orderManager.SaveOrdersToFile();
                return true;
            }
            return false;
        }
    }
}
