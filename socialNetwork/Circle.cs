using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace socialNetwork
{
    class Circle
    {
        public Circle()
        {
            members = new List<string>();
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string name { get; set; }
        public List<string> members { get; set; }
    }
}
