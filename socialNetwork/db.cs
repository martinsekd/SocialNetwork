using MongoDB.Driver;
using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace socialNetwork
{
    static class Db
    {
        public static IMongoCollection<User> users;
        public static IMongoCollection<Post> posts;
        public static IMongoCollection<Circle> circles;

        public static Insert insert = new Insert();
        public static Select select = new Select(); 

        public static void Init()
        {
            ///***************/////
            /// Indsæt egen connectionstreng og egen tomme database.
            var client = new MongoClient("mongodb://127.0.0.1:27017");
            var database = client.GetDatabase("SocialNetwork4");
            ///***************//////
            users = database.GetCollection<User>("User");
            posts = database.GetCollection<Post>("Post");
            circles = database.GetCollection<Circle>("Circle");
        }


        public static void insertData2()
        {
            var pub = new Circle();
            pub.name = "Public";
            pub.members = new System.Collections.Generic.List<string>();

            var user = new User();
            user.name = "Henrik";
            user.age = 25;
            user.gender = "M";
            user.userid = "Henrik123";
            user.circles = new List<Circle>();
            user.circles.Add(pub);

            var post = new Post();
            post.circle = pub;
            post.created = DateTime.Now;
            post.title = "Titel";
            post.description = "Her er en beskrivelse";
            post.url = "www.google.dk";
            post.author = user;
            posts.InsertOne(post);
        }
        public static void feed(string userid)
        {
            var user2 = (users.Find(u => u.userid == userid)).ToList();
            foreach (var u in user2)
                Console.WriteLine(u.name);
        }

        public static void insertTestData()
        {
            var pub = new Circle();
            pub.name = "Public";
            pub.members = new System.Collections.Generic.List<string>();

            var circle1 = new Circle();
            circle1.name = "Our private circle";
            circle1.members = new System.Collections.Generic.List<string>();

            var post1 = new Post();
            post1.id = ObjectId.GenerateNewId((int)DateTime.Now.ToFileTime()).ToString();
            post1.description = "Her er en beskrivelse 1 ";
            post1.title = "Title 1";
            post1.url = "www.dr.dk";
            post1.created = DateTime.Now;
            post1.circle = circle1;
            post1.comments = new System.Collections.Generic.List<Comment>();

            var post2 = new Post();
            post2.id = ObjectId.GenerateNewId((int)DateTime.Now.ToFileTime()).ToString();
            post2.description = "Her er en beskrivelse 2";
            post2.title = "Title 2";
            post2.url = "www.tv2.dk";
            post2.created = DateTime.Now;
            post2.circle = pub;
            post2.comments = new System.Collections.Generic.List<Comment>();

            var post3 = new Post();
            post3.id = ObjectId.GenerateNewId((int)DateTime.Now.ToFileTime()).ToString();
            post3.description = "Her er en beskrivelse 3";
            post3.title = "Title 3";
            post3.url = "www.google.dk";
            post3.created = DateTime.Now;
            post3.circle = circle1;
            post3.comments = new System.Collections.Generic.List<Comment>();
        }
    }
}