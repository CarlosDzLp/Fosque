using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Xamarin.Forms;
using SQLite;
namespace Fosque.Models
{
    public class PlanEntrenamiento
    {
        [JsonProperty("id")]
        [PrimaryKey]
        public string ID { get; set; }

        [JsonProperty("fechaplan")]
        public string FechaPlan { get; set; }

        [JsonProperty("plan")]
        public string Plan { get; set; }

        [JsonProperty("vigenciadesde")]
        public string VigenciaDesde { get; set; }

        [JsonProperty("vigenciahasta")]
        public string VigenciaHasta { get; set; }

        [JsonProperty("personal")]
        public string Personal { get; set; }

        [JsonProperty("foto")]
        public string Foto { get; set; }

        [JsonProperty("objetivo")]
        public string Objetivo { get; set; }

        [JsonProperty("objetivo_semanal")]
        public string ObjetivoRemanal { get; set; }

        [JsonProperty("objetivo_semanal_result")]
        public string ObjetivoSemanalResult { get; set; }

        [JsonProperty("objetivo_plan")]
        public string ObjetivoPlan { get; set; }

        [JsonProperty("objetivo_plan_result")]
        public string ObjetivoPlanResult { get; set; }

        [JsonProperty("observaciones")]
        public string Observaciones { get; set; }


        [SQLite.Ignore]
        public ImageSource ImageBase { get; set; }
    }
}
