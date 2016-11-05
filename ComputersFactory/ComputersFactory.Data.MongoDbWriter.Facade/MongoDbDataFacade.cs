using ComputersFactory.Data.TransferToSql;

namespace ComputersFactory.Data.MongoDbWriter.Facade
{
    public class MongoDbDataFacade : IMongoDbDataFacade
    {
        public void GenerateMongoDbData()
        {
            MongoDbWriter.GenerateData();
        }

        public void TransferDataFromMongoDbToSqlServer()
        {
            MongoToSqlMigrator.TransferData();
        }
    }
}
