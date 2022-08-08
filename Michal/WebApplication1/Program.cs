using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<CosDbContext, CosDbContext>();

string conn = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<CosDbContext>(options =>
{
    options.UseMySql(conn, ServerVersion.AutoDetect(conn));
});



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
