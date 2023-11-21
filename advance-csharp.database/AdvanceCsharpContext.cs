using advance_csharp.database.Models;
using Microsoft.EntityFrameworkCore;

namespace advance_csharp.database
{
    public class AdvanceCsharpContext : DbContext
    {
        public DbSet<AppVersion>? AppVersions { get; set; }
        public DbSet<Product>? Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer("Server=sql.bsite.net\\MSSQL2016;Database=appuser1001_advance_csharp;User Id=appuser1001_advance_csharp;Password=abcd123456;Trusted_Connection=False;");
        }
    }
}