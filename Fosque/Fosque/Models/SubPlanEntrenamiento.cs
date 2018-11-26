using System;
using Newtonsoft.Json;
using SQLite;
using Xamarin.Forms;
namespace Fosque.Models
{
    public class SubPlanEntrenamiento
    {
        [JsonProperty("Id")]
        [PrimaryKey]
        public string ID { get; set; }

        [JsonProperty("Plan")]
        public string Plan { get; set; }

        [JsonProperty("Tipo")]
        public string Tipo { get; set; }

        [JsonProperty("Imagen")]
        public string Imagen { get; set; }

        [SQLite.Ignore, JsonIgnore]
        public ImageSource ImageConvert { get; set; }

        [SQLite.Ignore, JsonIgnore]
        public bool IsVisibleImage { get; set; }

        [SQLite.Ignore, JsonIgnore]
        public bool IsVisibleText { get; set; }
    }
}
