namespace CineFlowAPI.service.api;

using CineFlowAPI.Data;
using CineFlowAPI.model;


public class FilmeService
{
    private readonly AppDbContext _context;


    public FilmeService(AppDbContext context)
    {
        _context = context;



    }


    public List<Filme> ListarFilmes()
    {
        return _context.Filmes.ToList();
    }




    public Filme CadastrarFilme(Filme filme)
    {
        if (string.IsNullOrWhiteSpace(filme.Titulo))
            throw new ArgumentException("Título do filme não pode ser vazio.");
        if (filme.DuracaoMinutos <= 0)
            throw new ArgumentException("Duração deve ser maior que zero.");


        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return filme;


    }


    public void RemoverFilme(int id)
    {
        var filme = _context.Filmes.Find(id);
        if (filme == null)
            throw new ArgumentException("Filme não encontrado.");

        bool existeSessao = _context.Sessoes.Any(s => s.FilmeId == id);
        if (existeSessao)
            throw new ArgumentException("Não é possível remover o filme, pois existem sessões cadastradas para ele.");

        _context.Filmes.Remove(filme);
        _context.SaveChanges();
    }





}