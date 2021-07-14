using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherApiApp.Models
{
    public class ReqOpenW
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int MunicipioId { get; set; }

        [DataType(DataType.Date)]
        public System.DateTime HorarioRequisicao { get; set; }

    }
}
