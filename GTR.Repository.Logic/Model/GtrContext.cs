using System;
using System.IO;
using GTR.Repository.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace GTR.Repository.Logic.Model
{
    public partial class GtrEntities : DbContext
    {
        public GtrEntities(DbContextOptions<GtrEntities> options)
            : base(options)
        {
        }

        public virtual DbSet<Blog> Blog { get; set; }
        public virtual DbSet<Post> Post { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>(entity =>
            {
                entity.Property(e => e.Url).IsRequired();
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.BlogId);
            });
        }
    }

    /// <summary>
    /// A factory to create an instance of the StudentsContext 
    /// </summary>
    //public static class GtrEntitiesFactory
    //{
    //    public static GtrEntities Create(string connectionString)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<GtrEntities>();
    //        optionsBuilder.UseSqlServer(connectionString);

    //        // Ensure that the SQLite database and sechema is created!
    //        GtrEntities context = new GtrEntities(optionsBuilder.Options);
    //        //context.Database.EnsureCreated();

    //        return context;
    //    }
    //}
}
