using System.Collections.Generic;
using WeatherApiApp.Models;
namespace Testes
{
    static class PrevisaoHoraWStub
    {
        public static readonly string json = @"{
    ""lat"": -22.9129,
    ""lon"": -43.2003,
    ""timezone"": ""America/Sao_Paulo"",
    ""timezone_offset"": -10800,
    ""hourly"": [
        {
        ""dt"": 1630519200,
            ""temp"": 24.18,
            ""feels_like"": 24.38,
            ""pressure"": 1020,
            ""humidity"": 66,
            ""dew_point"": 17.43,
            ""uvi"": 2.64,
            ""clouds"": 64,
            ""visibility"": 10000,
            ""wind_speed"": 5.73,
            ""wind_deg"": 108,
            ""wind_gust"": 7.09,
            ""weather"": [
                {
            ""id"": 803,
                    ""main"": ""Clouds"",
                    ""description"": ""nublado"",
                    ""icon"": ""04d""
                }
            ],
            ""pop"": 0.28
        },
        {
        ""dt"": 1630522800,
            ""temp"": 24.43,
            ""feels_like"": 24.63,
            ""pressure"": 1020,
            ""humidity"": 65,
            ""dew_point"": 17.43,
            ""uvi"": 0.99,
            ""clouds"": 75,
            ""visibility"": 10000,
            ""wind_speed"": 5.33,
            ""wind_deg"": 102,
            ""wind_gust"": 7.22,
            ""weather"": [
                {
            ""id"": 803,
                    ""main"": ""Clouds"",
                    ""description"": ""nublado"",
                    ""icon"": ""04d""
                }
            ],
            ""pop"": 0.21
        },
        {
        ""dt"": 1630526400,
            ""temp"": 23.93,
            ""feels_like"": 24.15,
            ""pressure"": 1020,
            ""humidity"": 68,
            ""dew_point"": 17.67,
            ""uvi"": 0.2,
            ""clouds"": 64,
            ""visibility"": 10000,
            ""wind_speed"": 4.88,
            ""wind_deg"": 100,
            ""wind_gust"": 7.52,
            ""weather"": [
                {
            ""id"": 803,
                    ""main"": ""Clouds"",
                    ""description"": ""nublado"",
                    ""icon"": ""04d""
                }
            ],
            ""pop"": 0.05
        },
        {
        ""dt"": 1630530000,
            ""temp"": 23.09,
            ""feels_like"": 23.33,
            ""pressure"": 1020,
            ""humidity"": 72,
            ""dew_point"": 17.77,
            ""uvi"": 0,
            ""clouds"": 51,
            ""visibility"": 10000,
            ""wind_speed"": 4.43,
            ""wind_deg"": 99,
            ""wind_gust"": 7.46,
            ""weather"": [
                {
            ""id"": 803,
                    ""main"": ""Clouds"",
                    ""description"": ""nublado"",
                    ""icon"": ""04n""
                }
            ],
            ""pop"": 0.04
        },
        {
        ""dt"": 1630533600,
            ""temp"": 22.2,
            ""feels_like"": 22.49,
            ""pressure"": 1021,
            ""humidity"": 77,
            ""dew_point"": 17.98,
            ""uvi"": 0,
            ""clouds"": 38,
            ""visibility"": 10000,
            ""wind_speed"": 3.81,
            ""wind_deg"": 94,
            ""wind_gust"": 6.45,
            ""weather"": [
                {
            ""id"": 802,
                    ""main"": ""Clouds"",
                    ""description"": ""nuvens dispersas"",
                    ""icon"": ""03n""
                }
            ],
            ""pop"": 0.04
        },
        {
        ""dt"": 1630537200,
            ""temp"": 21.2,
            ""feels_like"": 21.52,
            ""pressure"": 1022,
            ""humidity"": 82,
            ""dew_point"": 18.01,
            ""uvi"": 0,
            ""clouds"": 26,
            ""visibility"": 10000,
            ""wind_speed"": 3.32,
            ""wind_deg"": 89,
            ""wind_gust"": 5.53,
            ""weather"": [
                {
            ""id"": 802,
                    ""main"": ""Clouds"",
                    ""description"": ""nuvens dispersas"",
                    ""icon"": ""03n""
                }
            ],
            ""pop"": 0.04
        },
        {
        ""dt"": 1630540800,
            ""temp"": 20.14,
            ""feels_like"": 20.48,
            ""pressure"": 1022,
            ""humidity"": 87,
            ""dew_point"": 17.75,
            ""uvi"": 0,
            ""clouds"": 13,
            ""visibility"": 10000,
            ""wind_speed"": 3.17,
            ""wind_deg"": 80,
            ""wind_gust"": 5.23,
            ""weather"": [
                {
            ""id"": 801,
                    ""main"": ""Clouds"",
                    ""description"": ""algumas nuvens"",
                    ""icon"": ""02n""
                }
            ],
            ""pop"": 0.03
        },
        {
        ""dt"": 1630544400,
            ""temp"": 19.91,
            ""feels_like"": 20.25,
            ""pressure"": 1022,
            ""humidity"": 88,
            ""dew_point"": 17.68,
            ""uvi"": 0,
            ""clouds"": 4,
            ""visibility"": 10000,
            ""wind_speed"": 2.92,
            ""wind_deg"": 72,
            ""wind_gust"": 4.72,
            ""weather"": [
                {
            ""id"": 800,
                    ""main"": ""Clear"",
                    ""description"": ""céu limpo"",
                    ""icon"": ""01n""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630548000,
            ""temp"": 19.59,
            ""feels_like"": 19.93,
            ""pressure"": 1022,
            ""humidity"": 89,
            ""dew_point"": 17.57,
            ""uvi"": 0,
            ""clouds"": 4,
            ""visibility"": 10000,
            ""wind_speed"": 2.62,
            ""wind_deg"": 61,
            ""wind_gust"": 3.93,
            ""weather"": [
                {
            ""id"": 800,
                    ""main"": ""Clear"",
                    ""description"": ""céu limpo"",
                    ""icon"": ""01n""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630551600,
            ""temp"": 19.31,
            ""feels_like"": 19.65,
            ""pressure"": 1021,
            ""humidity"": 90,
            ""dew_point"": 17.41,
            ""uvi"": 0,
            ""clouds"": 3,
            ""visibility"": 10000,
            ""wind_speed"": 2.08,
            ""wind_deg"": 60,
            ""wind_gust"": 2.86,
            ""weather"": [
                {
            ""id"": 800,
                    ""main"": ""Clear"",
                    ""description"": ""céu limpo"",
                    ""icon"": ""01n""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630555200,
            ""temp"": 19,
            ""feels_like"": 19.31,
            ""pressure"": 1021,
            ""humidity"": 90,
            ""dew_point"": 17.25,
            ""uvi"": 0,
            ""clouds"": 3,
            ""visibility"": 10000,
            ""wind_speed"": 1.8,
            ""wind_deg"": 48,
            ""wind_gust"": 2.46,
            ""weather"": [
                {
            ""id"": 800,
                    ""main"": ""Clear"",
                    ""description"": ""céu limpo"",
                    ""icon"": ""01n""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630558800,
            ""temp"": 18.78,
            ""feels_like"": 19.06,
            ""pressure"": 1020,
            ""humidity"": 90,
            ""dew_point"": 17.01,
            ""uvi"": 0,
            ""clouds"": 2,
            ""visibility"": 10000,
            ""wind_speed"": 1.34,
            ""wind_deg"": 29,
            ""wind_gust"": 1.65,
            ""weather"": [
                {
            ""id"": 800,
                    ""main"": ""Clear"",
                    ""description"": ""céu limpo"",
                    ""icon"": ""01n""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630562400,
            ""temp"": 18.63,
            ""feels_like"": 18.9,
            ""pressure"": 1020,
            ""humidity"": 90,
            ""dew_point"": 16.89,
            ""uvi"": 0,
            ""clouds"": 2,
            ""visibility"": 10000,
            ""wind_speed"": 1.17,
            ""wind_deg"": 24,
            ""wind_gust"": 1.39,
            ""weather"": [
                {
            ""id"": 800,
                    ""main"": ""Clear"",
                    ""description"": ""céu limpo"",
                    ""icon"": ""01n""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630566000,
            ""temp"": 18.59,
            ""feels_like"": 18.85,
            ""pressure"": 1020,
            ""humidity"": 90,
            ""dew_point"": 16.73,
            ""uvi"": 0,
            ""clouds"": 0,
            ""visibility"": 10000,
            ""wind_speed"": 1.37,
            ""wind_deg"": 14,
            ""wind_gust"": 1.52,
            ""weather"": [
                {
            ""id"": 800,
                    ""main"": ""Clear"",
                    ""description"": ""céu limpo"",
                    ""icon"": ""01n""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630569600,
            ""temp"": 18.46,
            ""feels_like"": 18.71,
            ""pressure"": 1020,
            ""humidity"": 90,
            ""dew_point"": 16.64,
            ""uvi"": 0,
            ""clouds"": 0,
            ""visibility"": 10000,
            ""wind_speed"": 1.43,
            ""wind_deg"": 27,
            ""wind_gust"": 1.6,
            ""weather"": [
                {
            ""id"": 800,
                    ""main"": ""Clear"",
                    ""description"": ""céu limpo"",
                    ""icon"": ""01n""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630573200,
            ""temp"": 18.34,
            ""feels_like"": 18.58,
            ""pressure"": 1021,
            ""humidity"": 90,
            ""dew_point"": 16.53,
            ""uvi"": 0,
            ""clouds"": 0,
            ""visibility"": 10000,
            ""wind_speed"": 1.39,
            ""wind_deg"": 27,
            ""wind_gust"": 1.55,
            ""weather"": [
                {
            ""id"": 800,
                    ""main"": ""Clear"",
                    ""description"": ""céu limpo"",
                    ""icon"": ""01n""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630576800,
            ""temp"": 18.98,
            ""feels_like"": 19.21,
            ""pressure"": 1021,
            ""humidity"": 87,
            ""dew_point"": 16.56,
            ""uvi"": 0.38,
            ""clouds"": 0,
            ""visibility"": 10000,
            ""wind_speed"": 1.6,
            ""wind_deg"": 29,
            ""wind_gust"": 1.88,
            ""weather"": [
                {
            ""id"": 800,
                    ""main"": ""Clear"",
                    ""description"": ""céu limpo"",
                    ""icon"": ""01d""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630580400,
            ""temp"": 20.36,
            ""feels_like"": 20.51,
            ""pressure"": 1021,
            ""humidity"": 79,
            ""dew_point"": 16.5,
            ""uvi"": 1.55,
            ""clouds"": 0,
            ""visibility"": 10000,
            ""wind_speed"": 1.84,
            ""wind_deg"": 32,
            ""wind_gust"": 2.32,
            ""weather"": [
                {
            ""id"": 800,
                    ""main"": ""Clear"",
                    ""description"": ""céu limpo"",
                    ""icon"": ""01d""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630584000,
            ""temp"": 22.22,
            ""feels_like"": 22.33,
            ""pressure"": 1021,
            ""humidity"": 70,
            ""dew_point"": 16.26,
            ""uvi"": 3.64,
            ""clouds"": 0,
            ""visibility"": 10000,
            ""wind_speed"": 1.75,
            ""wind_deg"": 34,
            ""wind_gust"": 2.62,
            ""weather"": [
                {
            ""id"": 800,
                    ""main"": ""Clear"",
                    ""description"": ""céu limpo"",
                    ""icon"": ""01d""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630587600,
            ""temp"": 23.98,
            ""feels_like"": 24.05,
            ""pressure"": 1021,
            ""humidity"": 62,
            ""dew_point"": 16.1,
            ""uvi"": 5.98,
            ""clouds"": 0,
            ""visibility"": 10000,
            ""wind_speed"": 1.36,
            ""wind_deg"": 65,
            ""wind_gust"": 2.33,
            ""weather"": [
                {
            ""id"": 800,
                    ""main"": ""Clear"",
                    ""description"": ""céu limpo"",
                    ""icon"": ""01d""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630591200,
            ""temp"": 25.02,
            ""feels_like"": 25.09,
            ""pressure"": 1020,
            ""humidity"": 58,
            ""dew_point"": 16,
            ""uvi"": 7.84,
            ""clouds"": 0,
            ""visibility"": 10000,
            ""wind_speed"": 1.64,
            ""wind_deg"": 115,
            ""wind_gust"": 2.07,
            ""weather"": [
                {
            ""id"": 800,
                    ""main"": ""Clear"",
                    ""description"": ""céu limpo"",
                    ""icon"": ""01d""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630594800,
            ""temp"": 25.24,
            ""feels_like"": 25.33,
            ""pressure"": 1019,
            ""humidity"": 58,
            ""dew_point"": 16.07,
            ""uvi"": 8.45,
            ""clouds"": 2,
            ""visibility"": 10000,
            ""wind_speed"": 3.06,
            ""wind_deg"": 126,
            ""wind_gust"": 2.68,
            ""weather"": [
                {
            ""id"": 800,
                    ""main"": ""Clear"",
                    ""description"": ""céu limpo"",
                    ""icon"": ""01d""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630598400,
            ""temp"": 25.52,
            ""feels_like"": 25.69,
            ""pressure"": 1018,
            ""humidity"": 60,
            ""dew_point"": 16.63,
            ""uvi"": 7.51,
            ""clouds"": 3,
            ""visibility"": 10000,
            ""wind_speed"": 3.82,
            ""wind_deg"": 127,
            ""wind_gust"": 3.34,
            ""weather"": [
                {
            ""id"": 800,
                    ""main"": ""Clear"",
                    ""description"": ""céu limpo"",
                    ""icon"": ""01d""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630602000,
            ""temp"": 25.38,
            ""feels_like"": 25.62,
            ""pressure"": 1018,
            ""humidity"": 63,
            ""dew_point"": 17.2,
            ""uvi"": 5.49,
            ""clouds"": 18,
            ""visibility"": 10000,
            ""wind_speed"": 4.18,
            ""wind_deg"": 123,
            ""wind_gust"": 3.95,
            ""weather"": [
                {
            ""id"": 801,
                    ""main"": ""Clouds"",
                    ""description"": ""algumas nuvens"",
                    ""icon"": ""02d""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630605600,
            ""temp"": 24.84,
            ""feels_like"": 25.1,
            ""pressure"": 1017,
            ""humidity"": 66,
            ""dew_point"": 17.62,
            ""uvi"": 3.11,
            ""clouds"": 31,
            ""visibility"": 10000,
            ""wind_speed"": 4.45,
            ""wind_deg"": 108,
            ""wind_gust"": 4.84,
            ""weather"": [
                {
            ""id"": 802,
                    ""main"": ""Clouds"",
                    ""description"": ""nuvens dispersas"",
                    ""icon"": ""03d""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630609200,
            ""temp"": 24.28,
            ""feels_like"": 24.57,
            ""pressure"": 1017,
            ""humidity"": 69,
            ""dew_point"": 18.01,
            ""uvi"": 1.25,
            ""clouds"": 99,
            ""visibility"": 10000,
            ""wind_speed"": 4.57,
            ""wind_deg"": 105,
            ""wind_gust"": 5.84,
            ""weather"": [
                {
            ""id"": 804,
                    ""main"": ""Clouds"",
                    ""description"": ""nublado"",
                    ""icon"": ""04d""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630612800,
            ""temp"": 23.75,
            ""feels_like"": 24.09,
            ""pressure"": 1016,
            ""humidity"": 73,
            ""dew_point"": 18.41,
            ""uvi"": 0.24,
            ""clouds"": 69,
            ""visibility"": 10000,
            ""wind_speed"": 4.23,
            ""wind_deg"": 101,
            ""wind_gust"": 6.63,
            ""weather"": [
                {
            ""id"": 803,
                    ""main"": ""Clouds"",
                    ""description"": ""nublado"",
                    ""icon"": ""04d""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630616400,
            ""temp"": 23.08,
            ""feels_like"": 23.45,
            ""pressure"": 1017,
            ""humidity"": 77,
            ""dew_point"": 18.55,
            ""uvi"": 0,
            ""clouds"": 49,
            ""visibility"": 10000,
            ""wind_speed"": 4.17,
            ""wind_deg"": 88,
            ""wind_gust"": 6.67,
            ""weather"": [
                {
            ""id"": 802,
                    ""main"": ""Clouds"",
                    ""description"": ""nuvens dispersas"",
                    ""icon"": ""03n""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630620000,
            ""temp"": 22.68,
            ""feels_like"": 23.01,
            ""pressure"": 1017,
            ""humidity"": 77,
            ""dew_point"": 18.39,
            ""uvi"": 0,
            ""clouds"": 48,
            ""visibility"": 10000,
            ""wind_speed"": 4.08,
            ""wind_deg"": 75,
            ""wind_gust"": 6.91,
            ""weather"": [
                {
            ""id"": 802,
                    ""main"": ""Clouds"",
                    ""description"": ""nuvens dispersas"",
                    ""icon"": ""03n""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630623600,
            ""temp"": 22.18,
            ""feels_like"": 22.52,
            ""pressure"": 1018,
            ""humidity"": 79,
            ""dew_point"": 18.15,
            ""uvi"": 0,
            ""clouds"": 53,
            ""visibility"": 10000,
            ""wind_speed"": 3.17,
            ""wind_deg"": 71,
            ""wind_gust"": 5,
            ""weather"": [
                {
            ""id"": 803,
                    ""main"": ""Clouds"",
                    ""description"": ""nublado"",
                    ""icon"": ""04n""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630627200,
            ""temp"": 21.77,
            ""feels_like"": 22.09,
            ""pressure"": 1018,
            ""humidity"": 80,
            ""dew_point"": 17.91,
            ""uvi"": 0,
            ""clouds"": 57,
            ""visibility"": 10000,
            ""wind_speed"": 2.56,
            ""wind_deg"": 64,
            ""wind_gust"": 3.84,
            ""weather"": [
                {
            ""id"": 803,
                    ""main"": ""Clouds"",
                    ""description"": ""nublado"",
                    ""icon"": ""04n""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630630800,
            ""temp"": 21.46,
            ""feels_like"": 21.75,
            ""pressure"": 1018,
            ""humidity"": 80,
            ""dew_point"": 17.66,
            ""uvi"": 0,
            ""clouds"": 57,
            ""visibility"": 10000,
            ""wind_speed"": 2.27,
            ""wind_deg"": 50,
            ""wind_gust"": 3.5,
            ""weather"": [
                {
            ""id"": 803,
                    ""main"": ""Clouds"",
                    ""description"": ""nublado"",
                    ""icon"": ""04n""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630634400,
            ""temp"": 21.21,
            ""feels_like"": 21.45,
            ""pressure"": 1018,
            ""humidity"": 79,
            ""dew_point"": 17.36,
            ""uvi"": 0,
            ""clouds"": 33,
            ""visibility"": 10000,
            ""wind_speed"": 1.46,
            ""wind_deg"": 32,
            ""wind_gust"": 1.93,
            ""weather"": [
                {
            ""id"": 802,
                    ""main"": ""Clouds"",
                    ""description"": ""nuvens dispersas"",
                    ""icon"": ""03n""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630638000,
            ""temp"": 21.01,
            ""feels_like"": 21.23,
            ""pressure"": 1018,
            ""humidity"": 79,
            ""dew_point"": 17.14,
            ""uvi"": 0,
            ""clouds"": 24,
            ""visibility"": 10000,
            ""wind_speed"": 1.13,
            ""wind_deg"": 13,
            ""wind_gust"": 1.33,
            ""weather"": [
                {
            ""id"": 801,
                    ""main"": ""Clouds"",
                    ""description"": ""algumas nuvens"",
                    ""icon"": ""02n""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630641600,
            ""temp"": 20.77,
            ""feels_like"": 20.97,
            ""pressure"": 1017,
            ""humidity"": 79,
            ""dew_point"": 16.8,
            ""uvi"": 0,
            ""clouds"": 18,
            ""visibility"": 10000,
            ""wind_speed"": 1.53,
            ""wind_deg"": 21,
            ""wind_gust"": 1.72,
            ""weather"": [
                {
            ""id"": 801,
                    ""main"": ""Clouds"",
                    ""description"": ""algumas nuvens"",
                    ""icon"": ""02n""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630645200,
            ""temp"": 20.54,
            ""feels_like"": 20.71,
            ""pressure"": 1016,
            ""humidity"": 79,
            ""dew_point"": 16.51,
            ""uvi"": 0,
            ""clouds"": 16,
            ""visibility"": 10000,
            ""wind_speed"": 1.77,
            ""wind_deg"": 18,
            ""wind_gust"": 2.05,
            ""weather"": [
                {
            ""id"": 801,
                    ""main"": ""Clouds"",
                    ""description"": ""algumas nuvens"",
                    ""icon"": ""02n""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630648800,
            ""temp"": 20.33,
            ""feels_like"": 20.46,
            ""pressure"": 1016,
            ""humidity"": 78,
            ""dew_point"": 16.27,
            ""uvi"": 0,
            ""clouds"": 15,
            ""visibility"": 10000,
            ""wind_speed"": 1.72,
            ""wind_deg"": 15,
            ""wind_gust"": 2.1,
            ""weather"": [
                {
            ""id"": 801,
                    ""main"": ""Clouds"",
                    ""description"": ""algumas nuvens"",
                    ""icon"": ""02n""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630652400,
            ""temp"": 20.14,
            ""feels_like"": 20.25,
            ""pressure"": 1016,
            ""humidity"": 78,
            ""dew_point"": 16.03,
            ""uvi"": 0,
            ""clouds"": 10,
            ""visibility"": 10000,
            ""wind_speed"": 1.7,
            ""wind_deg"": 3,
            ""wind_gust"": 2.01,
            ""weather"": [
                {
            ""id"": 800,
                    ""main"": ""Clear"",
                    ""description"": ""céu limpo"",
                    ""icon"": ""01n""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630656000,
            ""temp"": 19.99,
            ""feels_like"": 20.08,
            ""pressure"": 1016,
            ""humidity"": 78,
            ""dew_point"": 15.92,
            ""uvi"": 0,
            ""clouds"": 9,
            ""visibility"": 10000,
            ""wind_speed"": 1.96,
            ""wind_deg"": 14,
            ""wind_gust"": 2.25,
            ""weather"": [
                {
            ""id"": 800,
                    ""main"": ""Clear"",
                    ""description"": ""céu limpo"",
                    ""icon"": ""01n""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630659600,
            ""temp"": 19.87,
            ""feels_like"": 19.95,
            ""pressure"": 1017,
            ""humidity"": 78,
            ""dew_point"": 15.76,
            ""uvi"": 0,
            ""clouds"": 8,
            ""visibility"": 10000,
            ""wind_speed"": 1.95,
            ""wind_deg"": 15,
            ""wind_gust"": 2.36,
            ""weather"": [
                {
            ""id"": 800,
                    ""main"": ""Clear"",
                    ""description"": ""céu limpo"",
                    ""icon"": ""01n""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630663200,
            ""temp"": 20.6,
            ""feels_like"": 20.67,
            ""pressure"": 1017,
            ""humidity"": 75,
            ""dew_point"": 15.83,
            ""uvi"": 0.35,
            ""clouds"": 23,
            ""visibility"": 10000,
            ""wind_speed"": 1.94,
            ""wind_deg"": 14,
            ""wind_gust"": 2.49,
            ""weather"": [
                {
            ""id"": 801,
                    ""main"": ""Clouds"",
                    ""description"": ""algumas nuvens"",
                    ""icon"": ""02d""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630666800,
            ""temp"": 22.24,
            ""feels_like"": 22.32,
            ""pressure"": 1017,
            ""humidity"": 69,
            ""dew_point"": 16.06,
            ""uvi"": 1.41,
            ""clouds"": 38,
            ""visibility"": 10000,
            ""wind_speed"": 1.88,
            ""wind_deg"": 14,
            ""wind_gust"": 2.63,
            ""weather"": [
                {
            ""id"": 802,
                    ""main"": ""Clouds"",
                    ""description"": ""nuvens dispersas"",
                    ""icon"": ""03d""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630670400,
            ""temp"": 23.94,
            ""feels_like"": 24.03,
            ""pressure"": 1017,
            ""humidity"": 63,
            ""dew_point"": 16.2,
            ""uvi"": 3.28,
            ""clouds"": 49,
            ""visibility"": 10000,
            ""wind_speed"": 2.3,
            ""wind_deg"": 25,
            ""wind_gust"": 3.39,
            ""weather"": [
                {
            ""id"": 802,
                    ""main"": ""Clouds"",
                    ""description"": ""nuvens dispersas"",
                    ""icon"": ""03d""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630674000,
            ""temp"": 25.96,
            ""feels_like"": 25.96,
            ""pressure"": 1017,
            ""humidity"": 56,
            ""dew_point"": 16.3,
            ""uvi"": 5.83,
            ""clouds"": 97,
            ""visibility"": 10000,
            ""wind_speed"": 1.64,
            ""wind_deg"": 28,
            ""wind_gust"": 2.99,
            ""weather"": [
                {
            ""id"": 804,
                    ""main"": ""Clouds"",
                    ""description"": ""nublado"",
                    ""icon"": ""04d""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630677600,
            ""temp"": 27.56,
            ""feels_like"": 28.05,
            ""pressure"": 1016,
            ""humidity"": 51,
            ""dew_point"": 16.22,
            ""uvi"": 7.63,
            ""clouds"": 82,
            ""visibility"": 10000,
            ""wind_speed"": 1.51,
            ""wind_deg"": 62,
            ""wind_gust"": 2.74,
            ""weather"": [
                {
            ""id"": 803,
                    ""main"": ""Clouds"",
                    ""description"": ""nublado"",
                    ""icon"": ""04d""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630681200,
            ""temp"": 28.26,
            ""feels_like"": 28.65,
            ""pressure"": 1015,
            ""humidity"": 49,
            ""dew_point"": 16.09,
            ""uvi"": 8.22,
            ""clouds"": 88,
            ""visibility"": 10000,
            ""wind_speed"": 1.56,
            ""wind_deg"": 116,
            ""wind_gust"": 2.45,
            ""weather"": [
                {
            ""id"": 804,
                    ""main"": ""Clouds"",
                    ""description"": ""nublado"",
                    ""icon"": ""04d""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630684800,
            ""temp"": 28.03,
            ""feels_like"": 28.57,
            ""pressure"": 1014,
            ""humidity"": 51,
            ""dew_point"": 16.19,
            ""uvi"": 7.49,
            ""clouds"": 91,
            ""visibility"": 10000,
            ""wind_speed"": 2.86,
            ""wind_deg"": 121,
            ""wind_gust"": 2.97,
            ""weather"": [
                {
            ""id"": 804,
                    ""main"": ""Clouds"",
                    ""description"": ""nublado"",
                    ""icon"": ""04d""
                }
            ],
            ""pop"": 0
        },
        {
        ""dt"": 1630688400,
            ""temp"": 28,
            ""feels_like"": 28.63,
            ""pressure"": 1013,
            ""humidity"": 52,
            ""dew_point"": 16.48,
            ""uvi"": 5.47,
            ""clouds"": 93,
            ""visibility"": 10000,
            ""wind_speed"": 3.43,
            ""wind_deg"": 115,
            ""wind_gust"": 3.25,
            ""weather"": [
                {
            ""id"": 804,
                    ""main"": ""Clouds"",
                    ""description"": ""nublado"",
                    ""icon"": ""04d""
                }
            ],
            ""pop"": 0
        }
    ]
}";

        public static readonly PrevisaoHoraOpenW previsao = new()
        {
            SensacaoTermica = 24.63f,
            Temperatura = 24.43f,
            ProbPrecipitacao = 0.21f,
            Pressao = 1020f,
            Humidade = 65f,
            PontoOrvalho = 17.43f,
            IndiceUV = 0.99f,
            CoberturaNuvem = 75f,
            Visibilidade = 10000f,
            DataPrevisao = new System.DateTime(2021, 09, 01, 16, 00, 00),
            Condicoes = new List<Condicao>()
            {
                new Condicao()
                {
                    Principal = "Clouds",
                    Detalhes = "nublado",
                    Icone = "04d"
                }       
            }
        };
    }
}
