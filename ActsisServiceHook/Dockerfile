FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

ARG ASPNETCORE_ENVIRONMENT
ARG RABBITMQ__HOST
ARG RABBITMQ__PORT
ARG RABBITMQ__MAXRETRYATTEMPS

ENV ASPNETCORE_ENVIRONMENT=${ASPNETCORE_ENVIRONMENT}
ENV RABBITMQ__HOST=${RABBITMQ__HOST}
ENV RABBITMQ__PORT=${RABBITMQ__PORT}
ENV RABBITMQ__MAXRETRYATTEMPS=${RABBITMQ__MAXRETRYATTEMPS}

COPY Nuget.Config ./Nuget.Config
COPY ActsisServiceHook.sln ./ActsisServiceHook.sln
COPY Src/ServiceHook.Api/ServiceHook.Api.csproj Src/ServiceHook.Api/
COPY Src/ServiceHook.Application/ServiceHook.Application.csproj Src/ServiceHook.Application/
COPY Src/ServiceHook.Domain/ServiceHook.Domain.csproj Src/ServiceHook.Domain/
COPY Src/ServiceHook.Infrastructure/ServiceHook.Infrastructure.csproj Src/ServiceHook.Infrastructure/

RUN dotnet restore

COPY . .

WORKDIR /src/Src/ServiceHook.Api
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ServiceHook.Api.dll"]
