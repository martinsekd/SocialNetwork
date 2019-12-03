using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace socialNetwork
{
    class Post
    {
        public Post()
        {
            comments = new List<Comment>();
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }

        public DateTime created { get; set; }
        public Circle circle { get; set; }
        public User author { get; set; }
        public List<Comment> comments { get; set; }
    }
}
