using ComputersFactory.Data.MongoDbWriter.Models.Components;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ComputersFactory.Data.MongoDbWriter.Models
{
    public class ComputerMongoModel
    {
        private ICollection<int> hardDrivesIds;

        public ComputerMongoModel()
        {
            this.hardDrivesIds = new HashSet<int>();
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

        [BsonRepresentation(BsonType.Int32)]
        public int MemoryId
        {
            get; set;
        }

        public virtual MemoryMongoModel Memory
        {
            get; set;
        }

        [BsonRepresentation(BsonType.Int32)]
        public int MotherboardId
        {
            get; set;
        }

        public virtual MotherboardMongoModel Motherboard
        {
            get; set;
        }

        [BsonRepresentation(BsonType.Int32)]
        public int ProcesorId
        {
            get; set;
        }

        public virtual ProcessorMongoModel Processor
        {
            get; set;
        }

        [BsonRepresentation(BsonType.Int32)]
        public int VideocardId
        {
            get; set;
        }

        public virtual VideoCardMongoModel Videocard
        {
            get; set;
        }

        public virtual ICollection<int> HardDrivesIds
        {
            get
            {
                return this.hardDrivesIds;
            }
            set
            {
                this.hardDrivesIds = value;
            }
        }

        [BsonRepresentation(BsonType.Int32)]
        public int ComputerShopId
        {
            get; set;
        }

        public virtual ComputerShopMongoModel ComputerShop
        {
            get; set;
        }
    }
}