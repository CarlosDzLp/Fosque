using System;
using Newtonsoft.Json;
namespace Fosque.Models
{
    public class ConfiguracionModel
    {
        [JsonProperty("client")]
        public string Client { get; set; }

        [JsonProperty("player")]
        public string Player { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("status_code")]
        public string StatusCode { get; set; }

    }
}
