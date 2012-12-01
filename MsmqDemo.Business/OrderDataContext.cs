using System.Data.Entity;

namespace MsmqDemo.Business
{
    public class OrderDataContext : DbContext
    {
        public OrderDataContext()
            : base("Data Source=localhost;Initial Catalog=DemoOrders;Integrated Security=True;Connect Timeout=5")
        {
        }

        public DbSet<OrderEntity> Orders { get; set; }

        public DbSet<OrderItemEntity> OrderItems { get; set; } 
    }
}