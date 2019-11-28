using System;
using System.Collections.Generic;
using System.Text;

namespace socialNetwork.Menu
{
    class MenuFriends
    {
        public string MenuValg;

        public bool Runner;

        private string UserId;

        public MenuFriends(string userId)
        {
            UserId = UserId;
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
                        Console.WriteLine("Menu: Friends");
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("(1): Vis list af venner");
                        Console.WriteLine("(2): Gå til vens væg");
                        Console.WriteLine("(3): Tilbage til main");
                        Console.WriteLine("---------------------------------");

                        string MenuValg = Console.ReadLine();

                        Console.Clear();
                        break;

                    case "1":
                        // Vis list af alle her
                        break;

                    case "2":
                        MenuFriendsWall menuFriendsWall = new MenuFriendsWall(UserId);
                        menuFriendsWall.StartMenu();
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
