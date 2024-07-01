using System;
using System.Collections.Generic;

namespace VVC.Biblioteca.API.Models;

// Representação da tabela LivroClienteEmprestimo.

public partial class LivroClienteEmprestimo
{
    public int Id { get; set; }

    public int? LceldCliente { get; set; }

    public int? LceldLivro { get; set; }

    public DateTime? LceldEmprestimo { get; set; }

    public DateTime? LceldEntrega { get; set; }

    public ulong? LceldEntregue { get; set; }

    // Foringkey Cliente
    public virtual Cliente? LceldClienteNavigation { get; set; }
 
    // Foringkey Livro
    public virtual Livro? LceldLivroNavigation { get; set; }
}
