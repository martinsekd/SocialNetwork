﻿using System;
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

        private string userId;

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
                        Console.WriteLine("(1): Registrer ny bruger");
                        Console.WriteLine("(2): Vis alle bruger");

                        if(string.IsNullOrEmpty(userId))
                        {
                            Console.WriteLine("(3): Log på");
                        }
                        else
                        {
                            Console.WriteLine("(4): Log af");
                            Console.WriteLine("(5): Min profil");
                            Console.WriteLine("(6): Tilføj til cirkel");
                            Console.WriteLine("(7): Tilføj ny cirkel");
                            Console.WriteLine("(8): Users wall");
                            Console.WriteLine("(9): Public wall");
                        }
                        
                        Console.WriteLine("(0): Exit program");
                        Console.WriteLine("---------------------------------");

                        MenuValg = Console.ReadLine();

                        Console.Clear();
                        break;

                    case "1":
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
                        MenuValg = "mainMenu";
                        break;

                    case "2":
                        List<User> user = Db.select.GetAllUsers();

                        Console.WriteLine("UserID" + "\t\t\t" + "Nave" + "\t\t\t" + "Alder" + "\t\t\t" + "Køn" + "\n");
                        for (int i = 0; i < user.Count; i++)
                        {
                            Console.WriteLine(user[i].userid.ToString() + "\t" + user[i].name.ToString() + "\t" + user[i].age.ToString() + "\t" + user[i].gender.ToString());
                        }

                        Console.WriteLine("Tryk enter for at forsætte");
                        Console.ReadLine();
                        MenuValg = "mainMenu";
                        break;

                    case "3":
                        LogOn();
                        MenuValg = "mainMenu";
                        break;

                    case "4":
                        LogOff();
                        MenuValg = "mainMenu";
                        break;

                    case "5":
                        MenuMyProfil menuMyProfil = new MenuMyProfil(userId);
                        menuMyProfil.StartMenu();
                        MenuValg = "mainMenu";
                        break;

                    case "6":
                        Console.WriteLine("----------");
                        Db.@select.GetAllCircles();
                        Console.WriteLine("Skriv cirkel navn");
                        string circleName = Console.ReadLine();
                        Db.insert.addUserToCircle(Db.@select.GetUser(userId),Db.@select.GetCircle(circleName));
                        Console.WriteLine("------------");
                        MenuValg = "mainMenu";
                        break;

                    case "7":
                        var circles = Db.@select.GetAllCircles();

                        Console.WriteLine();
                        Console.WriteLine("Skriv et nyt cirkelnavn:");
                        var cname = Console.ReadLine();
                        Db.insert.createCircle(cname);
                        MenuValg = "mainMenu";
                        break;

                    case "8":
                        Console.WriteLine("-----------");
                        var users = selects.GetAllUsers();
                        foreach (var luser in users)
                        {
                            Console.WriteLine(luser.userid);
                        }
                        Console.WriteLine("-------");
                        Console.WriteLine("Skriv brugerid for ønsket besøg");
                        string guestid = Console.ReadLine();
                        MenuUserWall menuUserWall = new MenuUserWall(userId,guestid);
                        menuUserWall.StartMenu();
                        MenuValg = "mainMenu";
                        
                        break;

                    case "9":
                        MenuPublicWall menuPublicWall = new MenuPublicWall(userId);
                        menuPublicWall.StartMenu();
                        MenuValg = "mainMenu";
                        break;


                    case "0":
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

        public void LogOn()
        {
            Console.WriteLine("Skriv min brugers id");
            userId = Console.ReadLine();

            //Se user eksistere... ellers break;
        }

        public void LogOff()
        {
            userId = "";
        }
    }
}
