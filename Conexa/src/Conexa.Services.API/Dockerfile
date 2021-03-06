#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Conexa.Services.API/Conexa.Services.API.csproj", "src/Conexa.Services.API/"]
COPY ["src/Conexa.Infra.Integracoes.OpenWeather/Conexa.Infra.Integracoes.OpenWeather.csproj", "src/Conexa.Infra.Integracoes.OpenWeather/"]
COPY ["src/Conexa.Infra.Integracoes.Spotify/Conexa.Infra.Integracoes.Spotify.csproj", "src/Conexa.Infra.Integracoes.Spotify/"]
COPY ["src/Conexa.Application/Conexa.Application.csproj", "src/Conexa.Application/"]
COPY ["src/Conexa.Domain/Conexa.Domain.csproj", "src/Conexa.Domain/"]
RUN dotnet restore "src/Conexa.Services.API/Conexa.Services.API.csproj"
COPY . .
WORKDIR "/src/src/Conexa.Services.API"
RUN dotnet build "Conexa.Services.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Conexa.Services.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Conexa.Services.API.dll"]