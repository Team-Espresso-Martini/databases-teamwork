using ComputersFactory.Data.MongoDbWriter.Models.Components;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ComputersFactory.Data.MongoDbWriter.Models
{
    public class ComputerMongoModel
    {
        private ICollection<HardDriveMongoModel> hardDrives;

        public ComputerMongoModel()
        {
            this.hardDrives = new HashSet<HardDriveMongoModel>();
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

        public virtual MemoryMongoModel Memory
        {
            get; set;
        }

        public virtual MotherboardMongoModel Motherboard
        {
            get; set;
        }

        public virtual ProcessorMongoModel Processor
        {
            get; set;
        }

        public virtual VideoCardMongoModel Videocard
        {
            get; set;
        }

        public virtual ComputerShopMongoModel ComputerShop
        {
            get; set;
        }

        public virtual ICollection<HardDriveMongoModel> HardDrives
        {
            get
            {
                return this.hardDrives;
            }
            set
            {
                this.hardDrives = value;
            }
        }
    }
}