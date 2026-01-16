using Microsoft.EntityFrameworkCore;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public decimal Price { get; set; }
}


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Book> Books => Set<Book>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .Property(b => b.Price)
            .HasPrecision(18, 2); // Fix Decimal-Warnung
    }
}
