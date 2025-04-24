using Microsoft.EntityFrameworkCore;
using SportRent.Application.WorkSpaces.InventoryItem.Query;
using SportRent.Application.WorkSpaces.Order;
using SportRent.Application.WorkSpaces.User;
using System.IO;

namespace SportRent.Database
{
    public class DatabaseContext : DbContext
    {
        private static DatabaseContext? _instance;
        public static DatabaseContext Instance
        {
            get
            {
                if (_instance is null)
                    _instance = new DatabaseContext();

                return _instance;
            }
        }

        public DbSet<InventoryItemEntity> InventoryItems { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        //dotnet ef migrations add InitialCreate --context DatabaseContext
        //dotnet ef database update --context DatabaseContext
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databasePath = Path.Combine(Directory.GetCurrentDirectory(), "sportrent.db");
            optionsBuilder.UseSqlite($"Data Source=D:\\VisualProjects\\SportRent\\sportrent.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
