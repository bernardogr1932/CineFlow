using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.OpenApi;
using Microsoft.SqlServer.Server;


namespace CineFlowAPI.model;

public class Sessao
{
    [Key]
    public int Id { get; set; }

    public int FilmeId { get; set; }
    [ForeignKey("FilmeId")]

    [JsonIgnore]
    public Filme Filme { get; set; }
    public int SalaId { get; set; }
    [ForeignKey("SalaId")]

    [JsonIgnore]
    public Sala Sala { get; set; }

    public DateTime DataHoraInicio { get; set; }
    public DateTime DataHoraFim { get; set; }
    public int LotacaoAtual { get; set; }
    public bool Lotado => LotacaoAtual >= (Sala?.CapacidadeTotal ?? 0);


    public Sessao()
    {
        Id = 0;
        FilmeId = 0;
        SalaId = 0;
        DataHoraInicio = DateTime.MinValue;
        DataHoraFim = DateTime.MinValue;
        LotacaoAtual = 0;


    }

    public Sessao(int id, int filmeid, int salaid, DateTime datahorainicio, DateTime datahorafim, int lotacaoatual, bool _lotado)
    {
        Id = id;
        FilmeId = filmeid;
        SalaId = salaid;
        DataHoraInicio = datahorainicio;
        DataHoraFim = datahorafim;
        LotacaoAtual = lotacaoatual;


    }


    public virtual string ToString()
    {
        return $"ID: {Id}, Filme ID: {FilmeId}, Sala ID: {SalaId}, Início: {DataHoraInicio}, Fim: {DataHoraFim}";
    }

}