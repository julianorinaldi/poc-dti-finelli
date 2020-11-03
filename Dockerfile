FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source
LABEL "Maintainer"="julianorinaldi"

COPY Source/FinelliServiceCRUDVehicle/. ./FinelliServiceCRUDVehicle/
COPY Source/FinelliApplicationVehicle/. ./FinelliApplicationVehicle/
COPY Source/FinelliDomainVehicle/. ./FinelliDomainVehicle/
COPY Source/FinelliDomainCore/. ./FinelliDomainCore/
COPY Source/FinelliDataCore/. ./FinelliDataCore/
COPY Source/FinelliDomainMonolito/. ./FinelliDomainMonolito/
WORKDIR /source/FinelliServiceCRUDVehicle
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "FinelliServiceCRUDVehicle.dll"]