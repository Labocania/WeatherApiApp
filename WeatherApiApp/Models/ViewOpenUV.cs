using System;

namespace WeatherApiApp.Models
{
    public class ViewOpenUV
    {
        private readonly DateTime _horario;
        private readonly float _uv;
        private (string mensagem, string classe) _mensagem;


        public ViewOpenUV(PrevisaoOpenUV previsao)
        {
            _horario = previsao.Horario;
            _uv = previsao.IndiceUV;
        }

        public string HorarioDia()
        {
            return _horario.ToShortDateString();
        }

        public string Horario()
        {
            return _horario.ToShortTimeString();
        }

        public (string mensagem, string classe) MensagemCorUV()
        {
            _mensagem = _uv switch
            {
                > 11f => ("Extremo", "list-group-item-primary"),
                >= 8f => ("Muito alto", "list-group-item-danger"),
                >= 6 => ("Alto", "list-group-item-warning"),
                >= 3 => ("Moderado", "list-group-item-dark"),
                _ => ("Baixo", "list-group-item-light")
            };

            return _mensagem;
        }

        public float UV()
        {
            return _uv;
        }
    }
}
