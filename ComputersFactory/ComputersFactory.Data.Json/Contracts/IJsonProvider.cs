namespace ComputersFactory.Data.Json.Contracts
{
    public interface IJsonProvider
    {
        string SerializeObject(object toSerialize);

        ModelType DeserializeToModel<ModelType>(string json);
    }
}
