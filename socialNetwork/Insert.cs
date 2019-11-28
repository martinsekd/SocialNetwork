using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace socialNetwork
{
    class Insert
    {
        public Insert()
        {
            
        }
        public Circle createCircle(string name)
        {
            var cir = new Circle();
            cir.name = name;
            Db.Db.circles.InsertOne(cir);
            return cir;
        }

        public User createUser(string userid,string name,int age,string gender)
        {
            var user = new User();
            user.name = name;
            user.age = age;
            user.gender = gender;
            user.userid = userid;
            Db.Db.users.InsertOne(user);
            return user;
        }

        public Post createPost(string title, string description, string url, User author,Circle circle)
        {
            var post = new Post();
            post.author = author;
            post.created = DateTime.Now;
            post.title = title;
            post.description = description;
            post.url = url;
            post.circle = circle;
            Db.Db.posts.InsertOne(post);
            return post;
        }

        public Comment createComment(string content, string user,Post post)
        {
            var comment = new Comment();
            comment.content = content;
            comment.user = user;

            var filter = Builders<Post>.Filter.Eq("id", post.id);
            var update = Builders<Post>.Update.Push(p => p.comments, comment);
            Db.Db.posts.UpdateOneAsync(filter, update);
            return comment;
        }

        public void addUserToCircle(User user, Circle circle)
        {
            var filter = Builders<Circle>.Filter.Eq("id", circle.id);
            var update = Builders<Circle>.Update.Push(c => c.members, user.userid);
            Db.Db.circles.FindOneAndUpdate(filter, update);

        }
    }
}
