#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["FarmApp.Application/FarmApp.Application.csproj", "FarmApp.Application/"]
COPY ["FarmApp.Service/FarmApp.Service.csproj", "FarmApp.Service/"]
COPY ["FarmApp.Infra.Data/FarmApp.Infra.Data.csproj", "FarmApp.Infra.Data/"]
COPY ["FarmApp.Domain/FarmApp.Domain.csproj", "FarmApp.Domain/"]
RUN dotnet restore "FarmApp.Application/FarmApp.Application.csproj"
COPY . .
WORKDIR "/src/FarmApp.Application"
RUN dotnet build "FarmApp.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FarmApp.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FarmApp.Application.dll"]