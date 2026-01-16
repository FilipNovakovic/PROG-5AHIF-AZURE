using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite")));

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
