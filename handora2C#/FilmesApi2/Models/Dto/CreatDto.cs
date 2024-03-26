using System.ComponentModel.DataAnnotations;

namespace Models.Dto.Filme;
public class CreateDto
{
     
    [Required(ErrorMessage = "O titulo do filme é obrigátio")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O genero do filme é obrigátio")]
    [MaxLength(50, ErrorMessage ="O tamanho do filme não pode ser maior que 50 caracteres" )]
    public string Genero { get; set; }

    [Required]
    [Range(70,600, ErrorMessage = "A duração deve ter entr 60  e 600 min")]
    public int Duraçao { get; set; }
}