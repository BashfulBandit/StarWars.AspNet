FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
ARG RESOURCE_REAPER_SESSION_ID="00000000-0000-0000-0000-000000000000"
LABEL "org.testcontainers.resource-reaper-session"=$RESOURCE_REAPER_SESSION_ID
RUN apt-get update \
	&& apt-get install --yes curl
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG RESOURCE_REAPER_SESSION_ID="00000000-0000-0000-0000-000000000000"
LABEL "org.testcontainers.resource-reaper-session"=$RESOURCE_REAPER_SESSION_ID
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/StarWars.AspNet.Api/StarWars.AspNet.Api.csproj", "src/StarWars.AspNet.Api/"]
RUN dotnet restore "./src/StarWars.AspNet.Api/StarWars.AspNet.Api.csproj"
COPY . .
WORKDIR "/src/src/StarWars.AspNet.Api"
RUN dotnet build "./StarWars.AspNet.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG RESOURCE_REAPER_SESSION_ID="00000000-0000-0000-0000-000000000000"
LABEL "org.testcontainers.resource-reaper-session"=$RESOURCE_REAPER_SESSION_ID
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./StarWars.AspNet.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
ARG RESOURCE_REAPER_SESSION_ID="00000000-0000-0000-0000-000000000000"
LABEL "org.testcontainers.resource-reaper-session"=$RESOURCE_REAPER_SESSION_ID
LABEL "org.opencontainers.image.source"="https://github.com/BashfulBandit/StarWars.AspNet.Api"
WORKDIR /app
COPY --from=publish /app/publish .
HEALTHCHECK CMD curl --fail http://localhost/api/healthz || exit 1
ENTRYPOINT ["dotnet", "StarWars.AspNet.Api.dll"]
