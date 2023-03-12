using DigitalLibrary.DAL.Entities;

namespace DigitalLibrary.DAL.Repositories
{
    /// <summary>
    /// Репозиторий работы с пользователями
    /// </summary>
    public class UserRepository : BaseRepository
    {
        public UserRepository(Settings.AppContext appcontext) : base(appcontext) { }

        /// <summary>
        /// Полуить пользователя по ID
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Пользователь</returns>
        public User GetUserById(int id)
        {
            return appContext.Users.Where(i => i.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Выбрать всех пользователей
        /// </summary>
        /// <returns>Список пользователей</returns>
        public List<User> GetAllUsers()
        {
            return appContext.Users.ToList();
        }

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int DelUser(User user)
        {
            appContext.Users.Remove(user);
            return appContext.SaveChanges();
        }

        /// <summary>
        /// Добавление пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>
        public int InsertUser(User user)
        {
            appContext.Users.Add(user);
            return appContext.SaveChanges();
        }

        /// <summary>
        /// Обновить информацию о имяни пользователя по ID
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="name">Имя</param>
        /// <returns></returns>
        public int UpdateUserNameById(int id, string name)
        {
            var user = GetUserById(id);
            user.Name = name;
            appContext.Users.Update(user);
            return appContext.SaveChanges();
        }

        /// <summary>
        /// Закрепить книгу за пользователем
        /// </summary>
        /// <param name="user"></param>
        /// <param name="book"></param>
        /// <returns></returns>
        public int AddBookToUser(User user, Book book)
        {
            book.User = user;
            appContext.Books.Update(book);
            return appContext.SaveChanges();
        }
    }
}
