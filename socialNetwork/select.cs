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
            return Db.users.Find(u => true).ToList();
        }


        
        public Circle GetCircle(string name)
        {
            return Db.circles.Find(c => c.name.Equals(name)).First();
        }

        public List<Circle> GetAllCircles()
        {
            var circles = Db.circles.Find(c => true).ToList();
            Console.WriteLine("Cirkler lige nu:");
            foreach (var circle in circles)
            {
                Console.WriteLine("\t"+circle.name);
            }
            return circles;
        }

        public Post GetPostFromTitle(string title)
        {
            return Db.posts.Find(p => p.title.Equals(title)).First();
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

        public List<string> seeBlockedUsers(string userid)
        {
            var user = Db.users.Find(u => u.userid == userid).First();
            var blocked = user.blocked;
            Console.WriteLine("Blokeret fra "+userid+":");
            foreach (var block in blocked)
            {
                Console.WriteLine(block);
            }
            return user.blocked;
        }
        public List<Post> GetPostsFromWall(string userid,string guestid)
        {
            var user = GetUser(userid);
            var guest = GetUser(guestid);
            //var posts = Db.posts.Find(p => user.circles.Contains(p.circle) && ).ToList();
            var posts = Db.posts
                .Find(p => p.author.userid.Equals(guestid) &&
                           (p.circle.members.Contains(userid) || p.circle.name.Equals("Public")) &&
                           !p.author.blocked.Contains(userid)).SortByDescending(p => p.created).Limit(5).ToList();
            
            foreach (var post in posts)
            {
                Console.WriteLine(post.title);
                Console.WriteLine("Skrevet af: " + post.author.name);
                Console.WriteLine(post.description);
                Console.WriteLine("Video: "+post.url);
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

        public List<Post> GetPostFromPublicWall(string userid)
        {
            
            //var posts = Db.posts.Find(p => user.circles.Contains(p.circle) && ).ToList();
            var posts = Db.posts
                .Find(p => p.circle.name.Equals("Public") &&
                           !p.author.blocked.Contains(userid)).SortByDescending(p => p.created).ToList();

            foreach (var post in posts)
            {
                Console.WriteLine(post.title);
                Console.WriteLine("Skrevet af: " + post.author.name);
                Console.WriteLine(post.description);
                Console.WriteLine("Video: " + post.url);
                Console.WriteLine("--------");
                if (post.comments != null)
                {
                    Console.WriteLine("Kommentarer:");
                    foreach (var comment in post.comments)
                    {
                        Console.WriteLine("\t" + comment.content);
                        Console.WriteLine("\tSkrevet af: " + comment.user);
                        Console.WriteLine("--------");
                    }
                }
            }

            return posts;
        }

        public List<Post> GetPostsFromFeed(string userid)
        {
            var user = GetUser(userid);
            //var posts = Db.posts.Find(p => user.circles.Contains(p.circle) && ).ToList();
            var posts = Db.posts
                .Find(p => p.author.userid == userid &&
                           (p.circle.members.Contains(userid) || p.circle.Equals("Public")) &&
                           p.author.blocked.Contains(userid)).SortByDescending(p => p.created).Limit(5).ToList();

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
