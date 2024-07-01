-- Conecte-se ao MySQL
mysql -u root -p

Show databases;

-- Crie um Novo Banco de Dados dbvvcbiblioteca.
CREATE DATABASE dbvvcbiblioteca;

-- selecione o banco de dados. 
use dbvvcbiblioteca;

-- Crie a tabela Cliente.
CREATE TABLE Cliente (
    id INT AUTO_INCREMENT PRIMARY KEY,
    cliCPF VARCHAR(14),
    cliNome VARCHAR(200),
    cliEndereco VARCHAR(200),
    cliCidade VARCHAR(100),
    cliBairro VARCHAR(100),
    cliNumero VARCHAR(50),
    cliTelefoneCelular VARCHAR(14),
    cliTelefoneFixo VARCHAR(14),
    cliEmail VARCHAR(100)
);

-- Crie a tabela Livro.
CREATE TABLE Livro(
    id INT AUTO_INCREMENT PRIMARY KEY,
    livroNome VARCHAR(200),
    livroAutor VARCHAR(200),
    livroEditora VARCHAR(100),
    livroAnoPublicacao datetime,
    livroEdicao VARCHAR(50)
);

-- Crie a tabela Livro_Cliente_Emprestimo.
CREATE TABLE Livro_Cliente_Emprestimo(
    id INT AUTO_INCREMENT PRIMARY KEY,
    LceldCliente int,
    LceldLivro int,    
    LceldEmprestimo DATE,
    LceldEntrega DATE,
    LceldEntregue bit,
    FOREIGN KEY (LceldCliente) REFERENCES Cliente(id),
    FOREIGN KEY (LceldLivro) REFERENCES Livro(id)
);

-- Verifique se a tabela foi criadada.
SHOW TABLES ;

-- Primeiro insert na tabela Cliente
INSERT INTO Cliente (cliCPF, cliNome, cliEndereco, cliCidade, cliBairro, cliNumero, cliTelefoneCelular, cliTelefoneFixo, cliEmail) VALUES (
'466.490.900-42', 'Pedro Pinto da Pedra', 'Rua das Carmelias Ricas', 'Bumenal', 'Gardenia Azul', '1423', '3132323232', '2141411414', 'pedropedra95@bol.com.br'
)

-- Popular a tabela Cliente.
INSERT INTO Cliente (cliCPF, cliNome, cliEndereco, cliCidade, cliBairro, cliNumero, cliTelefoneCelular, cliTelefoneFixo, cliEmail) VALUES 
 ('355.301.900-42', 'Anderson Albino', 'Rua das Carmelias Ricas', 'Bicas', 'Gardenia Azul', '10', '4139393939', '2141411414', 'pedropedra95@bol.com.br'),
 ('244.302.800-42', 'Bruno Bulgaro', 'Avenida Das Americas', 'Mar de Espanha', 'Baixada', '33', '5137373737', '2121412414', 'bbrunob@gmail.com.br'),
 ('133.303.700-42', 'Carolina Coutinho', 'Rua Canela Pobre', 'Niteroi', 'Santa Azul', '97', '6131313132', '2143433424', 'carolinaGatinha@Globo.com'),
 ('922.304.600-42', 'Darcy do Dado', 'Rua Capitao Braga', 'cataguases', 'Pao Duro', '130', '3032626262', '2141331466', 'cydoda@yahoul.com.br');

-- conferir a carda de dados em Cliente.
select * from Cliente;

-- Carregar dados na tabela Livro
INSERT INTO Livro ( livroNome, livroAutor, livroEditora, livroAnoPublicacao, livroEdicao) VALUES 
('O Senhor dos Anéis: A Sociedade do Anel', 'J.R.R. Tolkien', 'HarperCollins', '1954-01-01 14:30:00' , '1ª edição'),
('1984', 'George Orwell', 'Companhia das Letras', '1949-01-01 14:30:00', '1ª edição'),
('Dom Quixote', 'Miguel de Cervantes', 'Editora 34', '1605-01-01 14:30:00', '1ª edição'), 
('Orgulho e Preconceito', 'Jane Austen', 'Penguin Classics', '1813-01-01 14:30:00', '1ª edição'),
('Cem Anos de Solidão','Gabriel García Márquez', 'Record', '1967-01-01 14:30:00', '1ª edição'),
('O Grande Gatsby', 'F. Scott Fitzgerald', 'Scribner', '1925-01-01 14:30:00', '1ª edição');

select * from Livro;