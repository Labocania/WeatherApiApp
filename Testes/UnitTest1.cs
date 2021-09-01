using Xunit;
using WeatherApiApp.Services;
using WeatherApiApp.Models;

namespace Testes
{
    public class UnitTest1
    {
        private Deserializer deserializer = new();
        [Fact]
        public void ClimaAtualOpenWSucesso()
        {
            ClimaAtualOpenW clima = new();
            clima = deserializer.ConverterClimaAtual(ClimaAtualWCorreto.dailyW);
            Assert.NotNull(clima);
            Assert.Equal(ClimaAtualWCorreto.previsao.DataPrevisao, clima.DataPrevisao);
            Assert.Equal(ClimaAtualWCorreto.previsao.DataAmanhecer, clima.DataAmanhecer);
            Assert.Equal(ClimaAtualWCorreto.previsao.DataEntardecer, clima.DataEntardecer);
        }
    }
}
