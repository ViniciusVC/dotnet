
## VVC.DotNetAPI

Este é o exemplo padrao de DotNet API, em codigo C#, codificado no VSCode no Linux Ubuntu.
API de Previsão do Tempo.


/csharp_api/

![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![Vscode](https://img.shields.io/badge/Vscode-007ACC?style=for-the-badge&logo=visual-studio-code&logoColor=white)
![Linux](https://img.shields.io/badge/Linux-000?style=for-the-badge&logo=linux&logoColor=FCC624)
[![swagger-editor](https://img.shields.io/badge/open--API-in--editor-brightgreen.svg?style=flat&label=client%20open-api-v3)](https://editor.swagger.io/?url=https://raw.githubusercontent.com/lucaro/DRES/master/doc/oas-client.json)

https://github.com/ViniciusVC/dotnet/tree/main/VVC.DotNetAPI


# Criar projeto .net API
```
$ dotnet new webapi --name csharp_api
```

# Rorando servidor 
```
$ dotnet watch run
ou
$ dotnet run
ou
$ dotnet run --project src/csharp_api.csproj

```

# Ao iniciar o servidor 
```
Abra o Swagger em:
http://localhost:5297/swagger/index.html
```

## Endpoints :
* http://localhost:5297/WeatherForecast
* http://localhost:5297/WeatherForecast/api/operadores/{id}


# Controllers
```
Apage os  arquivos controllers criados por padrão.
```

# Criar classe
```
Crie o arquivo da classe na pasta Entities.

```


Execute o contêiner a partir da imagem criada:
```
$ cd src
$ sudo docker run -d -p 8080:80 --name DotNetAPIcontainer DotNetAPI
```



