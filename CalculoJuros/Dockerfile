FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build 
WORKDIR /app

COPY *.sln .
COPY ./CalculoJuros/*.csproj ./Api/
COPY ./CalculoJuros.Teste.Integracao/*.csproj ./Api.Tests/
COPY ./CalculoJuros.Teste.Unitario/*.csproj ./Api.Tests/
RUN dotnet restore

COPY Api/. ./api
WORKDIR /app/api
RUN dotnet publish -o published_api -v q

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
#efetua a cópia dos arquivos gerados pelo publish do estágio anterior
COPY --from=build /app/api/published_api ./
ENTRYPOINT [ "dotnet", "CalculoJuros.dll" ]