namespace CineFlowAPI.DTOs;

using System.ComponentModel.DataAnnotations;

public class CreateSessaoDto
{
    [Required(ErrorMessage = "Id do filme é obrigatório")]
    public int FilmeId { get; set; }

    [Required(ErrorMessage = "Id da sala é obrigatório")]
    public int SalaId { get; set; }

    [Required(ErrorMessage = "Data e hora de início são obrigatórios")]
    public DateTime DataHoraInicio { get; set; }
}