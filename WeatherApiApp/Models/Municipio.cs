using System.Collections.Generic;

namespace WeatherApiApp.Models
{
    public class Municipio
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public float Altitude { get; set; }
        public string FusoIana { get; set; }
        public string FusoWin { get; set; }

        public ICollection<PrevisaoOpenUV> PrevisoesOpenUV { get; set; }
        public ICollection<PrevisaoDiariaOpenW> PrevisoesDiariasOpenW { get; set; }
        public ICollection<PrevisaoHoraOpenW> ClimasAtuaisOpenW { get; set; }
        public ICollection<WeatherBit> WeatherBits { get; set; }
    }
}
