using EstoCare.Infrastructure;
using EstoCare.Domain.Interfaces;
using EstoCare.Infrastructure.Repositories;
using EstoCare.Application.Interfaces;
using EstoCare.Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco de dados
builder.Services.AddDbContext<EstocareDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Injeção de dependências - Repositórios
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Injeção de dependências - Serviços
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();

// Configuração de CORS (permitindo requisições do frontend, ajuste conforme necessário)
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Configuração de Controllers
builder.Services.AddControllers();

// Configuração do Swagger para documentação da API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "EstoCare API",
        Version = "v1",
        Description = "API para gerenciamento de estoque",
    });
});

// Middleware para tratamento global de exceções
//builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

var app = builder.Build();

// Middleware de tratamento global de erros (caso tenha um handler customizado)
app.UseExceptionHandler("/error");

// Habilita o Swagger apenas em desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "EstoCare API v1");
        c.RoutePrefix = "swagger";
    });
}

// Ativa CORS
app.UseCors("CorsPolicy");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
