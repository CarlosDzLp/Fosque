using System;
using Newtonsoft.Json;

namespace Fosque.Models
{
    public class DetailTurnosModel
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

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("habilita")]
        public string Habilita { get; set; }

        [JsonProperty("informacion")]
        public string Informacion { get; set; }

        [JsonProperty("cupo")]
        public string Cupo { get; set; }

        [JsonProperty("cupo_prospecto")]
        public string CupoProspecto { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("photo")]
        public string Photo { get; set; }

        [JsonProperty("reservaActivos")]
        public string ReservaActivos { get; set; }

        [JsonProperty("reservaProspectos")]
        public string ReservaProspectos { get; set; }

    }
}
