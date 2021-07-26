using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WeatherApiApp.Models
{
    [DataContract]
    public class PrevisaoOpenUV
    {
        public int ID { get; set; }

        [DataMember(Name = "uv")]
        public float IndiceUV { get; set; }

        [DataMember(Name = "uv_time")]
        [DataType(DataType.Date)]
        public System.DateTime Horario { get; set; }

        public Municipio Municipio { get; set; }

    }
}