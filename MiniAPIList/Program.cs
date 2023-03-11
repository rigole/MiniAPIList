using Microsoft.EntityFrameworkCore;
using MiniAPIList;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApiDbContext>(opt => opt.UseInMemoryDatabase("MiniAPIList"));


var app = builder.Build();



app.MapGet("/shoppinglist", async (ApiDbContext db) => await db.Groceries.ToListAsync());

app.MapPost("/shoppinglist", async (Grocery grocery, ApiDbContext db) => {

    db.Groceries.Add(grocery);

    await db.SaveChangesAsync();

    return Results.Created($"/shoppinglist/{grocery.Id}", grocery);
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
 
app.Run();