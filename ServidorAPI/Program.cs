using Microsoft.EntityFrameworkCore;
using ServidorAPI.Contenido;
using ServidorAPI.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("MiConexionLocalSQLite")));

var app = builder.Build();

app.MapGet("api/plato", async (AppDbContext context) =>
{
    var elementos = await context.Platos.ToListAsync();
    return Results.Ok(elementos);
});
app.MapPost("api/plato", async (AppDbContext context, Plato plato) =>
{
    await context.Platos.AddAsync(plato);
    await context.SaveChangesAsync();
    return Results.Created($"/api/plato/{plato.Id}", plato);
});
app.MapPut("api/plato/{id}", async (AppDbContext context, int id, Plato platoModificado) =>
{
    var plato = await context.Platos.FirstOrDefaultAsync(pl=>pl.Id == id);
    if (plato == null)
        return Results.NotFound(); // 404
    plato.Nombre = platoModificado.Nombre;
    await context.SaveChangesAsync();
    return Results.NoContent(); // 204
});
app.MapDelete("api/plato/{id}", async (AppDbContext context, int id) =>
{
    var plato = await context.Platos.FirstOrDefaultAsync(pl => pl.Id == id);
    if (plato == null)
        return Results.NotFound(); // 404
    context.Platos.Remove(plato);
    await context.SaveChangesAsync();
    return Results.NoContent(); // 204
});
app.Run();
