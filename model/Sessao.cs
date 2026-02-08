namespace CineFlow.model;

public class Sessao
{
    public int Id { get; set; }
    public int FilmeId { get; set; }
    public int SalaId { get; set; }
    public DateTime DataHoraInicio { get; set; }
    public DateTime DataHoraFim { get; set; }
    public int LotacaoAtual { get; set; }
    public bool _Lotado;



    public Sessao()
    {
        Id = 0;
        FilmeId = 0;
        SalaId = 0;
        DataHoraInicio = DateTime.MinValue;
        DataHoraFim = DateTime.MinValue;
        LotacaoAtual = 0;
        _Lotado = false;
    }

    public Sessao(int id, int filmeid, int salaid, DateTime datahorainicio, DateTime datahorafim, int lotacaoatual, bool _lotado)
    {
        Id = id;
        FilmeId = filmeid;
        SalaId = salaid;
        DataHoraInicio = datahorainicio;
        DataHoraFim = datahorafim;
        LotacaoAtual = lotacaoatual;
        _Lotado = _lotado;
    }


public virtual string ToString()
    {
        return $"ID: {Id}, Filme ID: {FilmeId}, Sala ID: {SalaId}, Início: {DataHoraInicio}, Fim: {DataHoraFim}";
    }

}