using DigitalLibrary.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary.DAL.Settings
{
    /// <summary>
    /// Контекст данных
    /// </summary>
    public class AppContext : DbContext
    {
        // Объекты таблиц
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        public AppContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP\\SQLEXPRESS;Database=BookLibrary;User Id=user;Password=user;TrustServerCertificate=true");
        }
    }
}
