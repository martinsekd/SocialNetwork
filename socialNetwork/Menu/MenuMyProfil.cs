using System;
using System.Collections.Generic;
using System.Text;
us


namespace socialNetwork.Menu
{
    class MenuMyProfil
    {
        public string MenuValg = "mainMenu";

        public bool Runner = true;

        public MenuMyProfil()
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
                        Console.WriteLine("Menu: Min profil");
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("(1): Se min væg");
                        Console.WriteLine("(2): Lav en post");
                        Console.WriteLine("(3):tilbage til main");
                        Console.WriteLine("---------------------------------");

                        string MenuValg = Console.ReadLine();

                        Console.Clear();
                        break;

                    case "1":
                        // Vis min egen væg

                        Console.WriteLine("Tryk enter for at forsætte");
                        Console.ReadLine();
                        break;

                    case "2":
                        Console.Write("Skriv Post Title: ");
                        string postTitle = Console.ReadLine();
                        Console.Write("Skriv Post beskrivelse: ");
                        string postContent = Console.ReadLine();
                        Console.Write("Skriv Post URL: ");
                        string postUrl = Console.ReadLine();

                        try
                        {
                            Circle circle = new Circle();
                            Post post = new Post();
                            post.id = ObjectId.GenerateNewId((int)DateTime.Now.ToFileTime()).ToString();
                            post.description = postContent;
                            post.title = postTitle;
                            post.url = postUrl;
                            post.created = DateTime.Now;
                            post.circle = circle;
                            post.comments = new System.Collections.Generic.List<Comment>();
                            Program.users.
                            // lav en post
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
