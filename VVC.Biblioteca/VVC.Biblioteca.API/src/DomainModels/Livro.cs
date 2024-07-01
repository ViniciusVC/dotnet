using System;
using System.Collections.Generic;

namespace VVC.Biblioteca.API.Models;

// Representação da tabela Livro.

public partial class Livro
{
    public int Id { get; set; }

    public string? LivroNome { get; set; }

    public string? LivroAutor { get; set; }

    public string? LivroEditora { get; set; }

    public DateTime? LivroAnoPublicacao { get; set; }

    public string? LivroEdicao { get; set; }

    public virtual ICollection<LivroClienteEmprestimo> LivroClienteEmprestimos { get; set; } = new List<LivroClienteEmprestimo>();
}
