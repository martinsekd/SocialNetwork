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
            var database = client.GetDatabase("SocialNetwork3");
            ///***************//////
            users = database.GetCollection<User>("User");
            posts = database.GetCollection<Post>("Post");
            circles = database.GetCollection<Circle>("Circle");

            
            
        }


        
    }
}