using System;

using ComputersFactory.Data.Json.Contracts;

using Newtonsoft.Json;

namespace ComputersFactory.Data.Json.JsonProviders
{
    public class NewtonsoftJsonProvider : IJsonProvider
    {
        public ModelType DeserializeToModel<ModelType>(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                throw new ArgumentNullException(nameof(json));
            }

            var model = JsonConvert.DeserializeObject<ModelType>(json);
            return model;
        }

        public string SerializeObject(object toSerialize)
        {
            if (toSerialize == null)
            {
                throw new ArgumentNullException(nameof(toSerialize));
            }

            var json = JsonConvert.SerializeObject(toSerialize, Formatting.Indented);
            return json;
        }
    }
}
