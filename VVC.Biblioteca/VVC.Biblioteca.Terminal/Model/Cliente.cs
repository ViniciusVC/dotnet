using System.ComponentModel.DataAnnotations;

// Modelo de dados da tabela Livro usando DataAnnotations
namespace VVC.Biblioteca.Terminal{

    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(14)]
        public string CliCPF { get; set; }

        [Required]
        [StringLength(200)]
        public string CliNome { get; set; }

        [Required]
        [StringLength(200)]
        public string CliEndereco { get; set; }

        [Required]
        [StringLength(100)]
        public string CliCidade { get; set; }

        [Required]
        [StringLength(100)]
        public string CliBairro { get; set; }

        [Required]
        [StringLength(50)]
        public string CliNumero { get; set; }

        [StringLength(14)]
        public string CliTelefoneCelular { get; set; }

        [StringLength(14)]
        public string CliTelefoneFixo { get; set; }

        [StringLength(100)]
        public string CliEmail { get; set; }
    }

}

/*
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

    [Key] indica que a propriedade Id é a chave primária da tabela.
    [Required] indica que a propriedade é obrigatória e não pode ser nula.
    [StringLength(x)] indica que a propriedade é uma string com um comprimento máximo de x caracteres.
*/