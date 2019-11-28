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
                        Console.WriteLine("Skriv min brugers id");
                        string userId = Console.ReadLine();

                        //Se user eksistere... ellers break;

                        MenuFriends menuFriends = new MenuFriends(userId);
                        menuFriends.StartMenu();
                        break;

                    case "3":
                        Console.WriteLine("Skriv min brugers id");
                        string userId = Console.ReadLine();

                        //Se user eksistere... ellers break;

                        MenuPublicWall menuPublicWall = new MenuPublicWall(userId);
                        menuPublicWall.StartMenu();
                        break;

                    case "4":
                        Console.WriteLine("Skriv min brugers id");
                        string userId = Console.ReadLine();

                        //Se user eksistere... ellers break;

                        MenuUserWall menuUserWall = new MenuUserWall(userId);
                        menuUserWall.StartMenu();
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
    }
}
