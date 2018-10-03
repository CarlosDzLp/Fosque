using System;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Fosque.Models
{
    public class PerfilModel
    {
        [JsonProperty("success")]
        public string Success { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("categoria")]
        public string Categoria { get; set; }

        [JsonProperty("nrosocio")]
        public string Nrosocio { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("caract_telefono")]
        public string CaractTelefono { get; set; }

        [JsonProperty("telefono")]
        public string Telefono { get; set; }

        [JsonProperty("caract_celular")]
        public string CaractCelular { get; set; }

        [JsonProperty("celular")]
        public string Celular { get; set; }

        [JsonProperty("fechanac")]
        public string Fechanacimiento { get; set; }

        [JsonProperty("domicilio")]
        public string Domicilio { get; set; }

        [JsonProperty("numeracion")]
        public string Numeracion { get; set; }

        [JsonProperty("photo")]
        public string Photo { get; set; }

        [JsonIgnore]
        public ImageSource PhotoConvert { get; set; }
    }
}
