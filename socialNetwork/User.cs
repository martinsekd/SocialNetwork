using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace socialNetwork
{
    class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        public string userid { get; set; }

        public string name { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public List<Post> posts { get; set; }
        public List<Circle> circles { get; set; }
        public List<String> blocked { get; set; }
    }
}
