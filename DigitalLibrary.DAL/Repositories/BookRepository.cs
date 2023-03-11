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

        public List<Book> GetAllBooks(int id)
        {
            return appContext.Books.ToList();
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

        public int UpdateBookYearById(int id, string year)
        {
            var book = GetBookById(id);
            book.Year = year;
            return appContext.SaveChanges();
        }
    }
}
