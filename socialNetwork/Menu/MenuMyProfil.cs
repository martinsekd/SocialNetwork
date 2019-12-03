using System;
using System.Collections.Generic;
using System.Text;


namespace socialNetwork.Menu
{
    class MenuMyProfil
    {
        public string MenuValg = "mainMenu";
        
        public bool Runner = true;

        private string UserId;

        public MenuMyProfil(string userId)
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
                        Console.WriteLine("Velkommen til Social Network "+UserId+".");
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("Menu: Min profil");
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("(1): Se min væg");
                        Console.WriteLine("(2): Lav en post");
                        Console.WriteLine("(4): Bloker bruger");
                        Console.WriteLine("(5): Se blokerede brugere");
                        Console.WriteLine("(6): Se mit feed");
                        Console.WriteLine("(3): Tilbage til main");
                        Console.WriteLine("---------------------------------");
                        
                        MenuValg = Console.ReadLine();

                        Console.Clear();
                        break;

                    case "1":
                        Console.Clear();
                        Db.@select.GetPostsFromAuthor(UserId);
                        Console.WriteLine("Tryk enter for at forsætte");
                        Console.ReadLine();
                        MenuValg = "mainMenu";
                        break;

                    case "2":
                        Console.Clear();
                        Console.Write("Skriv Post Title: ");
                        string postTitle = Console.ReadLine();
                        Console.Write("Skriv Post beskrivelse: ");
                        string postContent = Console.ReadLine();
                        Console.Write("Skriv Post URL: ");
                        string postUrl = Console.ReadLine();
                        Db.@select.GetAllCircles();
                        Console.WriteLine("Skriv hvilken cirkel, den skal postes i");
                        string circleName = Console.ReadLine();

                        try
                        {
                            var user = Db.@select.GetUser(UserId);
                            var circle = Db.@select.GetCircle(circleName);
                            Db.insert.createPost(postTitle, postContent, postUrl, user, circle);
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
                        MenuValg = "mainMenu";
                        break;

                    case "4":
                        Console.Clear();
                        Db.select.GetBlockedUsers(UserId);
                        Console.WriteLine("------------");
                        Db.@select.GetAllUsers();
                        Console.WriteLine("------------");
                        Console.WriteLine("Skriv en bruger at blokere");
                        var blockUser = Console.ReadLine();
                        var userIns = Db.@select.GetUser(UserId);
                        var blockUserIns = Db.@select.GetUser(blockUser);
                        
                        try
                        {
                            Db.insert.addBlockedUser(userIns, blockUserIns);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Brugeren eksistere ikke");
                        }

                        Console.WriteLine("Tryk enter for at forsætte");
                        Console.ReadLine();

                        MenuValg = "mainMenu";
                        break;

                    case "5":
                        Console.Clear();
                        Db.select.GetBlockedUsers(UserId);
                        Console.ReadLine();
                        MenuValg = "mainMenu";
                        break;

                    case "6":
                        Console.Clear();
                        Db.select.GetPostsFromFeed(UserId);
                        Console.WriteLine("Tryk enter for at forsætte");
                        Console.ReadLine();
                        MenuValg = "mainMenu";
                        break;

                    default:
                        Console.Clear();
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
