namespace CineFlow.controller.console;

using model;
public class FilmeController
{
    public List<Filme> filmes;
    private readonly SessaoController _sessaocontroller;
    public FilmeController(SessaoController sessaocontroller)
    {
        filmes = new List<Filme>
        {
            new Filme(1, "O Poderoso Chefão", 175, "Crime"),
            new Filme(2, "A Origem", 148, "Sci-Fi"),
            new Filme(3, "Pulp Fiction", 154, "Crime")
        };
        _sessaocontroller = sessaocontroller;
    }


    public void ListarFilmes()
    {
        foreach (var filme in filmes)
        {
            Console.WriteLine(filme.ToString());
        }
    }

    public void BuscarFilmePorId(int idfilme)
    {

        foreach (var filme in filmes)
        {
            if (filme.Id == idfilme)
            {
                Console.WriteLine(filme.ToString());

            }
        }
    }


    public void CadastrarFilme()
    {
        try{
        Console.Write("Digite o título do filme: ");
        string? titulo = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(titulo))
            throw new ArgumentException("Título não pode ser vazio.");

        Console.Write("Digite a duração do filme em minutos: ");
        int duracaoMinutos = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Digite o gênero do filme: ");
        string? genero = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(genero))
            throw new ArgumentException("Gênero não pode ser vazio.");

        int novoId = filmes.Count > 0 ? filmes.Max(f => f.Id) + 1 : 1;

        Filme novoFilme = new Filme(novoId, titulo, duracaoMinutos, genero);
        filmes.Add(novoFilme);

        Console.WriteLine("Filme cadastrado com sucesso!");
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



    public void RemoverFilme(SessaoController sessaocontroller)

    
{
    ListarFilmes();

    Console.Write("Digite o ID do filme a ser removido: ");
    int id = int.Parse(Console.ReadLine() ?? "0");

    bool ExisteSessao = sessaocontroller.sessoes.Any(s => s.FilmeId == id);
    if (ExisteSessao)
{
    Console.WriteLine("Não é possível remover o filme, pois existem sessões vinculadas.");
    return;
}

    Filme? filmeremover = filmes.FirstOrDefault(f => f.Id == id);

    if (filmeremover != null)
    {
        filmes.Remove(filmeremover);
        Console.WriteLine("Filme removido com sucesso!");
    }
    else
    {
        Console.WriteLine("Filme não encontrado.");
    }
}

}