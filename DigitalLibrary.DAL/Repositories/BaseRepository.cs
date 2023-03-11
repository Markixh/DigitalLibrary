namespace DigitalLibrary.DAL.Repositories
{
    public class BaseRepository
    {
        public Settings.AppContext appContext;

        public BaseRepository(Settings.AppContext appcontext)
        {
            appContext = appcontext;
        }
    }
}
