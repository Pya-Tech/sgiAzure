# Etapa base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

ARG ASPNETCORE_ENVIRONMENT
ARG RABBITMQ__HOST
ARG RABBITMQ__PORT
ARG RABBITMQ__MAXRETRYATTEMPS

ENV ASPNETCORE_ENVIRONMENT=${ASPNETCORE_ENVIRONMENT}
ENV RABBITMQ__HOST=${RABBITMQ__HOST}
ENV RABBITMQ__PORT=${RABBITMQ__PORT}
ENV RABBITMQ__MAXRETRYATTEMPS=${RABBITMQ__MAXRETRYATTEMPS}

COPY Nuget.Config ./

COPY SgiAzure.sln ./
COPY Src/SgiAzure.Worker/SgiAzure.Worker.csproj Src/SgiAzure.Worker/
COPY Src/SgiAzure.Application/SgiAzure.Application.csproj Src/SgiAzure.Application/
COPY Src/SgiAzure.Domain/SgiAzure.Domain.csproj Src/SgiAzure.Domain/
COPY Src/SgiAzure.Infrastructure/SgiAzure.Infrastructure.csproj Src/SgiAzure.Infrastructure/
COPY Tests/SgiAzure.Application.Tests/SgiAzure.Application.Tests.csproj Tests/SgiAzure.Application.Tests/

RUN dotnet restore

COPY . .

WORKDIR /app/Src/SgiAzure.Worker
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SgiAzure.Worker.dll"]
