namespace DigitalLibrary.DAL.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Author { get; set; }

        public int GenreId { get; set; }
        public int? UserId { get; set; }

        public Genre Genre { get; set; }
        public User User { get; set; }
    }
}
