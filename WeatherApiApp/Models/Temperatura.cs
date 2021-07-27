using System.Runtime.Serialization;

namespace WeatherApiApp.Models
{
    [DataContract]
    public class Temperatura
    {
        public int ID { get; set; }
        public int PrevisaoOpenWId { get; set; }
        public PrevisaoDiariaOpenW PrevisaoOpenW { get; set; }

        [DataMember(Name = "day")]
        public float TempDiaria { get; set; }

        [DataMember(Name = "morn")]
        public float TempManha { get; set; }

        [DataMember(Name = "eve")]
        public float TempEntardecer { get; set; }

        [DataMember(Name = "night")]
        public float TempNoite { get; set; }

        [DataMember(Name = "min")]
        public float TempMin { get; set; }

        [DataMember(Name = "max")]
        public float TempMax { get; set; }
    }
}
