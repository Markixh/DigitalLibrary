using DigitalLibrary.DAL.Entities;

namespace DigitalLibrary.DAL.Repositories
{
    /// <summary>
    /// Репозиторий для работы с книгами
    /// </summary>
    public class BookRepository : BaseRepository
    {
        public BookRepository(Settings.AppContext appContext) : base(appContext) { }

        /// <summary>
        /// Получить книгу по ID
        /// </summary>
        /// <param name="id">Идентификатор книги</param>
        /// <returns>Книга</returns>
        public Book GetBookById(int id)
        {
            return appContext.Books.Where(i => i.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Возращает список всех книг
        /// </summary>
        /// <returns>Список книг</returns>
        public List<Book> GetAllBooks()
        {
            return appContext.Books.ToList();
        }

        /// <summary>
        /// Возращает список всех книг отсортированных по названию
        /// </summary>
        /// <returns>Список книг</returns>
        public List<Book> GetAllBooksSortTitle()
        {
            return GetAllBooks().OrderBy(o => o.Title).ToList();
        }

        /// <summary>
        /// Возращает список всех книг отсортированных по году выхода
        /// </summary>
        /// <returns>Список книг</returns>
        public List<Book> GetAllBooksSortYear()
        {
            return GetAllBooks().OrderByDescending(o => o.Year).ToList();
        }

        /// <summary>
        /// Удаляет книгу из БД
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public int DelBook(Book book)
        {
            appContext.Books.Remove(book);
            return appContext.SaveChanges();
        }

        /// <summary>
        /// Добавляет книгу в БД
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public int InsertBook(Book book)
        {
            appContext.Books.Add(book);
            return appContext.SaveChanges();
        }

        /// <summary>
        /// Меняет год выхода книги по ID книги
        /// </summary>
        /// <param name="id"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public int UpdateBookYearById(int id, int year)
        {
            var book = GetBookById(id);
            book.Year = year;
            appContext.Books.Update(book);
            return appContext.SaveChanges();
        }

        /// <summary>
        /// Выбирает список книги вышедших между определенными годами
        /// </summary>
        /// <param name="fromdate">от</param>
        /// <param name="before">до</param>
        /// <returns>Список книг</returns>
        public List<Book> GetBooksBetweenYear(int fromdate, int before)
        {
            return appContext.Books.Where(b => (b.Year > fromdate) && (b.Year > before)).ToList();
        }

        /// <summary>
        /// Получать список книг определенного жанра
        /// </summary>
        /// <param name="genre">Жанр книги</param>
        /// <returns>Список книг</returns>
        public List<Book> GetGenreBooks (Genre genre)
        {
            return appContext.Books.Where(b => b.Genre.GenreName == genre.GenreName).ToList();
        }

        /// <summary>
        /// Получает количество книг определенного автора в библиотеке
        /// </summary>
        /// <param name="author">Автор</param>
        /// <returns>Количество книг</returns>
        public int GetCountBooksByAuthor(string author)
        {
            return appContext.Books.Where(b => b.Author == author).Count();
        }

        /// <summary>
        /// Получает количество книг определенного жанра в библиотеке
        /// </summary>
        /// <param name="genre">Жанр</param>
        /// <returns>Количество книг</returns>
        public int GetCountBooksByGenre(Genre genre)
        {
            return GetGenreBooks(genre).Count();
        }

        /// <summary>
        /// Получает булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке
        /// </summary>
        /// <param name="author">Автор</param>
        /// <param name="genre">Жанр</param>
        /// <returns></returns>
        public bool IsBooksByGenreAndAuthor(string author, Genre genre)
        {
            var count = appContext.Books.Where(b => (b.Genre.GenreName == genre.GenreName) && (b.Author == author)).Count();
            return count > 0;
        }

        /// <summary>
        /// Получает булевый флаг о том, есть ли определенная книга на руках у пользователя
        /// </summary>
        /// <param name="book">Книга</param>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>
        public bool IsBookAtUser(Book book, User user)
        {
            if (book == null || book.UserId is null || user is null) return false;
            return book.UserId == user.Id;
        }

        /// <summary>
        /// Получает количество книг на руках у пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns>Список книг</returns>
        public List<Book> GetBooksAtUser(User user)
        {
            return appContext.Books.Where(b => b.UserId == user.Id).ToList();
        }

        /// <summary>
        /// Получает самую новую книгу
        /// </summary>
        /// <returns>Книга</returns>
        public Book GetNewBook()
        {
            return appContext.Books.OrderByDescending(o => o.Year).First();
        }
    }
}
