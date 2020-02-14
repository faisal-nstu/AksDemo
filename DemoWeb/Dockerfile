#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

#
# Angular Client build
#
FROM node:12 as angular-build
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["DemoWeb/DemoWeb.csproj", "DemoWeb/"]
RUN dotnet restore "DemoWeb/DemoWeb.csproj"
COPY . .
WORKDIR "/src/DemoWeb"
RUN dotnet build "DemoWeb.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DemoWeb.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DemoWeb.dll"]