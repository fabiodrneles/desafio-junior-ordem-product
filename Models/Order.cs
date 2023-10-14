// Importando o espaço de nomes System para usar funcionalidades básicas.
using System;

// Definindo o namespace para organizar a classe.
namespace DesafioJuniors.Models
{
    // Declaração da classe Order, que representa uma ordem de produção.
    public class Order
    {
        // Propriedade que representa o ID único da ordem de produção.
        public int Id { get; set; }

        // Propriedade que representa o nome do produto a ser fabricado.
        public string Product { get; set; }

        // Propriedade que representa a quantidade desejada do produto.
        public int Quantity { get; set; }

        // Propriedade que representa a data de entrega da ordem de produção.
        public DateTime DeliveryDate { get; set; }

        // Propriedade que representa o status da ordem de produção (Ex: Pendente, Concluída).
        public string Status { get; set; }
    }
}
