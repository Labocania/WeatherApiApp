using Xunit;
using FluentAssertions;
using WeatherApiApp.Services;
using WeatherApiApp.Models;

namespace Testes
{
    public class UnitTest1
    {
        private Deserializer deserializer = new();
        [Fact]
        public void PrevisaoHoraWSucesso()
        {
            PrevisaoHoraOpenW previsao = deserializer.ConverterClimaAtual(PrevisaoHoraWStub.json);
            Assert.NotNull(previsao);
            PrevisaoHoraWStub.previsao.Should().BeEquivalentTo(previsao);
        }
    }
}
