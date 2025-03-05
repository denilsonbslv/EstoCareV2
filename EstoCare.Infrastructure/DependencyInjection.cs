using EstoCare.Domain.Interfaces;
using EstoCare.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EstoCare.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Configura o DbContext para usar o SQL Server (ou outro banco de dados)
            services.AddDbContext<EstocareDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Registra os repositórios
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            // Registra o UnitOfWork, se você for utilizar
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
