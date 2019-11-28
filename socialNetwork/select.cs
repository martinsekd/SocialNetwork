using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using MongoDB.Driver;

namespace socialNetwork
{
    class Select
    {
        public User GetUser(string userid)
        {
            return Db.users.Find(u => u.userid.Equals(userid)).First();
        }

        public List<User> GetAllUsers()
        {
            return Db.users.Find(u => u.id!=null).ToList();
        }

        public Circle GetCircle(string name)
        {
            return Db.circles.Find(c => c.name.Equals(name)).First();
        }

        public List<Post> GetPostsFromAuthor(string userid)
        {
            var posts = Db.posts.Find(p => p.author.userid.Equals(userid)).ToList();

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

        public List<Post> GetPostsFromCircle(Circle circle)
        {
            var posts = Db.posts.Find(p => p.circle.name.Equals(circle.name)).ToList();

            foreach (var post in posts)
            {
                Console.WriteLine(post.title);
                Console.WriteLine("Skrevet af: " + post.author.name);
                Console.WriteLine(post.description);
                Console.WriteLine("Video: " + post.url);
                Console.WriteLine("--------");
                Console.WriteLine("Kommentarer:");
                foreach (var comment in post.comments)
                {
                    Console.WriteLine("\t" + comment.content);
                    Console.WriteLine("\tSkrevet af: " + comment.user);
                    Console.WriteLine("--------");
                }
            }

            return posts;
        }

        public List<Post> GetPostsFromWall(string userid)
        {
            var user = GetUser(userid);
            
            var posts = Db.posts.Find(p => user.circles.Contains(p.circle)).ToList();

            foreach (var post in posts)
            {
                Console.WriteLine(post.title);
                Console.WriteLine("Skrevet af: " + post.author.name);
                Console.WriteLine(post.description);
                Console.WriteLine("Video: " + post.url);
                Console.WriteLine("--------");
                Console.WriteLine("Kommentarer:");
                foreach (var comment in post.comments)
                {
                    Console.WriteLine("\t" + comment.content);
                    Console.WriteLine("\tSkrevet af: " + comment.user);
                    Console.WriteLine("--------");
                }
            }

            return posts;
        }
    }
}
