using LivroDeReceitas.Domain.Repositories;
using LivroDeReceitas.Domain.Repositories.User;
using LivroDeReceitas.Domain.Security.PasswordHashing;
using LivroDeReceitas.Infrastructure.DataAccess;
using LivroDeReceitas.Infrastructure.Repositories;
using LivroDeReceitas.Infrastructure.Security.PasswordHashing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LivroDeReceitas.Infrastructure;

public static class DependencyInjectionExtension
{
    extension(IServiceCollection services)
    {
        public void AddInfrastructure(IConfiguration configuration)
        {
            services.AddScoped<IPasswordHasher, Argon2PasswordHasher>();

            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
            // services.AddScoped<IUserReadOnlyRepository, UserRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddDbContext<LivroDeReceitasDbContext>(config =>
            {
                config.UseMySQL(configuration.GetConnectionString("Connection")!);
            });
        }
    }
}
