using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ComputersFactory.Data.MongoDbWriter.Models
{
    public class ComputerShopMongoModel
    {
        public ComputerShopMongoModel()
        {
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }
    }
}
