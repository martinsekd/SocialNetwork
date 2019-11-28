using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace socialNetwork
{
    class Select
    {
        public User GetUser(string userid)
        {
            return Db.Db.users.Find(u => u.userid.Equals(userid)).First();
        }

        public Circle GetCircle(string name)
        {
            return null;
        }

        public List<Post> GetPostsFromAuthor(string userid)
        {
            var posts = Db.Db.posts.Find(p => p.author.userid.Equals(userid)).ToList();

            foreach (var post in posts)
            {
                Console.WriteLine(post.title);
                Console.WriteLine("Skrevet af: "+post.author.name);
                Console.WriteLine(post.description);
                Console.WriteLine("Video: "+post.url);
                Console.WriteLine("--------");
                Console.WriteLine("Kommentarer:");
                foreach (var comment in post.comments)
                {
                    Console.WriteLine("\t"+comment.content);
                    Console.WriteLine("\tSkrevet af: "+comment.user);
                    Console.WriteLine("--------");
                }
            }

            return posts;
        }
    }
}
