using DigitalLibrary.DAL.Entities;
using DigitalLibrary.DAL.Repositories;

namespace DigitalLibrary.Console
{
    internal class Program
    {
        static void Main()
        {
            using (var db = new DAL.Settings.AppContext()) // Создаем подключение к БД
            {
                // Подключаем репозитории
                UserRepository userRepository = new UserRepository(db);
                BookRepository bookRepository = new BookRepository(db);

                // Добавляем в БД жанры и книги
                var genre1 = new Genre { GenreName = "Роман" };
                var genre2 = new Genre { GenreName = "Детективная фантастика" };

                var book1 = new Book { Title = "Мастер и Маргарита", Year = 1966, Author = "Михаил Булгаков", Genre = genre1 };
                var book2 = new Book { Title = "Происхождение", Year = 2022, Author = "Дэн Браун", Genre = genre2 };

                bookRepository.InsertBook(book1);
                bookRepository.InsertBook(book2);

                // Добавляем пользователей
                var user1 = new User { Name = "Андрей" };
                var user2 = new User { Name = "Елена" };

                userRepository.InsertUser(user1);
                userRepository.InsertUser(user2);

                // Закрепляем книги за пользователем
                userRepository.AddBookToUser(user1 , book1);
                userRepository.AddBookToUser(user2 , book2);
            }
        }
    }
}