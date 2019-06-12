using Newtonsoft.Json;

namespace NASAApi.Models
{
    public class RandomJokes
    {
        [JsonProperty("content")]
        public string Content { get; set; }
    }
}
