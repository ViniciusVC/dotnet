using System.ComponentModel.DataAnnotations; // Necessário para usar as taks []
using System.ComponentModel; // Necessário para classe modelo de dados

namespace VVC.CursoRazorPages.Models
{
    public class Aluno
    {
        [Key]
        [DisplayName("Id")]
        public int Id {get; set;} // O ID é a chave. 

        [Required(ErrorMessage = "Informe o nome do aluno.")] // campo obrigatorio
        [StringLength(80, ErrorMessage = "O nome deve conter até 80 caracteres")]
        [MinLength(5, ErrorMessage = "O nome deve conter pelo menos 5 caracteres")]
        [DisplayName("Nome Completo")]
        public string Name {get; set;} = string.Empty;

        [Required(ErrorMessage = "Infrome o e-mail")] // Campo obrigatorio.
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        [DisplayName("E-mail")]
        public string Email {get; set;} = string.Empty;

        // Lista de curssos. Aluno pode ter varios cursos associados.
        public List<Curso> Cursos {get; set;} = new();
    }
}

