namespace ComputersFactory.Data.Services.Contracts
{
    public interface IDatabaseService
    {
        void SaveDataToDatabase<ModelType>(IEnumerable<ModelType> data);
    }
}
