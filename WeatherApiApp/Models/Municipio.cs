using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeatherApiApp.Models
{
    public class Municipio
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public float Altitude { get; set; }

        [Timestamp]
        public byte[] UltimaModificacao { get; set; }

        public ICollection<PrevisaoOpenUV> PrevisoesOpenUV { get; set; }
        //public ICollection<PrevisaoOpenW> PrevisoesOpenW { get; set; }
    }
}
