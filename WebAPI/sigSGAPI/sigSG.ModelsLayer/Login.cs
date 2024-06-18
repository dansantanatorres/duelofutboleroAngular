using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace sigSG.ModelsLayer
{
    public class Login
    {
        [JsonPropertyName("user")]
        public string Usuario { get; set; }

        [JsonPropertyName("password")]
        public string Clave { get; set; }
    }
}
