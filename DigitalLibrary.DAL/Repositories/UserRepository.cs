using DigitalLibrary.DAL.Entities;

namespace DigitalLibrary.DAL.Repositories
{
    public class UserRepository
    {  
        public User GetUserById(int id)
        {
            using (var db = new Settings.AppContext())
            {
                return db.Users.Where(i => i.Id == id).FirstOrDefault();
            }
        }

        public List<User> GetAllUsers(int id)
        {
            using (var db = new Settings.AppContext())
            {
                return db.Users.ToList();
            }
        }

        public int DelUser(User user)
        {
            using (var db = new Settings.AppContext())
            {
                db.Users.Remove(user);
                return db.SaveChanges();
            }
        }

        public int InsertUser(User user)
        {
            using (var db = new Settings.AppContext())
            {
                db.Users.Add(user);
                return db.SaveChanges();
            }
        }

        public int UpdateUserNameById(int id, string name)
        {
            using (var db = new Settings.AppContext())
            {
                var user = GetUserById(id);
                user.Name = name;
                return db.SaveChanges();
            }
        }
    }
}
