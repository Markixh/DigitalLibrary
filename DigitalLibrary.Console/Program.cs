using DigitalLibrary.Library;

namespace DigitalLibrary.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new Library.AppContext())
            {
                var user1 = new User { Name = "Андрей"};
                var user2 = new User { Name = "Елена"};

                db.Users.Add(user1);
                db.Users.Add(user2);

                var book1 = new Book { Title = "Мастер и Маргарита", Year = "1966" };
                var book2 = new Book { Title = "Происхождение", Year = "2022" };

                db.Books.Add(book1);
                db.Books.Add(book2);

                db.SaveChanges();
            }
        }
    }
}