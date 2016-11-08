namespace ComputersFactory.Data.MongoDbWriter.Facade
{
    public interface IMongoDbDataFacade
    {
        void GenerateMongoDbData();

        void TransferDataFromMongoDbToSqlServer();
    }
}