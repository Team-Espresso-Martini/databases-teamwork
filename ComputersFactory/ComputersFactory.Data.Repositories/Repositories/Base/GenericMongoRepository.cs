using ComputersFactory.Data.Repositories.Repositories.Contracts;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace ComputersFactory.Data.Repositories.Repositories.Base
{
    public class GenericMongoRepository<TEntity>
          : IMongoRepository<TEntity> where TEntity : class
    {
        private string collectionName;
        private IMongoDatabase database;
        private const int NumberOfCharactersToTrim = 10;

        public GenericMongoRepository(IMongoDatabase database)
        {
            this.database = database;
            this.collectionName = typeof(TEntity).Name;
            this.collectionName = collectionName.Substring(0, collectionName.Length - 10);

            if (this.collectionName == "Memory")
            {
                this.collectionName = "Memories";
            }

            else
            {
                this.collectionName += "s";
            }
        }

        public void Add(TEntity value)
        {
            var collection = database.GetCollection<BsonDocument>(this.collectionName);
            var valueAsBson = value.ToBsonDocument();

            collection.InsertOne(valueAsBson);
        }

        public void AddMany(IEnumerable<TEntity> values)
        {
            var collection = database.GetCollection<BsonDocument>(this.collectionName);
            var valuesAsBson = values.Select(v => v.ToBsonDocument());

            collection.InsertMany(valuesAsBson);
        }

        public IEnumerable<TEntity> GetAll()
        {
            var collection = database.GetCollection<BsonDocument>(this.collectionName);
            var valuesAsBson = collection.Find(new BsonDocument()).ToList();
            var values = valuesAsBson.Select(v => BsonSerializer.Deserialize<TEntity>(v));

            return values.AsQueryable();
        }
    }
}
