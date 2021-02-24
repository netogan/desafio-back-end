using AutoMapper;
using Conexa.Application;
using Conexa.Application.AutoMapper;
using Conexa.Application.Interface;
using Conexa.Domain.Interfaces.Service;
using Conexa.Domain.Services;
using Conexa.Infra.Integracoes.OpenWeather.Config;
using Conexa.Infra.Integracoes.OpenWeather.Interfaces;
using Conexa.Infra.Integracoes.OpenWeather.Services;
using Conexa.Infra.Integracoes.Spotify.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Conexa.Services.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddScoped<IPlaylistAppService, PlaylistAppService>();
            services.AddScoped<IPlaylistService, PlaylistService>();

            services.AddScoped<IWeather, Weather>();

            services.AddScoped<Infra.Integracoes.Spotify.Interfaces.IAuth, Infra.Integracoes.Spotify.Services.Auth>();
            services.AddScoped<Infra.Integracoes.Spotify.Interfaces.ITracks, Infra.Integracoes.Spotify.Services.Tracks>();


            //services.Configure<OpenWeatherConfig>(option => Configuration.GetSection("OpenWeatherConfig").Bind(option));

            //services.Configure<SpotifyConfig>(option => Configuration.GetSection("SpotifyConfig").Bind(option));



            services.Configure<OpenWeatherConfig>(Configuration.GetSection("OpenWeatherConfig"));

            services.Configure<SpotifyConfig>(Configuration.GetSection("SpotifyConfig"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
