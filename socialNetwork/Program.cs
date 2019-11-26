using MongoDB.Driver;
using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using socialNetwork.Db;

namespace socialNetwork
{
    class Program
    {



            static void Main(string[] args)
            {
                Db.Db.Init();
                //IMongoCollection<User> users;
                //IMongoCollection<Post> posts;
                


                //var post = new Post();
                //post.id = ObjectId.GenerateNewId((int)DateTime.Now.ToFileTime()).ToString();
                //post.description = "Her er en beskrivelse";
                //post.title = "Title 3";
                //post.url = "www.google.dk";
                //post.comments = new System.Collections.Generic.List<string>();

                //var user = new User();
                //user.age = 20;
                //user.gender = "Mand";
                //user.name = "Carl Børge Hansen";
                //user.posts = new System.Collections.Generic.List<Post>();
                //user.posts.Add(post);

                //users.InsertOne(user);

                //var post = new Post();
                //post.id = ObjectId.GenerateNewId((int)DateTime.Now.ToFileTime()).ToString();
                //post.description = "Her er en beskrivelse";
                //post.title = "Title 2";
                //post.url = "www.google.dk";

                //var user2 = Builders<User>.Filter.Eq("name","Carl Børge Hansen");
                //var user2 = Builders<User>.Filter.Eq("name", new BsonDocument { { "name", "Kim Hansen" } });
                //var update = Builders<User>.Update.Push("posts", post);
                //var post2 = Builders<Post>.Filter.Eq("title", "Titlen");
                //var user3 = users.
                //var update = Builders<User>.Update.Push("post", post);
                //var update = Builders<User>.Update.Push("post[0].$.comments", "kommentar1");
                //var update = Builders<User>.Update.Push(x => x.posts[0].comments,"kommentar2");
                //var res=  users.UpdateOneAsync(user2, update);
                //Thread.Sleep(5000);
                //User updatedUser = new User() { "name", "Kim Hansen" };
                //users.FindOneAndUpdate(user2, update);
                //var update = Update<Student>.
                //Set(s => s.AVG, "500").
                //Set(s => s.FirstName, "New Name");


                //Builders<User>.Update.Push()
                //users.UpdateOne("{name : 'Kim Hansen'}", "{$push: {po}");

                //users.UpdateOne({ name: 'Kim Hansen'},)



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
                Console.ReadLine();
            }

        }

    }
