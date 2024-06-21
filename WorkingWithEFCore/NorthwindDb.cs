using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Northwind.EntityModels;

namespace WorkingWithEFCore
{
    public class NorthwindDb : DbContext
    {
        // These two properties map to tables in the database.
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }

        protected override void OnConfiguring(
    DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder builder = new();

            builder.DataSource = "."; // "ServerName\InstanceName" e.g. @".\sqlexpress"
            builder.InitialCatalog = "Northwind";
            builder.Encrypt = true;
            builder.TrustServerCertificate = true;
            builder.MultipleActiveResultSets = true;
            builder.ConnectTimeout = 3; // Because we want to fail fast. Default is 15 seconds.

            // If using Windows Integrated authentication.
            builder.IntegratedSecurity = true;

            // If using SQL Server authentication.
            // builder.UserId = Environment.GetEnvironmentVariable("MY_SQL_USR");
            // builder.Password = Environment.GetEnvironmentVariable("MY_SQL_PWD");

            //string? connectionString = builder.ConnectionString;
            string? connectionString = "Data Source=.;Initial Catalog=Northwind;User Id=sa;Password=P@ssw0rd;Integrated Security=false;TrustServerCertificate=true;";
            WriteLine($"Connection: {connectionString}");
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.LogTo(WriteLine, // This is the Console method.
                                             new[] { RelationalEventId.CommandExecuting })
#if DEBUG
 .EnableSensitiveDataLogging()
 .EnableDetailedErrors()
#endif
;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            {
                // Example of using Fluent API instead of attributes
                // to limit the length of a category name to 15.
                modelBuilder.Entity<Category>()
                .Property(category => category.CategoryName)
                .IsRequired() // NOT NULL
                .HasMaxLength(15);

                // Some SQLite-specific configuration.
                if (Database.ProviderName?.Contains("Sqlite") ?? false)
                {
                    // To "fix" the lack of decimal support in SQLite.
                    modelBuilder.Entity<Product>()
                    .Property(product => product.Cost)
                    .HasConversion<double>();
                }
            }
            modelBuilder.Entity<Product>()
                .HasQueryFilter(p => !p.Discontinued);
        }
    }
}
