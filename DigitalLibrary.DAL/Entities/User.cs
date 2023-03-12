namespace DigitalLibrary.DAL.Entities
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }    // Имя пользователя
        public string? Email { get; set; }  // EMAIL

        // Список книг в пользовании
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
