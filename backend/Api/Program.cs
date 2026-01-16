using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();


        
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

app.Run();
