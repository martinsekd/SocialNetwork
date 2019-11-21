using MongoDB.Driver;
using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;

namespace socialNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            IMongoCollection<User> users;
            IMongoCollection<Post> posts;
            var client = new MongoClient("mongodb://127.0.0.1:27017");
            var database = client.GetDatabase("SocialNetwork");

            users = database.GetCollection<User>("User");
            posts = database.GetCollection<Post>("Post");

            //var user = new User();
            //user.age = 20;
            //user.gender = "Mand";
            //user.name = "Kim Hansen";

            //users.InsertOne(user);

            var post = new Post();
            post.id = ObjectId.GenerateNewId((int) DateTime.Now.ToFileTime()).ToString();
            post.description = "Her er en beskrivelse";
            post.title = "Titlen";
            post.url = "www.google.dk";


            //var user2 = Builders<User>.Filter.Eq("name", "Kim Hansen");
            //var user3 = users.
            //var update = Builders<User>.Update.Push("post", post);

            //users.UpdateOne(user2, update);
            
            //Builders<User>.Update.Push()
            //users.UpdateOne("{name : 'Kim Hansen'}", "{$push: {po}");
            //
            //users.UpdateOne({name:'Kim Hansen'},)



            //users.UpdateOne("{'name': 'Hans Pilgård'}", "" +
            //"{$push:" +
            //                                            "{post: 'Her er en post'})");

            //var post = new Post();
            //post.title = "Første post";
            //post.description = "Her er en post";
            //post.url = "www.google.dk";
            //post.authorId = user.id;


            //posts.InsertOne(post);

            Console.WriteLine("Hello World!");
        }
    }
}
