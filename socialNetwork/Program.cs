using socialNetwork.Menu;

namespace socialNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            Db.Init();

            DbDummyData dbDummyData = new DbDummyData();

            MainMenu mainMenu = new MainMenu();
            mainMenu.StartMenu();
        }
    }
}
