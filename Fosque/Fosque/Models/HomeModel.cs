using System;
using Newtonsoft.Json;
using Xamarin.Forms;
namespace Fosque.Models
{
    public class HomeModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("titulo")]
        public string Titulo { get; set; }

        [JsonProperty("imagen")]
        public string Imagen { get; set; }

        [JsonIgnore]
        public ImageSource ImagenConvert { get; set; }
    }
}
