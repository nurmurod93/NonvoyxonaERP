FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY NonvoyxonaERP.Domain/NonvoyxonaERP.Domain.csproj NonvoyxonaERP.Domain/
COPY NonvoyxonaERP.Application/NonvoyxonaERP.Application.csproj NonvoyxonaERP.Application/
COPY NonvoyxonaERP.Web/NonvoyxonaERP.Web.csproj NonvoyxonaERP.Web/
RUN dotnet restore NonvoyxonaERP.Web/NonvoyxonaERP.Web.csproj

COPY NonvoyxonaERP.Domain/ NonvoyxonaERP.Domain/
COPY NonvoyxonaERP.Application/ NonvoyxonaERP.Application/
COPY NonvoyxonaERP.Web/ NonvoyxonaERP.Web/

RUN dotnet publish NonvoyxonaERP.Web/NonvoyxonaERP.Web.csproj -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "NonvoyxonaERP.Web.dll"]
