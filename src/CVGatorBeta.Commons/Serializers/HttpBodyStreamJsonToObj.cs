using Newtonsoft.Json;

namespace CVGatorBeta.Commons.Serializers
{
    public static class HttpBodyStreamJsonToObj<T>
    {
        public async static Task<T> ReadBody(Stream bodyStream)
        {
            string result = "";
            using (var streamReader = new StreamReader(bodyStream))
            {
                result = await streamReader.ReadToEndAsync();
            }

            return JsonConvert.DeserializeObject<T>(result, GetJsonSerializerSettings()) ?? throw new JsonSerializationException($"Null Deserialized Object: {typeof(T)}");
        }

        private static JsonSerializerSettings GetJsonSerializerSettings()
        {
            return new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                
            };
        }
    }
}
