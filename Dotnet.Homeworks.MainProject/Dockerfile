﻿FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore Dotnet.Homeworks.MainProject/Dotnet.Homeworks.MainProject.csproj
WORKDIR /src/Dotnet.Homeworks.MainProject
RUN dotnet build Dotnet.Homeworks.MainProject.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish Dotnet.Homeworks.MainProject.csproj -c Release -o /app/publish 

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dotnet.Homeworks.MainProject.dll"]
