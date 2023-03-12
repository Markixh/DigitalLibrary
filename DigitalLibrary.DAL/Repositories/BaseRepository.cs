namespace DigitalLibrary.DAL.Repositories
{
    /// <summary>
    /// Базовый репозиторий
    /// </summary>
    public class BaseRepository
    {
        public Settings.AppContext appContext;

        public BaseRepository(Settings.AppContext appcontext)
        {
            appContext = appcontext;
        }
    }
}
