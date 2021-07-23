using System.ComponentModel.DataAnnotations;

namespace WeatherApiApp.Models
{
    public class ReqOpenW
    {
        public int ID { get; set; }

        [DataType(DataType.Date)]
        public System.DateTime HorarioRequisicao { get; set; }

        //public ICollection<PrevisaoOpenW> PrevisoesOpenW { get; set; }
    }
}
