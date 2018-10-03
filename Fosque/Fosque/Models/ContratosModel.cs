using System;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Fosque.Models
{
    public class ContratosModel
    {
        [JsonProperty("success")]
        public string Success { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("categoria")]
        public string Categoria { get; set; }

        [JsonProperty("nrosocio")]
        public string Nrosocio { get; set; }

        [JsonProperty("actividad")]
        public string Actividad { get; set; }

        [JsonProperty("vigenciad")]
        public string Vigenciad { get; set; }

        [JsonProperty("vigenciah")]
        public string Vigenciah { get; set; }

        [JsonProperty("total_clases")]
        public string TotalClases { get; set; }

        [JsonProperty("asistencias")]
        public string Asistencias { get; set; }

        [JsonProperty("ultima_clase")]
        public string UltimaClase { get; set; }

        [JsonProperty("photo")]
        public string Photo { get; set; }

        [JsonProperty("contrato")]
        public string Contrato { get; set; } 
        [JsonIgnore]
        public string VigenciaContrato { get; set; }

        [JsonIgnore]
        public ImageSource PhotoConvert { get; set; }
        
    }
}
