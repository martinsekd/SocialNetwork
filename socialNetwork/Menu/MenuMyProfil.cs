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
                        Console.WriteLine("(3):tilbage til main");
                        Console.WriteLine("---------------------------------");
                        
                        MenuValg = Console.ReadLine();

                        Console.Clear();
                        break;

                    case "1":
                        // Vis min egen væg
                        Db.@select.GetPostsFromAuthor(UserId);
                        Console.WriteLine("Tryk enter for at forsætte");
                        Console.ReadLine();
                        MenuValg = "mainMenu";
                        break;

                    case "2":
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
                            
                            //Circle circle = new Circle();
                            //Post post = new Post();
                            //post.id = ObjectId.GenerateNewId((int)DateTime.Now.ToFileTime()).ToString();
                            //post.description = postContent;
                            //post.title = postTitle;
                            //post.url = postUrl;
                            //post.created = DateTime.Now;
                            //post.circle = circle;
                            //post.comments = new System.Collections.Generic.List<Comment>();

                            // lav en post
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
                        Db.select.GetBlockedUsers(UserId);
                        Console.WriteLine("------------");
                        Db.@select.GetAllUsers();
                        Console.WriteLine("------------");
                        Console.WriteLine("Skriv en bruger at blokere");
                        var blockUser = Console.ReadLine();
                        var userIns = Db.@select.GetUser(UserId);
                        var blockUserIns = Db.@select.GetUser(blockUser);
                        Db.insert.addBlockedUser(userIns,blockUserIns);
                        MenuValg = "mainMenu";
                        break;
                    case "5":
                        Db.select.GetBlockedUsers(UserId);
                        Console.ReadLine();
                        MenuValg = "mainMenu";
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
