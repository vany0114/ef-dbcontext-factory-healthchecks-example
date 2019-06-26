using Microsoft.EntityFrameworkCore;

namespace dbcontextfactory_healthcheck
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Orders { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }
    }
}
