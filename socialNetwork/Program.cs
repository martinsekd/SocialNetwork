using MongoDB.Driver;
using System;
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

            var user = new User();
            user.age = 20;
            user.gender = "Mand";
            user.name = "Kim Hansen";

            users.InsertOne(user);

            //var user2 = Builders<BsonDocument>.Filter.Eq("name": "Kim Hansen");

            //Builders<User>.Update.Push()
            users.UpdateOne("{name : 'Kim Hansen'}", "{$push: {posts: 'hej2'}}");
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
