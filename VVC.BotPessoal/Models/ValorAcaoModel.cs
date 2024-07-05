using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations; // Necessário para usar as taks []
using System.ComponentModel; // Necessário para classe modelo de dados

namespace VVCBotPessoal
{
    public partial class ValorAcaoModel
    {
        [Key]
        [DisplayName("Id")]
        public int Id {get; set;} // O ID é a chave. 

        [Required]
        [DisplayName("Nome da Acao")]
        [StringLength(200)]
        public string? NomeAcao { get; set; }
        
        [Required]
        [DisplayName("Data da Cotacao")]
        public DateTime? DataCotacao { get; set; }

        [Required]
        [DisplayName("valor")]
        public decimal valor { get; set; }

    }
}