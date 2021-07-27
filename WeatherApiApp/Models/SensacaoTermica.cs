using System.Runtime.Serialization;

namespace WeatherApiApp.Models
{
    [DataContract]
    public class SensacaoTermica
    {
        public int ID { get; set; }
        public int PrevisaoOpenWId { get; set; }
        public PrevisaoDiariaOpenW PrevisaoOpenW { get; set; }

        [DataMember(Name = "day")]
        public float SensDiaria { get; set; }

        [DataMember(Name = "morn")]
        public float SensManha { get; set; }

        [DataMember(Name = "eve")]
        public float SensEntardecer { get; set; }

        [DataMember(Name = "night")]
        public float SensNoite { get; set; }
    }
}
