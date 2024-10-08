using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            OrderService orderService = new OrderService(db);   
            var orders = orderService.GetAllOrders();
            orderService.DeleteOrder(1);
            orderService.GetOrderById(2);
        }
    }
}
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Count { get; set; }
    public int? OrderId { get; set; }
    public Order? Order { get; set; }
}
public class Order
{
    public int Id { get; set; }
    public List<Product>? Products { get; set; }
}
public class OrderService
{
    private readonly ApplicationContext _context;

    public OrderService(ApplicationContext context)
    {
        _context = context;
    }

    public void AddOrder(Order order)
    {
        _context.Orders.Add(order);
        _context.SaveChanges();
    }

    public void DeleteOrder(int orderId)
    {
        var order = _context.Orders.FirstOrDefault(o => o.Id == orderId);
        if (order != null)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }
        else
        {
            Console.WriteLine($"Order with Id {orderId} not found.");
        }
    }

    public List<Order> GetAllOrders()
    {
        return _context.Orders.Include(o => o.Products).ToList();
    }

    public Order? GetOrderById(int orderId)
    {
        return _context.Orders.Include(o => o.Products).FirstOrDefault(o => o.Id == orderId);
    }
}
public class ApplicationContext : DbContext
{
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public ApplicationContext() { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Order)
            .WithMany(o => o.Products)
            .HasForeignKey(p => p.OrderId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Order>().HasData(
            new Order() { Id = 1 },
            new Order() { Id = 2 }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product() { Id = 1, Name = "Crystal Soda", Price = 2.99m, Count = 100, OrderId = 1 },
            new Product() { Id = 2, Name = "Starberry Juice", Price = 3.49m, Count = 50, OrderId = 1 },
            new Product() { Id = 3, Name = "Shadow Coffee", Price = 5.99m, Count = 75, OrderId = 2 },
            new Product() { Id = 4, Name = "Moonlight Tea", Price = 4.99m, Count = 120, OrderId = 2 }
        );

        base.OnModelCreating(modelBuilder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EFCoreDB;Trusted_Connection=True;");
    }
}