using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeatherApiApp.Models
{
    public class ReqOpenUV
    {
        public int ID { get; set; }

        [DataType(DataType.Date)]
        public System.DateTime HorarioRequisicao { get; set; }

        public ICollection<PrevisaoOpenUV> PrevisoesOpenUV { get; set; }

    }
}
