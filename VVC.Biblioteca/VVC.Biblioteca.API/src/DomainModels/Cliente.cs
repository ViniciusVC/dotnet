using System;
using System.Collections.Generic;

namespace VVC.Biblioteca.API.Models;

// Representação da tabela Cliente.

public partial class Cliente
{
    public int Id { get; set; }

    public string? CliCpf { get; set; }

    public string? CliNome { get; set; }

    public string? CliEndereco { get; set; }

    public string? CliCidade { get; set; }

    public string? CliBairro { get; set; }

    public string? CliNumero { get; set; }

    public string? CliTelefoneCelular { get; set; }

    public string? CliTelefoneFixo { get; set; }

    public string? CliEmail { get; set; }

    public virtual ICollection<LivroClienteEmprestimo> LivroClienteEmprestimos { get; set; } = new List<LivroClienteEmprestimo>();
}
