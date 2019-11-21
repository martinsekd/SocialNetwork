using System;
using System.Collections.Generic;
using System.Text;

namespace socialNetwork.Menu
{
    class MenuUserWall
    {
        public string MenuValg = "mainMenu";

        public bool Runner = true;

        public MenuUserWall()
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
                    case "mainMenu": 
                        Console.Clear();
                        Console.WriteLine("Velkommen til Social Network.");
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("Menu: User wall");
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("(1): Vis seneste post");
                        Console.WriteLine("(2): Skriv kommentar på post");
                        Console.WriteLine("(4): Tilbage til main");
                        Console.WriteLine("---------------------------------");

                        string MenuValg = Console.ReadLine();

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

                        // Skriv kommentar på post
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
