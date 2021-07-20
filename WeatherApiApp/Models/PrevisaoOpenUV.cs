using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace WeatherApiApp.Models
{
    [DataContract]
    public class PrevisaoOpenUV
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int ReqOpenUVId { get; set; }

        [DataMember(Name = "uv")]
        public float IndiceUV { get; set; }

        [DataMember(Name = "uv_time")]
        [DataType(DataType.Date)]
        public System.DateTime Horario { get; set; }

    }
}