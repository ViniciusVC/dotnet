# Usar a imagem base do .NET 8 SDK para compilar e publicar a aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar os arquivos de projeto e restaurar as dependências
COPY *.csproj ./
RUN dotnet restore

# Copiar o restante do código e publicar a aplicação
COPY . ./
RUN dotnet publish -c Release -o out

# Usar a imagem base do .NET 8 Runtime para rodar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Expor a porta 5000 para acesso à aplicação
EXPOSE 5000

# Definir o ponto de entrada para a aplicação
ENTRYPOINT ["dotnet", "VVC.console24062024.aplication.dll"]