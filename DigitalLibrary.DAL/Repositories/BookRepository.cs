using DigitalLibrary.DAL.Entities;

namespace DigitalLibrary.DAL.Repositories
{
    public class BookRepository : BaseRepository
    {
        public BookRepository(Settings.AppContext appContext) : base(appContext) { }

        public Book GetBookById(int id)
        {
            return appContext.Books.Where(i => i.Id == id).FirstOrDefault();
        }

        public List<Book> GetAllBooks()
        {
            return appContext.Books.ToList();
        }

        public List<Book> GetAllBooksSortTitle()
        {
            return GetAllBooks().OrderBy(o => o.Title).ToList();
        }

        public List<Book> GetAllBooksSortYear()
        {
            return GetAllBooks().OrderByDescending(o => o.Year).ToList();
        }

        public int DelBook(Book book)
        {
            appContext.Books.Remove(book);
            return appContext.SaveChanges();
        }

        public int InsertBook(Book book)
        {
            appContext.Books.Add(book);
            return appContext.SaveChanges();
        }

        public int UpdateBookYearById(int id, int year)
        {
            var book = GetBookById(id);
            book.Year = year;
            return appContext.SaveChanges();
        }

        public List<Book> GetBooksBetweenYear(int fromdate, int before)
        {
            return appContext.Books.Where(b => (b.Year > fromdate) && (b.Year > before)).ToList();
        }

        public List<Book> GetGenreBooks (Genre genre)
        {
            return appContext.Books.Where(b => b.Genre.GenreName == genre.GenreName).ToList();
        }

        public int GetCountBooksByAuthor(string author)
        {
            return appContext.Books.Where(b => b.Author == author).Count();
        }

        public int GetCountBooksByGenre(Genre genre)
        {
            return GetGenreBooks(genre).Count();
        }

        public bool IsBooksByGenreAndAuthor(string author, Genre genre)
        {
            var count = appContext.Books.Where(b => (b.Genre.GenreName == genre.GenreName) && (b.Author == author)).Count();
            return count > 0;
        }

        public bool IsBookAtUser(Book book, User user)
        {
            if (book == null || book.UserId is null || user is null) return false;
            return book.UserId == user.Id;
        }

        public List<Book> GetBooksAtUser(User user)
        {
            return appContext.Books.Where(b => b.UserId == user.Id).ToList();
        }

        public Book GetYoungestBook()
        {
            return appContext.Books.OrderByDescending(o => o.Year).First();
        }
    }
}
