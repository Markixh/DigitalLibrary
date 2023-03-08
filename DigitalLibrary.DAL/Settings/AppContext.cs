using DigitalLibrary.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary.DAL.Settings
{
    public class AppContext : DbContext
    {
        // Объекты таблицы Users
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        public AppContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP\\SQLEXPRESS;Database=BookLibrary;User Id=user;Password=user;TrustServerCertificate=true");
        }
    }
}
