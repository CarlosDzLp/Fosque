using System;
using Newtonsoft.Json;

namespace Fosque.Models
{
    public class ReservaTurnosModel
    {
        [JsonProperty("idcliente")]
        public string Idcliente { get; set; }

        [JsonProperty("idptovta")]
        public string Idptovta { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("conceptoid")]
        public string ConceptoId { get; set; }

        [JsonProperty("descripcion_concepto")]
        public string DescripcionConcepto { get; set; }

        [JsonProperty("sala")]
        public string Sala { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("inicio")]
        public string Inicio { get; set; }

        [JsonProperty("palette_number")]
        public string PaletteNumber { get; set; }

        [JsonProperty("habilita")]
        public string Habilita { get; set; }

    }
}
