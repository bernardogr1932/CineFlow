namespace CineFlowApi.DTOs;

using System.ComponentModel.DataAnnotations;

public class CreateSalaDto
{
    [Required(ErrorMessage = "Nome é obrigatório")]
    public string Nome { get; set; }

    [Required]
    [Range(1, 500, ErrorMessage = "Capacidade total deve ser de 1 a 500 pessoas")]
    public int CapacidadeTotal { get; set; }
}