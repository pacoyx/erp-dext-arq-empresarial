#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /src
COPY . .
WORKDIR /src/Dls.Erp.Services.WebApi

ENV ASPNETCORE_ENVIRONMENT Development

RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /src/Dls.Erp.Services.WebApi/out ./

EXPOSE 80
EXPOSE 8080

ENTRYPOINT ["dotnet", "Dls.Erp.Services.WebApi.dll"]