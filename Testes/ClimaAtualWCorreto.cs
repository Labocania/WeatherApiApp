using System.Collections.Generic;
using WeatherApiApp.Models;
namespace Testes
{
    static class ClimaAtualWCorreto
    {
        public static readonly string dailyW = @"
        {
            ""lat"": -22.9129,
            ""lon"": -43.2003,
            ""timezone"": ""America/Sao_Paulo"",
            ""timezone_offset"": -10800,
            ""current"": {
                ""dt"": 1630451590,
                ""sunrise"": 1630400650,
                ""sunset"": 1630442544,
                ""temp"": 19.96,
                ""feels_like"": 20.47,
                ""pressure"": 1023,
                ""humidity"": 94,
                ""dew_point"": 18.97,
                ""uvi"": 0,
                ""clouds"": 75,
                ""visibility"": 10000,
                ""wind_speed"": 6.69,
                ""wind_deg"": 130,
                ""weather"": [
                    {
                        ""id"": 803,
                        ""main"": ""Clouds"",
                        ""description"": ""nublado"",
                        ""icon"": ""04n""
                    }
                ],
                ""rain"": {
                  ""1h"": 0.21
                }
            }
        }";

        public static readonly ClimaAtualOpenW previsao = new()
        {
            SensacaoTermica = 20.47f,
            Pressao = 1023f,
            Humidade = 94f,
            PontoOrvalho = 18.97f,
            IndiceUV = 0f,
            CoberturaNuvem = 75f,
            Visibilidade = 10000f,
            DataPrevisao = new System.DateTime(2021, 08, 31, 20, 13, 10),
            DataAmanhecer = new System.DateTime(2021, 08, 31, 06, 04, 10),
            DataEntardecer = new System.DateTime(2021, 08, 31, 17, 42, 24),
            Chuva = new Chuva()
            {
                ChuvaUltimaHora = 0.21f
            }, 
            Condicoes = new List<Condicao>()
            {
               new Condicao()
               {
                   Principal = "Clouds",
                   Detalhes = "nublado",
                   Icone = "04n"
               }
            }
        };
    }
}
