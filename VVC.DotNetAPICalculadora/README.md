
## Projeto Caltuladora Simples API.

Este é um exemplo de projeto DotNet API.

Foi codificado no VSCode no Linux Ubuntu.

/VVC.DotNetAPICalculadora/

![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![Vscode](https://img.shields.io/badge/Vscode-007ACC?style=for-the-badge&logo=visual-studio-code&logoColor=white)
![Linux](https://img.shields.io/badge/Linux-000?style=for-the-badge&logo=linux&logoColor=FCC624)
[![swagger-editor](https://img.shields.io/badge/open--API-in--editor-brightgreen.svg?style=flat&label=client%20open-api-v3)](https://editor.swagger.io/?url=https://raw.githubusercontent.com/lucaro/DRES/master/doc/oas-client.json)

https://github.com/ViniciusVC/dotnet/tree/main/VVC.DotNetAPICalculadora

# Criar projeto .net API
```
$ dotnet new webapi --name CalculadoraSimplesAPI
```

# Rorando servidor (com atualização automatica)
```
$ dotnet watch run
```
![terminal API](docs/sreenshot_terinal_dotnet.png "screenshot")


# Swagger
```
Swagger é um front apenas para teste de API.
Abre uma pagina em com Swagger em:
http://localhost:5271/swagger/index.html
```
![navegador swagger](docs/screenshot_swagger_dotnet.png "screenshot")


# Controllers
```
Apage os  arquivos controllers criados por padrão.
```

# Criar classe
```
crie a pasta Models
mkdir Models
crie o arquivo da classe model nesta pasta.

```

# docker
```
Para gerar a imagem:
$ sudo docker build . -t dotnet_api_calculadora_img

Criar um contêiner a partir da imagem que vc criou:
$ sudo docker run -d -p 4000:5271 --name dotnet_api_calculadora dotnet_api_calculadora_img

Para a execução do contêiner: 
$ sudo docker stop dotnet_api_calculadora
```
