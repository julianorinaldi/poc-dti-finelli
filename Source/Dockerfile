FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source
LABEL "Maintainer"="julianorinaldi"

COPY FinelliServiceCRUDVehicle/*.csproj ./FinelliServiceCRUDVehicle/
COPY FinelliApplicationVehicle/*.csproj ./FinelliApplicationVehicle/
COPY FinelliDomainVehicle/*.csproj ./FinelliDomainVehicle/
COPY FinelliDomainCore/*.csproj ./FinelliDomainCore/
COPY FinelliDataCore/*.csproj ./FinelliDataCore/
COPY FinelliDomainMonolito/*.csproj ./FinelliDomainMonolito/
RUN dotnet restore

COPY FinelliServiceCRUDVehicle/. ./FinelliServiceCRUDVehicle/
COPY FinelliApplicationVehicle/. ./FinelliApplicationVehicle/
COPY FinelliDomainVehicle/. ./FinelliDomainVehicle/
COPY FinelliDomainCore/. ./FinelliDomainCore/
COPY FinelliDataCore/. ./FinelliDataCore/
COPY FinelliDomainMonolito/. ./FinelliDomainMonolito/
WORKDIR /source/FinelliServiceCRUDVehicle
RUN dotnet publish -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "FinelliServiceCRUDVehicle.dll"]