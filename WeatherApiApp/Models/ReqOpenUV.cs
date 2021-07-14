﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherApiApp.Models
{
    public class ReqOpenUV
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int MunicipioId { get; set; }

        [DataType(DataType.Date)]
        public System.DateTime HorarioRequisicao { get; set; }

        public ICollection<PrevisaoOpenUV> PrevisoesOpenUV { get; set; }

    }
}
