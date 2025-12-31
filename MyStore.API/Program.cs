using Microsoft.EntityFrameworkCore;
using MyStore.Application.Products;
using MyStore.Domain.Interfaces;
using MyStore.Infrastructure;
using MyStore.Infrastructure.Data;
using MyStore.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Serviços de domínio e aplicação
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Swagger - sempre visível
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyStore API V1");
    c.RoutePrefix = ""; // Swagger acessível em https://localhost:porta/
});

// Middlewares padrão
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
