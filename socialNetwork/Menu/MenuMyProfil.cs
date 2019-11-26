using System;
using System.Collections.Generic;
using System.Text;

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
                        Console.Write("Skriv Post: ");
                        string postContent = Console.ReadLine();

                        try
                        {
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
