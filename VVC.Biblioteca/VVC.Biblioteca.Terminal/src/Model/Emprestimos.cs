using System.ComponentModel.DataAnnotations;

// Modelo de dados da tabela Livro usando DataAnnotations
namespace VVC.Biblioteca.Terminal.Model
{

    public class Emprestimo
    {
        [Key]
        public int Id { get; set; }

        public int LceldCliente { get; set; }
        
        public int LceldLivro { get; set; }

        public string LceldEmprestimo { get; set; }

        public string LceldEntrega { get; set; }
        public bool LceldEntregue { get; set; }

        // Infromações do livro emprestado.
        public string livroNome { get; set; }

        // Infromações do Cliente que pegou o livro.
        public string cliCPF { get; set; }
        public string cliNome { get; set; }
    }

}


/*
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

    [Key] indica que a propriedade Id é a chave primária da tabela.
    [Required] indica que a propriedade é obrigatória e não pode ser nula.
    [StringLength(x)] indica que a propriedade é uma string com um comprimento máximo de x caracteres.

-- listar livros emprestados.
select l.id, l.livroNome, c.id, c.cliCPF, c.cliNome, e.LceldEmprestimo  from Cliente c JOIN Livro_Cliente_Emprestimo e ON c.id=e.LceldCliente JOIN Livro l ON e.LceldLivro = l.id WHERE e.LceldEntregue=0 Order By e.LceldEmprestimo;

-- listar livros com um cliente (id=2).
select l.id, l.livroNome, c.id, c.cliCPF, c.cliNome, e.LceldEmprestimo  from Cliente c JOIN Livro_Cliente_Emprestimo e ON c.id=e.LceldCliente JOIN Livro l ON e.LceldLivro = l.id WHERE e.LceldEntregue=0 AND c.id=2 Order By e.LceldEmprestimo;

--Pegar livro emprestimos.
INSERT INTO Livro_Cliente_Emprestimo( LceldCliente, LceldLivro, LceldEmprestimo, LceldEntrega, LceldEntregue) VALUES (1,2,'2019-05-05','2019-06-16',1);

-- Devolver livro (informe o id docliente e o id=4 do livbro=5)
select l.id, l.livroNome, c.id, c.cliCPF, c.cliNome, e.LceldEmprestimo  from Cliente c JOIN Livro_Cliente_Emprestimo e ON c.id=e.LceldCliente JOIN Livro l ON e.LceldLivro = l.id WHERE e.LceldEntregue=0 AND c.id=4 AND l.id=5;
-- Confirme o livro (S).
-- Informar Data de entrega 
Update Livro_Cliente_Emprestimo Set LceldEntrega='2020-05-13', LceldEntregue=true Where LceldCliente=4 AND LceldLivro=5;

*/