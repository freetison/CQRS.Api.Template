#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY src/nuget.config .
COPY ["src/Fiter.Access.Api/Fiter.Access.Api.csproj", "src/Fiter.Access.Api/"]
COPY ["src/Fiter.Access.App/Fiter.Access.App.csproj", "src/Fiter.Access.App/"]
COPY ["src/Fiter.Access.Domain/Fiter.Access.Domain.csproj", "src/Fiter.Access.Domain/"]
COPY ["src/Fiter.Access.Infra/Fiter.Access.Infra.csproj", "src/Fiter.Access.Infra/"]

RUN ls src -la

RUN dotnet restore "src/Fiter.Access.Api/Fiter.Access.Api.csproj" --configfile "nuget.config"
RUN dotnet restore "src/Fiter.Access.Api/Fiter.Access.App.csproj" --configfile "nuget.config"
RUN dotnet restore "src/Fiter.Access.Api/Fiter.Access.Domain.csproj" --configfile "./nuget.config"
RUN dotnet restore "src/Fiter.Access.Api/Fiter.Access.Infra.csproj" --configfile "./nuget.config"

COPY . .
WORKDIR "/src/src/Fiter.Access.Api"
RUN dotnet build "Fiter.Access.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Fiter.Access.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Fiter.Access.Api.dll"]
