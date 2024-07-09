-- Conecte-se ao MySQL
mysql -u root -p

Show databases;

-- Crie um Novo Banco de Dados dbvvcbiblioteca.
CREATE DATABASE dbvvcinvestimentos;

-- selecione o banco de dados. 
use dbvvcinvestimentos;

-- Crie a tabela Cliente.
CREATE TABLE valorAcao (
    id INT AUTO_INCREMENT PRIMARY KEY,
    Sigla VARCHAR(200),
    DataCotacao Date,
    Valor INT
);
-- Nota : Campo valor unidade em centavos (Divida por 100 para obter o valor correto).

-- Verifique se a tabela foi criadada.
SHOW TABLES;

-- Primeiro insert de teste na tabela 
INSERT INTO valorAcao (Sigla, DataCotacao, Valor) VALUES 
('Alphabet BDR', '2024-07-08', 8690);

-- Popular a tabela Cliente.
INSERT INTO valorAcao (Sigla, DataCotacao, Valor) VALUES 
 ('IBM NYSE', '08-07-2024', 17602),
 ('XOM', '08-07-2024', 11337);

-- conferir a carda de dados em Cliente.
select * from valorAcao;


/*
╔═══════════════════════════════
║ Abrindo ações do Google.
║ Capturando valor da ação (Alphabet BDR).
║---------------------------------
║ Valor : 86,90 em 08-07-2024
╚═══════════════════════════════
╔═══════════════════════════════
║ Abrindo ações do IBM.
║ Capturando valor da ação (IBM NYSE).
║---------------------------------
║ Valor : 176,02 em 08-07-2024
╚═══════════════════════════════
╔═══════════════════════════════
║ Abrindo ações do Exxon Mobil Corp..
║ Capturando valor da ação (XOM).
║---------------------------------
║ Valor : 113,37 em 08-07-2024
╚═══════════════════════════════
*/