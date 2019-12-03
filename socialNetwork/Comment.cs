using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace socialNetwork
{
    class Comment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string content { get; set; }
        public string user { get; set; }
    }
}
