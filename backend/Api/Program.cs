var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var products = new List<Product>
{
    new(1, "Apple", 1.00m),
    new(2, "Banana", 1.50m)
};

app.MapGet("/", () => "Hello World!");
app.MapGet("/products", () => products);

app.Run();

// Types / records immer ganz unten:
record Product(int Id, string Name, decimal Price);
