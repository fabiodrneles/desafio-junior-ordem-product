// ProductionReport.cs
using System;
using System.Collections.Generic;

namespace DesafioJuniors.Models
{
    public class ProductionReport
    {
        // Listas para armazenar ordens em andamento e concluídas.
        public List<Order> InProgressOrders { get; set; }
        public List<Order> CompletedOrders { get; set; }

        // Construtor da classe.
        public ProductionReport()
        {
            InProgressOrders = new List<Order>(); // Inicializa a lista de ordens em andamento.
            CompletedOrders = new List<Order>(); // Inicializa a lista de ordens concluídas.
        }
    }
}
