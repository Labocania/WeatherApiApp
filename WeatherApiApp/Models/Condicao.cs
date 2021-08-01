using System.Runtime.Serialization;

namespace WeatherApiApp.Models
{
    [DataContract]
    public class Condicao
    {
        public int ID { get; set; }
        public PrevisaoDiariaOpenW PrevisaoOpenW { get; set; }
        public ClimaAtualOpenW ClimaAtualOpenW { get; set; }

        [DataMember(Name = "main")]
        public string Principal { get; set; }

        [DataMember(Name = "description")]
        public string Detalhes { get; set; }

        [DataMember(Name = "icon")]
        public string Icone { get; set; }
    }
}
