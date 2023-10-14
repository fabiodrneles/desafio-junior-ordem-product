using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace DesafioJuniors.Models
{
    public class OrderManager
    {
        // Listas para armazenar ordens e materiais.
        private List<Order> Orders { get; set; }
        private List<Material> Materials { get; set; }

        // Caminho dos arquivos de ordens e materiais.
        private string OrdersFilePath { get; }
        private string MaterialsFilePath { get; }

        // Construtor da classe, recebe caminhos dos arquivos de ordens e materiais.
        public OrderManager(string ordersFilePath, string materialsFilePath)
        {
            OrdersFilePath = ordersFilePath;
            MaterialsFilePath = materialsFilePath;
            LoadData(); // Carrega os dados a partir dos arquivos.
        }

        // Adiciona uma nova ordem à lista e salva no arquivo.
        public void AddOrder(Order order)
        {
            Orders.Add(order);
            SaveOrdersToFile();
        }

        // Obtém a lista de ordens.
        public List<Order> GetOrders()
        {
            return Orders;
        }

        // Adiciona um novo material à lista e salva no arquivo.
        public void AddMaterial(Material material)
        {
            Materials.Add(material);
            SaveMaterialsToFile();
        }

        // Obtém a lista de materiais.
        public List<Material> GetMaterials()
        {
            return Materials;
        }

        // Atualiza o status de uma ordem com base no ID.
        public void UpdateOrderStatus(int orderId, string newStatus)
        {
            Order order = Orders.Find(o => o.Id == orderId);
            if (order != null)
            {
                order.Status = newStatus;
                SaveOrdersToFile();
            }
        }

        // Salva as ordens em um arquivo JSON.
        public void SaveOrdersToFile()
        {
            string ordersJson = JsonConvert.SerializeObject(Orders);
            File.WriteAllText(OrdersFilePath, ordersJson);
        }

        // Salva os materiais em um arquivo JSON.
        public void SaveMaterialsToFile()
        {
            string materialsJson = JsonConvert.SerializeObject(Materials);
            File.WriteAllText(MaterialsFilePath, materialsJson);
        }

        // Carrega os dados a partir dos arquivos JSON, se existirem.
        private void LoadData()
        {
            if (File.Exists(OrdersFilePath))
            {
                string ordersJson = File.ReadAllText(OrdersFilePath);
                Orders = JsonConvert.DeserializeObject<List<Order>>(ordersJson);
            }
            else
            {
                Orders = new List<Order>();
            }

            if (File.Exists(MaterialsFilePath))
            {
                string materialsJson = File.ReadAllText(MaterialsFilePath);
                Materials = JsonConvert.DeserializeObject<List<Material>>(materialsJson);
            }
            else
            {
                Materials = new List<Material>();
            }
        }
    }
}
