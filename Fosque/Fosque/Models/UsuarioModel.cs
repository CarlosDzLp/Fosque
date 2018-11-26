using System;
using Newtonsoft.Json;
using Xamarin.Forms;
using SQLite;

namespace Fosque.Models
{
    public class UsuarioModel
    {
        [JsonProperty("status_code")]
        public string StatusCode { get; set; }

        [JsonProperty("id")]
        [PrimaryKey]
        public string IdUser{ get; set; }

        [JsonProperty("dni")]
        public string DNI { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("categoria")]
        public string Categoria { get; set; }

        [JsonProperty("sede")]
        public string Sede { get; set; }

        [JsonProperty("mensaje")]
        public string Mensaje { get; set; }

        [JsonProperty("perfil")]
        public string Perfil { get; set; }

        [JsonProperty("client")]
        public string Client { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("nombreApp")]
        public string NombreApp { get; set; }

        [JsonIgnore,SQLite.Ignore]
        public ImageSource ImageConvert { get; set; }

        [JsonIgnore]
        public bool IsRemember { get; set; }
    }
}
