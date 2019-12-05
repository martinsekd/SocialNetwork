using System;

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
                        Console.WriteLine("--Velkommen til Social Network---");
                        Console.WriteLine("--------I4DAB - Gruppe 2---------");
                        Console.WriteLine("Menu: Public wall");
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("(1): Vis seneste post");
                        Console.WriteLine("(2): Skriv kommentar på post");
                        Console.WriteLine("(3): Tilbage til main");
                        Console.WriteLine("---------------------------------");

                        MenuValg = Console.ReadLine();

                        Console.Clear();
                        break;

                    case "1":
                        Console.Clear();
                        Db.@select.GetPostFromPublicWall(UserId);
                        Console.WriteLine("\n\nTryk enter for at forsætte");
                        Console.ReadLine();
                        MenuValg = "mainMenu";
                        break;

                    case "2":
                        Console.Clear();
                        Console.Write("Skriv titel på Post: ");
                        string titel = Console.ReadLine();
                        Console.Write("Skriv kommentar til Post: ");
                        string postComment = Console.ReadLine();

                        try
                        {
                            Post post = Db.@select.GetPostFromTitle(titel);
                            Db.insert.createComment(postComment, UserId, post);

                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Fejled I at skrive til database");
                            Console.WriteLine("\n\nTryk enter for at forsætte");
                            Console.ReadLine();
                        }
                        MenuValg = "mainMenu";
                        break;

                    case "3":
                        Runner = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Forkert indtastning");
                        MenuValg = "mainMenu";
                        Console.WriteLine("\n\nTryk enter for at forsætte");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
