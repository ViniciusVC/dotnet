using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VVC.CursoRazorPages.Models;

namespace VVC.SisCTRazorPages.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Referenci as tabelas.
    public DbSet<Aluno> Alunos { get; set; } = default!; 
    public DbSet<Curso> Cursos { get; set; } = default!;
}
