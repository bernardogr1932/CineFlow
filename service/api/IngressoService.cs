namespace CineFlowAPI.service.api;

using CineFlowAPI.Data;
using Microsoft.EntityFrameworkCore;
using CineFlowAPI.model;
using CineFlowAPI.controller.api;
public class IngressoService
{
    private readonly AppDbContext _context;



    public IngressoService(AppDbContext context)
    {

        _context = context;



    }




    public List<Ingresso> ListarIngressos()
    {
        return _context.Ingressos
            .Include(i => i.Sessao)
                .ThenInclude(s => s.Filme)
            .Include(i => i.Sessao)
                .ThenInclude(s => s.Sala)
            .ToList();
    }

    public Ingresso CriarIngresso(Ingresso ingresso)
    {



        if (ingresso.SessaoId <= 0)
            throw new ArgumentException("ID da sessão deve ser maior que zero.");
        if (ingresso.LugarMarcado <= 0)
            throw new ArgumentException("Lugar marcado deve ser maior que zero.");
        if (ingresso.Preco <= 0)
            throw new ArgumentException("Preço do ingresso deve ser maior que zero.");



        var sessao = _context.Sessoes
            .Include(s => s.Sala)
            .FirstOrDefault(s => s.Id == ingresso.SessaoId);

        if (sessao == null)
            throw new ArgumentException("Sessão não encontrada.");

        if (sessao.LotacaoAtual >= sessao.Sala.CapacidadeTotal)
            throw new ArgumentException("Sessão lotada. Não é possível adicionar mais ingressos.");

        bool LugarOcupado = _context.Ingressos.Any(i => i.SessaoId == ingresso.SessaoId && i.LugarMarcado == ingresso.LugarMarcado);
        if (LugarOcupado)
            throw new ArgumentException("Lugar já ocupado.");

        sessao.LotacaoAtual++;

        _context.Ingressos.Add(ingresso);
        _context.SaveChanges();

        return ingresso;
    }

    public void RemoverIngresso(int id)
    {
        var ingresso = _context.Ingressos.Find(id);
        if (ingresso == null)
            throw new ArgumentException("Ingresso não encontrado.");


        var sessao = _context.Sessoes.Find(ingresso.SessaoId);
        sessao.LotacaoAtual--;

        _context.Ingressos.Remove(ingresso);
        _context.SaveChanges();
    }





}