using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models;

public class Filme
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O Titulo é obrigatorio")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O Genero é obrigatorio")]
    [MaxLength(50, ErrorMessage = "tamanho maximo do genero é 50 caracteres")]
    public string Genero { get; set; }

    [Required(ErrorMessage = "A Duracao é obrigatoria")]
    [Range(70, 600, ErrorMessage = "A Duracao deve ter entre 70 e 600 min")]
    public int Duracao { get; set; }
    
}
