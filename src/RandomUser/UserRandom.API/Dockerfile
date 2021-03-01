#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["UserRandom.API/UserRandom.API.csproj", "UserRandom.API/"]
COPY ["UserRandom.Application/UserRandom.Application.csproj", "UserRandom.Application/"]
COPY ["UserRandom.Data/UserRandom.Data.csproj", "UserRandom.Data/"]
COPY ["UserRandom.CrossCutting/UserRandom.CrossCutting.csproj", "UserRandom.CrossCutting/"]
COPY ["UserRandom.Domain/UserRandom.Domain.csproj", "UserRandom.Domain/"]
COPY ["UserRandom.IoC/UserRandom.IoC.csproj", "UserRandom.IoC/"]
RUN dotnet restore "UserRandom.API/UserRandom.API.csproj"
COPY . .
WORKDIR "/src/UserRandom.API"
RUN dotnet build "UserRandom.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserRandom.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserRandom.API.dll"]
