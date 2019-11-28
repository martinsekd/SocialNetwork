using System;
using System.Collections.Generic;
using System.Text;

namespace socialNetwork.Menu
{
    class MainMenu
    {
        public string MenuValg;

        public bool Runner;

        public MainMenu()
        {
            MenuValg = "mainMenu";
            Runner = true;
        }

        public void StartMenu()
        { 
            while (Runner)
            {
                switch (MenuValg)
                {
                    case "mainMenu": // Main Menu
                        Console.Clear();
                        Console.WriteLine("Velkommen til Social Network.");
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("(1): Min profil");
                        Console.WriteLine("(2): Venner");
                        Console.WriteLine("(3): Users wall");
                        Console.WriteLine("(4): Registrer ny bruger");
                        Console.WriteLine("(5): Exit program");
                        Console.WriteLine("---------------------------------");

                        string MenuValg = Console.ReadLine();

                        Console.Clear();
                        break;

                    case "1":
                        Console.WriteLine("Skriv min brugers id");
                        string userId = Console.ReadLine();

                        //Se user eksistere... ellers break;

                        MenuMyProfil menuMyProfil = new MenuMyProfil(userId);
                        menuMyProfil.StartMenu();
                        break;

                    case "2":
                        MenuFriends menuFriends = new MenuFriends();
                        menuFriends.StartMenu();
                        break;

                    case "3":
                        MenuUserWall menuUserWall = new MenuUserWall();
                        menuUserWall.StartMenu();
                        break;

                    case "4":
                        Console.Write("Skriv ny brugers navn: ");
                        string userName = Console.ReadLine();

                        try
                        {
                            // Indsæt ny bruger
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Fejled I at skrive til database");
                            Console.WriteLine("Tryk enter for at forsætte");
                            Console.ReadLine();
                        }
                        break;

                    case "5":
                        Runner = false;
                        break;

                    default:
                        Console.WriteLine("Forkert indtastning");
                        MenuValg = "mainMenu";
                        Console.WriteLine("Tryk enter for at forsætte");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
