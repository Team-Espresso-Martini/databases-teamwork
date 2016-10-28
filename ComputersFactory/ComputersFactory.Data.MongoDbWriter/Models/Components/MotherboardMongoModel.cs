using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ComputersFactory.Data.MongoDbWriter.Models.Components
{
    public class MotherboardMongoModel
    {
        private ICollection<ComputerMongoModel> computers;

        public MotherboardMongoModel()
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

        public string Model
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
