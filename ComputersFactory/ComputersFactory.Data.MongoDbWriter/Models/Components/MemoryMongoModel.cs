using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ComputersFactory.Data.MongoDbWriter.Models.Components
{
    public class MemoryMongoModel
    {
        private ICollection<ComputerMongoModel> computers;

        public MemoryMongoModel()
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

        [BsonRepresentation(BsonType.Int32)]
        public int CapacityInGb
        {
            get; set;
        }

        [BsonRepresentation(BsonType.Double)]
        public decimal Price
        {
            get; set;
        }

        public string Manufacturer
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
