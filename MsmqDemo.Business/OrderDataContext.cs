using System.Data.Entity;

namespace MsmqDemo.Business
{
    public class OrderDataContext : DbContext
    {
        public DbSet<OrderEntity> Orders { get; set; }

        public DbSet<OrderItemEntity> OrderItems { get; set; } 
    }
}