namespace CineFlowAPI.service.api;

using CineFlowAPI.model;
using CineFlowAPI.controller.api;
using CineFlowAPI.Data;

public class SalaService
{
    private readonly AppDbContext _context;






    public SalaService(AppDbContext context)
    {
        _context = context;

    }




    public List<Sala> ListarSalas()
    {
        return _context.Salas.ToList();
    }


    public Sala BuscarSalaPorId(int id)
    {
        return _context.Salas.FirstOrDefault(s => s.Id == id);
    }


    public Sala CadastrarSala(Sala sala)
    {



        if (string.IsNullOrWhiteSpace(sala.Nome))
            throw new ArgumentException("Nome da sala não pode ser vazio.");

        if (sala.CapacidadeTotal <= 0)
            throw new ArgumentException("Capacidade da sala deve ser maior que zero.");




        _context.Salas.Add(sala);
        _context.SaveChanges();


        return sala;
    }

    public void RemoverSala(int id)
    {
        var sala = _context.Salas.Find(id);
        if (sala == null)
            throw new ArgumentException("Sala não encontrada.");

        bool existeSessao = _context.Sessoes.Any(s => s.SalaId == id);
        if (existeSessao)
            throw new ArgumentException("Não é possível remover a sala, pois existem sessões cadastradas para ela.");

        _context.Salas.Remove(sala);
        _context.SaveChanges();
    }

}