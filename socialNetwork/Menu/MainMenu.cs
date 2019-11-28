using System;
using System.Collections.Generic;
using System.Text;

namespace socialNetwork.Menu
{
    class MainMenu
    {
        public string MenuValg;
        private Insert insert;
        private Select selects;
        public bool Runner;

        private string userId;

        public MainMenu()
        {
            MenuValg = "mainMenu";
            Runner = true;
            insert = new Insert();
            selects = new Select();
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
                        Console.WriteLine("(4): Public wall");
                        Console.WriteLine("(5): Registrer ny bruger");
                        Console.WriteLine("(6): Exit program");
                        Console.WriteLine("---------------------------------");

                        MenuValg = Console.ReadLine();

                        Console.Clear();
                        break;

                    case "1":
                        LogOn();
                        MenuMyProfil menuMyProfil = new MenuMyProfil(userId);
                        menuMyProfil.StartMenu();
                        MenuValg = "mainMenu";
                        break;

                    case "2":
                        LogOn();
                        MenuFriends menuFriends = new MenuFriends(userId);
                        menuFriends.StartMenu();
                        MenuValg = "mainMenu";
                        break;

                    case "3":
                        LogOn();
                        MenuPublicWall menuPublicWall = new MenuPublicWall(userId);
                        menuPublicWall.StartMenu();
                        MenuValg = "mainMenu";
                        break;

                    case "4":
                        LogOn();
                        MenuUserWall menuUserWall = new MenuUserWall(userId);
                        menuUserWall.StartMenu();
                        MenuValg = "mainMenu";
                        break;


                    case "5":
                        Console.Write("Skriv ny brugers fulde navn: ");
                        string Name = Console.ReadLine();
                        Console.Write("Skriv ny brugers brugernavn: ");
                        string userName = Console.ReadLine();
                        Console.WriteLine("Skriv brugers alder");
                        int age = int.Parse(Console.ReadLine());
                        Console.WriteLine("Skriv køn (M/K):");
                        string kon = Console.ReadLine();
                        try
                        {
                            // Indsæt ny bruger
                            insert.createUser(userName, Name, age, kon);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Fejled I at skrive til database");
                            Console.WriteLine("Tryk enter for at forsætte");
                            Console.ReadLine();
                        }
                        MenuValg = "mainMenu";
                        break;

                    case "6":
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

        public void LogOn()
        {
            Console.WriteLine("Skriv min brugers id");
            userId = Console.ReadLine();

            //Se user eksistere... ellers break;
        }
    }
}
