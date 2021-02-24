﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace Conexa.Infra.Integracoes.OpenWeather.Entidades
{
    public class Clima
    {
        [JsonProperty("coord")]
        public Coord Coord { get; set; }

        [JsonProperty("weather")]
        public IEnumerable<Weather> Weather { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("main")]
        public Main Main { get; set; }

        [JsonProperty("visibility")]
        public long Visibility { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }

        [JsonProperty("dt")]
        public long Dt { get; set; }

        [JsonProperty("sys")]
        public Sys Sys { get; set; }

        [JsonProperty("timezone")]
        public long Timezone { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cod")]
        public long Cod { get; set; }

        public Erro Erro { get; set; }
    }
}
