namespace CineFlow.controller.console;
using model;

public class SalaController
{
    public List<Sala> salas;

    private readonly SessaoController _sessaocontroller;
    
    

    public SalaController(SessaoController sessaocontroller)
    {
        salas = new List<Sala>
        {
            new Sala(1, "Sala 1", 100),
            new Sala(2, "Sala 2", 150),
            new Sala(3, "Sala 3", 200)
        };
        _sessaocontroller = sessaocontroller;
        
    }




    public void ListarSalas()
    {
        foreach (var sala in salas)
        {
            Console.WriteLine(sala.ToString());
        }
    }


    public void BuscarSalaPorId(int idsala)
    {
        foreach (var sala in salas)
        {
            if (sala.Id == idsala)
            {
                Console.WriteLine(sala.ToString());
            }
        }
    }

    public void CadastrarSala()
    {
        try{
        Console.Write("Digite o nome da sala: ");
        string? nome = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome da sala não pode ser vazio.");

        Console.Write("Digite a capacidade da sala: ");
        int capacidade = int.Parse(Console.ReadLine() ?? "0");

        int novoId = salas.Count > 0 ? salas.Max(s => s.Id) + 1 : 1;

        Sala novaSala = new Sala(novoId, nome, capacidade);
        salas.Add(novaSala);

        Console.WriteLine("Sala cadastrada com sucesso!");
    }
    
        catch(ArgumentException ex)
        {
            Console.WriteLine($"Erro de validação: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro Inesperado: {ex.Message}");
        }
    }


    public void RemoverSala(SessaoController sessaocontroller)
{
    Console.Write("Digite o ID da sala a ser removida: ");
    int id = int.Parse(Console.ReadLine() ?? "0");

    bool ExisteSessao = sessaocontroller.sessoes.Any(s => s.SalaId == id);
    if (ExisteSessao)
{
    Console.WriteLine("Não é possível remover a sala, pois existem sessões vinculadas.");
    return;
}

    Sala? salaremover = salas.FirstOrDefault(s => s.Id == id);

    if (salaremover != null)
    {
        salas.Remove(salaremover);
        Console.WriteLine("Sala removida com sucesso!");
    }
    else
    {
        Console.WriteLine("Sala não encontrada.");
    }

}
}