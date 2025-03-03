using MedRepairTrack.Core.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace MedRepairTrack.Core.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public static readonly DatabaseContext Instance = new DatabaseContext();
        public DbSet<EquipmentEntity> Equipments { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RequestEntity> Requests { get; set; }
        public DbSet<AccountEntity> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Base;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
