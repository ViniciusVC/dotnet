# Baichar a imagem do MySQl
> docker pull mysql

ou

> docker pull mysql:5.7

# Rodar contêiner MySQl:
> docker run -e MYSQL_ROOT_PASSWORD=senharoot --name vvc-mysql -d -p 3306:3306 mysql

MYSQL_ROOT_PASSWORD=senharoot : Senha do usuário root é “senharoot”

--name vvc-mysql : Nome do Conteiner.

-d : Rodar em segundo plano.

mysql : Usar a imagem do MySQL

-p 3306:3306 : Porta de acesso externa e interna. Acessar pela porta 1200 a porta 1433 do contêiner

# Parar contêiner MySQl:
> docker stop vvc-mysql

# Verificar o Ip do contêiner:
> docker inspect vvc-mysql

"IPAddress": "172.17.0.2"

# Acessar terminal do MySQL:
> docker exec -it vvc-mysql

# Acessar terminal do MySQL:
> mysql -uroot -p

# Mostrar todos os bancos:
> Show databases;

# Criar um banco:
> create database dbvvclogin;

> USE dbvvclogin:

# Mostra as tabelas do nosso banco:
>Show tables;

# Criar tabela dentro do banco:
>Create  table nome_da_tabela(

-> id int(6) not null auto_increment,
-> nome text(20) not null,
-> idede

# String conection
> Server=127.0.0.1;Port=3306;Database=dbvvclogin;Uid=root;Pwd=senharoot;

# SQL
-- Mostrar bancos existentes no SGBD.
Show databases;

-- Usar o banco dbvvclogin.
use dbvvclogin;

-- Mostrar tabelas existentes no banco dbvvclogin.
show tables;

-- Listar usuarios cadastrdos.
select * from AspNetUsers;


