using System;
using System.Collections.Generic;
using System.Text;

namespace socialNetwork.Menu
{
    class MenuFriendsWall
    {
        public string MenuValg;

        public bool Runner;

        public string UserId;

        public MenuFriendsWall(string userId)
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
                    case "mainMenu": // Main Menu
                        Console.Clear();
                        Console.WriteLine("Velkommen til Social Network.");
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("Menu: Friends");
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("Menu: Friends Wall");
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("(1): Vis Væg");
                        Console.WriteLine("(2): Skriv kommentar på post");
                        Console.WriteLine("(3): Tilbage til Friends menu");
                        Console.WriteLine("---------------------------------");

                        MenuValg = Console.ReadLine();

                        Console.Clear();
                        break;

                    case "1":
                        // Vis vennes væg

                        Console.WriteLine("Tryk enter for at forsætte");
                        Console.ReadLine();
                        MenuValg = "mainMenu";
                        break;

                    case "2":
                        Console.Write("Skriv id på Post: ");
                        string idContent = Console.ReadLine();
                        Console.Write("Skriv kommentar til Post: ");
                        string postComment = Console.ReadLine();

                        try
                        {
                            User user = Db.select.GetUser(UserId);
                            //Post post = Db.select.GetPostsFromAuthor()
                            //Db.insert.createComment(postComment, user, )
                            // skriv kommentar på post
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Fejled I at skrive til database");
                            Console.WriteLine("Tryk enter for at forsætte");
                            Console.ReadLine();
                        }
                        MenuValg = "mainMenu";
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
