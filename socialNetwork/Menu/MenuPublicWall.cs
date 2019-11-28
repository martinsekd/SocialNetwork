using System;
using System.Collections.Generic;
using System.Text;

namespace socialNetwork.Menu
{
    class MenuPublicWall
    {
        public string MenuValg = "mainMenu";

        public bool Runner = true;

        private string UserId;

        public MenuPublicWall(string userId)
        {
            UserId = userId;
            MenuValg = "mainMenu";
            Runner = true;
        }

        public void StartMenu()
        {
            while (Runner)
            {
                switch (MenuValg)
                {
                    case "mainMenu": 
                        Console.Clear();
                        Console.WriteLine("Velkommen til Social Network.");
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("Menu: Public wall");
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("(1): Vis seneste post");
                        Console.WriteLine("(2): Skriv kommentar på post");
                        Console.WriteLine("(4): Tilbage til main");
                        Console.WriteLine("---------------------------------");

                        MenuValg = Console.ReadLine();

                        Console.Clear();
                        break;

                    case "1":
                        //Vis seneste post 

                        Console.WriteLine("Tryk enter for at forsætte");
                        Console.ReadLine();
                        break;

                    case "2":
                        Console.Write("Skriv id på Post: ");
                        string idContent = Console.ReadLine();
                        Console.Write("Skriv kommentar til Post: ");
                        string postComment = Console.ReadLine();

                        try
                        {
                            // Skriv kommentar på post
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Fejled I at skrive til database");
                            Console.WriteLine("Tryk enter for at forsætte");
                            Console.ReadLine();
                        }
                        break;

                    case "3":
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
