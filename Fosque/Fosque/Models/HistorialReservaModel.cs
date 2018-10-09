using System;
using Newtonsoft.Json;

namespace Fosque.Models
{
    public class HistorialReservaModel
    {
        [JsonProperty("descripcion_concepto")]
        public string DescripcionConcepto { get; set; }

        [JsonProperty("fecha")]
        public string Fecha { get; set; }

        [JsonProperty("idreserva")]
        public string IdReserva { get; set; }

        [JsonProperty("estado")]
        public string Estado { get; set; }

    }
}
