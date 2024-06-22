
# Usar a imagem SDK como base para esta etapa da criação da imagem.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

# Criar um diretório de trabalho.
WORKDIR /app

# Copie tudo para o diretório de trabalho.
COPY . ./

# Baixar dependencias de todas as camadas. 
RUN dotnet restore

# Build e publish uma release na pasta /app/out.
RUN dotnet publish -c Release -o out


# criar um contêiner da imagem e executar o aplicativo, 


# Usar a imagem aspnet client como base para a proxima etapa.
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Pasta de trabalho
WORKDIR /runtimeapi

# Copiar o aplicativo publicado para o contêiner
COPY --from=build-env /app/out .

# Expor a porta 8080 do contêiner.
expose 8080

# Definir o comando inicial do contêiner.
ENTRYPOINT ["dotnet", "CalculadoraSimplesAPI.dll"]

# Quando o contêiner é iniciado, o comando ENTRYPOINT é executado e quando esse comando terminar, o contêiner será interrompido automaticamente.
