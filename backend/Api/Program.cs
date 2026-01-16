using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite")));

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

<<<<<<< HEAD
var products = new List<Product>
{
    new(1, "Apple", 1.00m),
    new(2, "Banana", 1.50m)
};

app.MapGet("/", () => "Hello World!");
app.MapGet("/products", () => products);
=======

app.MapPost("/books", async (Book book, AppDbContext db) =>
{
    if (book.Price <= 0)
        return Results.BadRequest("Price must be greater than zero");

    db.Books.Add(book);
    await db.SaveChangesAsync();
    return Results.Created($"/books/{book.Id}", book);
});

app.MapGet("/books", async (AppDbContext db) =>
    await db.Books.ToListAsync());
>>>>>>> 48ba7c00906851ff8b637ee5c7ee68e490775f77

app.Run();

// Types / records immer ganz unten:
record Product(int Id, string Name, decimal Price);
