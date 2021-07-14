using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherApiApp.Models
{
    public class Municipio
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Nome { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public float Altitude { get; set; }

        [Timestamp]
        public byte[] UltimaModificacao { get; set; }

        public ICollection<ReqOpenUV> RequisicoesOpenUV { get; set; }
        public ICollection<ReqOpenW> RequisicoesOpenW { get; set; }
    }
}
