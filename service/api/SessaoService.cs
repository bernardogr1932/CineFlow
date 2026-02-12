using CineFlowAPI.model;
using CineFlowAPI.Data;
using Microsoft.EntityFrameworkCore;
namespace CineFlowAPI.service.api;


using CineFlowAPI.DTOs;

public class SessaoService
{

    private readonly AppDbContext _context;




    public SessaoService(AppDbContext context)
    {
        _context = context;
    }

    public Sessao CriarSessao(Sessao sessao)
    {



        if (sessao.FilmeId <= 0)
            throw new ArgumentException("ID do filme deve ser maior que zero.");

        if (sessao.SalaId <= 0)
            throw new ArgumentException("ID da sala deve ser maior que zero.");
        if (sessao.DataHoraInicio == default)
            throw new ArgumentException("Data e hora de início da sessão devem ser válidos.");
        sessao.DataHoraFim = sessao.DataHoraInicio.AddMinutes(_context.Filmes.Find(sessao.FilmeId)?.DuracaoMinutos ?? 0);

        bool conflito = _context.Sessoes.Any(s =>
       s.SalaId == sessao.SalaId &&
       sessao.DataHoraInicio.Date == s.DataHoraInicio.Date &&
       ((sessao.DataHoraInicio >= s.DataHoraInicio && sessao.DataHoraInicio < s.DataHoraFim) ||
             (sessao.DataHoraFim > s.DataHoraInicio && sessao.DataHoraFim <= s.DataHoraFim) ||
             (sessao.DataHoraInicio <= s.DataHoraInicio && sessao.DataHoraFim >= s.DataHoraFim)));

        if (conflito)
            throw new ArgumentException("Conflito de horário com outra sessão na mesma sala.");

        var sala = _context.Salas.Find(sessao.SalaId);
        if (sala == null)
            throw new ArgumentException("Sala não encontrada.");

        sessao.LotacaoAtual = 0;

        _context.Sessoes.Add(sessao);
        _context.SaveChanges();

        return sessao;
    }






    public List<Sessao> ListarSessoes()
    {
        return _context.Sessoes
            .Include(s => s.Filme)
            .Include(s => s.Sala)
            .ToList();
    }

    public void RemoverSessao(int id)
    {
        var sessao = _context.Sessoes.Find(id);
        if (sessao == null)
            throw new ArgumentException("Sessão não encontrada.");

        bool existeIngresso = _context.Ingressos.Any(i => i.SessaoId == id);
        if (existeIngresso)
            throw new ArgumentException("Não é possível remover a sessão, pois existem ingressos vendidos para ela.");

        _context.Sessoes.Remove(sessao);
        _context.SaveChanges();
    }

    public List<Sessao> FilmesEmCartaz()
{
    DateTime agora = DateTime.Now;
    DateTime dataLimite = agora.AddDays(7);

    return _context.Sessoes
        .Include(s => s.Filme)   // para ter os dados do filme
        .Include(s => s.Sala)    // opcional, se precisar
        .Where(s => s.DataHoraInicio >= agora && s.DataHoraInicio <= dataLimite)
        .OrderBy(s => s.DataHoraInicio)
        .ToList();
}

}