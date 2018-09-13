//using GTR.CrossCutting.Logging;
using GTR.CrossCutting.Mapping;
using GTR.Domain.Logic.Services;
using GTR.Domain.Logic.Validations;
using GTR.Domain.Services;
using GTR.Domain.Validations;
using GTR.Repository;
using GTR.Repository.Logic.Model;
using GTR.Repository.Logic.Repositories;
using GTR.Repository.Repositories;
using GTR.Service.Logic.Services;
using GTR.Service.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GTR.CrossCutting.DependencyInjection
{
    public static class DependencyInjector
    {
        private static IServiceProvider ServiceProvider { get; set; }

        private static IServiceCollection Services { get; set; }

        private static IHostingEnvironment HostingEnvironment { get; set; }

        //public static void AddDbContext<T>(string connectionString) where T : DbContext
        //{
        //    Services.AddDbContextPool<T>(options => options.UseSqlServer(connectionString));
        //    //T context = GetService<T>();
        //}

        public static void AddDbContext<T>(string connectionString) where T : DbContext
        {
            //https://rehansaeed.com/optimally-configuring-entity-framework-core/
            Services.AddDbContextPool<T>(
                options => options
                    .UseSqlServer(connectionString, x => x.EnableRetryOnFailure())
                    .ConfigureWarnings(x => x.Throw(RelationalEventId.QueryClientEvaluationWarning))
                    .EnableSensitiveDataLogging(HostingEnvironment.IsDevelopment()));
                    //.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
        }

        public static void AddDbContextInMemoryDatabase<T>() where T : DbContext
        {
            Services.AddDbContextPool<T>(options => options.UseInMemoryDatabase(typeof(T).Name));
        }

        public static T GetService<T>()
        {
            ServiceProvider = ServiceProvider ?? Services.BuildServiceProvider();

            return ServiceProvider.GetService<T>();
        }

        public static IServiceCollection RegisterServices(IServiceCollection services, IHostingEnvironment hostingEnvironment)
        {
            Services = services;
            HostingEnvironment = hostingEnvironment;

            // Solution.Application.Applications
            Services.AddScoped<IBlogService, BlogService>();
            Services.AddScoped<IPostService, PostService>();
            
            //// Solution.CrossCutting
            //Services.AddScoped<ILogger, Logger>();
            Services.AddScoped<IMapper, Mapper>();

            //// Solution.Domain.Domains
            services.AddScoped<IBlogLogic, BlogLogic>();
            services.AddScoped<IPostLogic, PostLogic>();

            services.AddScoped<IBlogValidator, BlogValidator>();
            services.AddScoped<IPostValidator, PostValidator>();

            //// Solution.Infrastructure.Database
            services.AddScoped<IUnitOfWork, GtrEntities>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IPostRepository, PostRepository>();

            return Services;
        }
    }
}