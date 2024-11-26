using System.ComponentModel.DataAnnotations;

// Modelo de dados da tabela Livro usando DataAnnotations
namespace VVC.Biblioteca.Terminal.Model;

public class Livro
{
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string LivroNome { get; set; }

        [Required]
        [StringLength(200)]
        public string LivroAutor { get; set; }

        [Required]
        [StringLength(100)]
        public string LivroEditora { get; set; }

        [Required]
        public DateTime LivroAnoPublicacao { get; set; }

        [Required]
        [StringLength(50)]
        public string LivroEdicao { get; set; }

}



/*
    -- SQl de criaçã oda tabela Livro.
    CREATE TABLE Livro(
        id INT AUTO_INCREMENT PRIMARY KEY,
        livroNome VARCHAR(200),
        livroAutor VARCHAR(200),
        livroEditora VARCHAR(100),
        livroAnoPublicacao datetime,
        livroEdicao VARCHAR(50)
    );

    [Key] indica que a propriedade Id é a chave primária da tabela.
    [Required] indica que a propriedade é obrigatória e não pode ser nula.
    [StringLength(x)] indica que a propriedade é uma string com um comprimento máximo de x caracteres.
*/