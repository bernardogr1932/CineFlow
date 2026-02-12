namespace CineFlowAPI.DTOs;

public class SessaoResponseDto
{
    public int Id { get; set; }
    public int FilmeId { get; set; }
    public int SalaId { get; set; }
    public DateTime DataHoraInicio { get; set; }
    public DateTime DataHoraFim { get; set; }
    public int LotacaoAtual { get; set; }
}