using DigitalLibrary.DAL.Entities;

namespace DigitalLibrary.DAL.Repositories
{
    public class BookRepository
    {
        public Book GetBookById(int id)
        {
            using (var db = new Settings.AppContext())
            {
                return db.Books.Where(i => i.Id == id).FirstOrDefault();
            }
        }

        public List<Book> GetAllBooks(int id)
        {
            using (var db = new Settings.AppContext())
            {
                return db.Books.ToList();
            }
        }

        public int DelBook(Book book)
        {
            using (var db = new Settings.AppContext())
            {
                db.Books.Remove(book);
                return db.SaveChanges();
            }
        }

        public int InsertBook(Book book)
        {
            using (var db = new Settings.AppContext())
            {
                db.Books.Add(book);
                return db.SaveChanges();
            }
        }

        public int UpdateBookYearById(int id, string year)
        {
            using (var db = new Settings.AppContext())
            {
                var book = GetBookById(id);
                book.Year = year;
                return db.SaveChanges();
            }
        }
    }
}
