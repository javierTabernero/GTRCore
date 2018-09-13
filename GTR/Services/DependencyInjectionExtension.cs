using GTR.CrossCutting.DependencyInjection;
using GTR.Repository.Logic.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GTR.Services
{
    public static class DependencyInjectionExtension
    {
        public static void AddDependencyInjectionCustom(this IServiceCollection services, IConfiguration configuration, IHostingEnvironment environment)
        {
            DependencyInjector.RegisterServices(services, environment);

            string connection = configuration.GetConnectionString("BloggingDatabase");
            DependencyInjector.AddDbContext<GtrEntities>(connection);
        }
    }
}