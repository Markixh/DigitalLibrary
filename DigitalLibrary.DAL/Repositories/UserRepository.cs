using DigitalLibrary.DAL.Entities;

namespace DigitalLibrary.DAL.Repositories
{
    public class UserRepository : BaseRepository
    {
        public UserRepository(Settings.AppContext appcontext) : base(appcontext) { }

        public User GetUserById(int id)
        {
            return appContext.Users.Where(i => i.Id == id).FirstOrDefault();
        }

        public List<User> GetAllUsers(int id)
        {
            return appContext.Users.ToList();
        }

        public int DelUser(User user)
        {
            appContext.Users.Remove(user);
            return appContext.SaveChanges();
        }

        public int InsertUser(User user)
        {
            appContext.Users.Add(user);
            return appContext.SaveChanges();
        }

        public int UpdateUserNameById(int id, string name)
        {
            var user = GetUserById(id);
            user.Name = name;
            return appContext.SaveChanges();
        }

        public int AddBookToUser(User user, Book book)
        {
            user.Books.Add(book);
            return appContext.SaveChanges();
        }
    }
}
