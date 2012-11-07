using System.ComponentModel.DataAnnotations.Schema;

namespace MsmqDemo.Business
{
    [Table("OrderItems")]
    public class OrderItemEntity
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public string ProductIdentifier { get; set; }

        public OrderEntity Order { get; set; }
    }
}