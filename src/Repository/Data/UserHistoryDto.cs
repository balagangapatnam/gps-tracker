using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Repository.Data
{
    public class UserHistoryDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("userid")]
        public int UserId { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("location-history")]
        public IList<Location> LocationHistory { get; set; }
    }
}