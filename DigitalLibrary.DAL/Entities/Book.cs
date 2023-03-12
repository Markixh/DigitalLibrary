namespace DigitalLibrary.DAL.Entities
{
    /// <summary>
    /// Книга
    /// </summary>
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }   // Название книги
        public int Year { get; set; }       // Год выхода
        public string Author { get; set; }  // Автор
        
        // Внешние ключи
        public int GenreId { get; set; }
        public int? UserId { get; set; }

        // Навигационные свойства
        public Genre Genre { get; set; }
        public User User { get; set; }
    }
}
