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
            Db.circles.InsertOne(cir);
            return cir;
        }

        public User createUser(string userid,string name,int age,string gender)
        {
            var user = new User();
            user.name = name;
            user.age = age;
            user.gender = gender;
            user.userid = userid;
            Db.users.InsertOne(user);
            var cir = Db.@select.GetCircle("Public");
            Db.insert.addUserToCircle(user,cir);
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
            Db.posts.InsertOne(post);
            return post;
        }

        public Comment createComment(string content, string user,Post post)
        {
            var comment = new Comment();
            comment.content = content;
            comment.user = user;

            var filter = Builders<Post>.Filter.Eq("id", post.id);
            var update = Builders<Post>.Update.Push(p => p.comments, comment);
            Db.posts.UpdateOneAsync(filter, update);
            return comment;
        }

        public void addUserToCircle(User user, Circle circle)
        {
            var filter = Builders<Circle>.Filter.Eq("id", circle.id);
            var update = Builders<Circle>.Update.Push(c => c.members, user.userid);
            Db.circles.FindOneAndUpdate(filter, update);

            var userFilter = Builders<User>.Filter.Eq("id", user.id);
            var userUpdate = Builders<User>.Update.Push(u => u.circles, circle);
            Db.users.FindOneAndUpdate(userFilter, userUpdate);

        }

        public void addBlockedUser(User user, User blockedUser)
        {
            var filter = Builders<User>.Filter.Eq("userid", user.userid);
            var update = Builders<User>.Update.Push(u => u.blocked, user.userid);
            Db.users.FindOneAndUpdate(filter, update);
        }
    }
}
