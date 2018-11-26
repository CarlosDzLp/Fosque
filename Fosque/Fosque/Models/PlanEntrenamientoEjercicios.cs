using System;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Fosque.Models
{
    public class PlanEntrenamientoEjercicios
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("plan")]
        public string Plan { get; set; }

        [JsonProperty("etapa")]
        public string Etapa { get; set; }

        [JsonProperty("ejercicio")]
        public string Ejercicio { get; set; }

        [JsonProperty("photo")]
        public string Photo { get; set; }

        [JsonProperty("video")]
        public string Video { get; set; }

        [JsonProperty("peso")]
        public string Peso { get; set; }

        [JsonProperty("series")]
        public string Series { get; set; }

        [JsonProperty("repeticiones")]
        public string Repeticiones { get; set; }

        [JsonProperty("pausa")]
        public string Pausa { get; set; }

        [JsonProperty("tiempo")]
        public string Tiempo { get; set; }

        [JsonProperty("comentario")]
        public string Comentario { get; set; }

        [SQLite.Ignore, JsonIgnore]
        public ImageSource ImageConvert { get; set; }


        [SQLite.Ignore, JsonIgnore]
        public int Alto { get; set; }

        [SQLite.Ignore, JsonIgnore]
        public int Ancho { get; set; }
    }
}
