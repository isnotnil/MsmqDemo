using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MsmqDemo.Business
{
    [Table("Order")]
    public class OrderEntity
    {
        public int Id { get; set; }

        public string VenderNumber { get; set; }

        public DateTime RequestedDeliveryDate { get; set; }

        public string ConfirmationEmailAddress { get; set; }

        public DateTime DateCreated { get; set; }

        [ForeignKey("OrderId")]
        public Collection<OrderItemEntity> OrderItems { get; set; } 
    }
}