namespace ComputersFactory.Data.Json.Contracts
{
    public interface IJsonService
    {
        string ConvertModelToJson<ModelType>(ModelType model);
    }
}
