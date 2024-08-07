using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace VVC.CursoRazorPages.Models
{
    public class Curso
    {
        [Key]
        [DisplayName("Id")]
        public int Id {get; set;} // O ID é a chave. 

        [Required(ErrorMessage = "Informe o titulo do Curso")] // campo obrigatorio
        [StringLength(80, ErrorMessage = "O titulo deve conter até 80 caracteres")]
        [MinLength(5, ErrorMessage = "O titulo deve conter pelo menos 5 caracteres")]
        [DisplayName("Título")]
        public string Titulo {get; set;} = string.Empty;

        [DataType(DataType.DateTime)]
        //[GreaterThanToday]
        [DisplayName("Inicio")]
        public DateTime StartDate {get; set;}

        [DataType(DataType.DateTime)]
        [DisplayName("Termino")]
        public DateTime EndDate {get; set;}


        [DisplayName("Aluno")]
        [Required(ErrorMessage = "Aluno inválido")] // campo obrigatorio
        public int AlunoId {get; set;}

        public Aluno? Aluno {get; set;}

    }
}