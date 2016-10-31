using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ComputersFactory.Data.MongoDbWriter.Models
{
    public class ComputerShopMongoModel
    {
        private ICollection<ComputerMongoModel> computers;

        public ComputerShopMongoModel()
        {
            this.computers = new HashSet<ComputerMongoModel>();
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

        public virtual ICollection<ComputerMongoModel> Computers
        {
            get
            {
                return this.computers;
            }
            set
            {
                this.computers = value;
            }
        }
    }
}
