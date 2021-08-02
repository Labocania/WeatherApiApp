using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WeatherApiApp.Models
{
    [DataContract]
    public class PrevisaoOpenUV
    {
        [JsonIgnore]
        public int ID { get; set; }
        [JsonIgnore]
        public Municipio Municipio { get; set; }

        [JsonPropertyName("uv")]
        public float IndiceUV { get; set; }

        [JsonPropertyName("uv_time")]
        [DataType(DataType.Date)]
        public System.DateTime Horario { get; set; }
    }
}