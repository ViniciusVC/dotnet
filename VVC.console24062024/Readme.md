## VVC.console24062014

Este é um exemplo de projeto DotNet Core do tipo console.

Codificado em C#, no VSCode, no Linux Ubuntu.

![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![Vscode](https://img.shields.io/badge/Vscode-007ACC?style=for-the-badge&logo=visual-studio-code&logoColor=white)
![Linux](https://img.shields.io/badge/Linux-000?style=for-the-badge&logo=linux&logoColor=FCC624)


Repositorio no GIT :
https://github.com/ViniciusVC/dotnet/tree/main/VVC.DotNetTerminal


# Comandos para criar esta aplicação:
```
// Instalar o SDK do .NET:
$ sudo apt-get install -y dotnet-sdk-8.0

$ cd VVC.console24062024
$ dotnet new sln
$ mkdir cd VVC.console24062024.aplication
$ cd VVC.console24062024.aplication
$ dotnet new console
$ cd ..

// Criar projeto teste
$ dotnet new xunit -n VVC.console24062024.test

// Adicionar projeto teste a Solução.
$ dotnet sln VVC.console24062024.sln add VVC.console24062024.test/VVC.console24062024.test.csproj

// referenciar projetos
$ dotnet add VVC.console24062024.test/VVC.console24062024.test.csproj reference VVC.console24062024.aplication/VVC.console24062024.aplication.csproj


```

# Rodar projeto:
```

Rodar o projeto em dev.
$ dotnet run

Rodar os test.
$ dotnet test

Publicar aplicação.
$ dotnet publish -c Release -o out 

```

# Docker
```
gerar o Imagem do Docker.
$ sudo docker build -t console24062024 -f Dockerfile .

listar Imagens no computador.
$ sudo docker images

Execute o contêiner a partir da imagem criada:
$ sudo docker run -it --name console24062024container2 console24062024

Verifique se o contêiner está rodando:
$ docker ps

parar conteiner
$ sudo docker stop console24062024

```
