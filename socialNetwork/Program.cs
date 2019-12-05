using System;
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

            Console.WriteLine("\t       -----");
            Console.WriteLine("\t    ---      ---");
            Console.WriteLine("\t ---            ---");
            Console.WriteLine("\t|       I4DAB      |");
            Console.WriteLine("\t|        GRP2      |");
            Console.WriteLine("\t ---            ---");
            Console.WriteLine("\t    ---      ---");
            Console.WriteLine("\t       -----");
        }
    }
}
