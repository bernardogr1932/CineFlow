using System.ComponentModel.DataAnnotations;

namespace CineFlowAPI.DTOs;

public class CreateFilmeDto
{
    [Required(ErrorMessage = "Título é obrigatório")]
    public string Titulo { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Duração deve ser maior que zero")]
    public int DuracaoMinutos { get; set; }

    [Required(ErrorMessage = "Gênero é obrigatório")]
    public string Genero { get; set; }
}