FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["src/Best.Route.Web/Best.Route.Web.csproj", "src/Best.Route.Web/"]
COPY ["src/Best.Route.Infrastructure/Best.Route.Infrastructure.csproj", "src/Best.Route.Infrastructure/"]
COPY ["src/Best.Route.Core/Best.Route.Core.csproj", "src/Best.Route.Core/"]
COPY ["src/Best.Route.UseCases/Best.Route.UseCases.csproj", "src/Best.Route.UseCases/"]
RUN dotnet restore "./src/Best.Route.Web/Best.Route.Web.csproj"
COPY . .
WORKDIR "/src/src/Best.Route.Web"
RUN dotnet build "./Best.Route.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Best.Route.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Best.Route.Web.dll"]