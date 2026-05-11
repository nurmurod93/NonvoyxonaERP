FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY NonvoyxonaERP.Domain/NonvoyxonaERP.Domain.csproj NonvoyxonaERP.Domain/
COPY NonvoyxonaERP.Data/NonvoyxonaERP.Data.csproj NonvoyxonaERP.Data/
COPY NonvoyxonaERP.Application/NonvoyxonaERP.Application.csproj NonvoyxonaERP.Application/
COPY NonvoyxonaERP.Services/NonvoyxonaERP.Services.csproj NonvoyxonaERP.Services/
COPY NonvoyxonaERP.API/NonvoyxonaERP.API.csproj NonvoyxonaERP.API/
RUN dotnet restore NonvoyxonaERP.API/NonvoyxonaERP.API.csproj

COPY NonvoyxonaERP.Domain/ NonvoyxonaERP.Domain/
COPY NonvoyxonaERP.Data/ NonvoyxonaERP.Data/
COPY NonvoyxonaERP.Application/ NonvoyxonaERP.Application/
COPY NonvoyxonaERP.Services/ NonvoyxonaERP.Services/
COPY NonvoyxonaERP.API/ NonvoyxonaERP.API/

RUN dotnet publish NonvoyxonaERP.API/NonvoyxonaERP.API.csproj -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "NonvoyxonaERP.API.dll"]
