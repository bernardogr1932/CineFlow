namespace CineFlowAPI.DTOs;
using System.ComponentModel.DataAnnotations;

public class CreateIngressoDto
{
    [Required(ErrorMessage = "Id da sessão é obrigatório")]
    public int SessaoId { get; set; }

    [Required(ErrorMessage = "Número do assento é obrigatório")]
    public int LugarMarcado { get; set; }

    [Required(ErrorMessage = "Preço é obrigatório")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Preço deve ser maior que zero")]
    public decimal Preco { get; set; }
}