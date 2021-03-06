﻿using Conexa.Infra.Integracoes.OpenWeather.Entidades;
using System.Threading.Tasks;

namespace Conexa.Infra.Integracoes.OpenWeather.Interfaces
{
    public interface IWeather
    {
        Task<Clima> ObterTemperaturaPorCidade(string cidade);
        Task<Clima> ObterTemperaturaPorLocalizacao(decimal latitude, decimal longitude);
    }
}
