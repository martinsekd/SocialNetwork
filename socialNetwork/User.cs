using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace socialNetwork
{
    class User
    {
        public User()
        {
            circles = new List<Circle>();
            blocked = new List<string>();
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        public string userid { get; set; }

        public string name { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public List<Circle> circles { get; set; }
        public List<String> blocked { get; set; }
    }
}
