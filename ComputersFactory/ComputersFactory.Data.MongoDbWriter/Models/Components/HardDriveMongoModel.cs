﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ComputersFactory.Data.MongoDbWriter.Models.Components
{
    public class HardDriveMongoModel
    {
        public HardDriveMongoModel()
        {
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
        public int CapacityInGb
        {
            get; set;
        }

        public string Manufacturer
        {
            get; set;
        }
    }
}
