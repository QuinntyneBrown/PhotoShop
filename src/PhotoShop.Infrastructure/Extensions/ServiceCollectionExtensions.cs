using PhotoShop.Core.Interfaces;
using PhotoShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace PhotoShop.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {                
        public static IServiceCollection AddDataStore(this IServiceCollection services,
                                               string connectionString, bool useInMemoryDatabase = false)
        {
            services.AddTransient<IAppDbContext, AppDbContext>();

            return services.AddDbContext<AppDbContext>(options =>
            {
                _ = useInMemoryDatabase 
                ? options.UseInMemoryDatabase(databaseName: "PhotoShop")
                : options.UseSqlServer(connectionString, b => b.MigrationsAssembly("PhotoShop.Infrastructure"));
            });          
        }
    }
}
