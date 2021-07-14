using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherApiApp.Models
{
    public class PrevisaoOpenUV
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int ReqOpenUVId { get; set; }
        public float IndiceUV { get; set; }

        [DataType(DataType.Date)]
        public System.DateTime Horario { get; set; }

    }
}