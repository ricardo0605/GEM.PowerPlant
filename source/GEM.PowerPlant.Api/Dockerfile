#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["source/GEM.PowerPlant.Api/GEM.PowerPlant.Api.csproj", "source/GEM.PowerPlant.Api/"]
RUN dotnet restore "source/GEM.PowerPlant.Api/GEM.PowerPlant.Api.csproj"
COPY . .
WORKDIR "/src/source/GEM.PowerPlant.Api"
RUN dotnet build "GEM.PowerPlant.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GEM.PowerPlant.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GEM.PowerPlant.Api.dll"]