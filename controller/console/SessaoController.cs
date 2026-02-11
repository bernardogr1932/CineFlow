namespace CineFlow.controller.console;

using Cineflow.controller.console;

using model;

public class SessaoController
{

    SalaController salacontroller;
    public List<Sessao> sessoes;
    private FilmeController _filmecontroller;
    private SalaController _salacontroller;
    private readonly IngressoController _ingressocontroller;



    public SessaoController(FilmeController filmecontroller, SalaController salacontroller, IngressoController ingressocontroller)
    {
        _filmecontroller = filmecontroller;
        _salacontroller = salacontroller;
        _ingressocontroller = ingressocontroller;
        sessoes = new List<Sessao> { };

        sessoes = new List<Sessao> { };
    }
    public void CriarSessao(FilmeController filmecontroller, SalaController salacontroller)
    {
        filmecontroller.ListarFilmes();

        Console.Write("Digite o ID do filme que deseja exibir: ");
        int idfilme = int.Parse(Console.ReadLine() ?? "0");
        salacontroller.ListarSalas();
        Console.Write("Digite o ID da sala onde a sessão será exibida: ");
        int idsala = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Digite a data e hora da sessão (formato: dd/MM/yyyy HH:mm): ");
        DateTime datainicio = DateTime.Parse(Console.ReadLine() ?? "");

        Filme? filme = _filmecontroller.filmes.FirstOrDefault(f => f.Id == idfilme);
        if (filme == null)
        {
            Console.WriteLine("Filme não encontrado.");
            return;
        }
        DateTime datafim = datainicio.AddMinutes(filme.DuracaoMinutos);
        bool Conflito = sessoes.Any(sessao =>
            sessao.SalaId == idsala &&
            sessao.DataHoraInicio.Date == datainicio.Date &&
            ((datainicio >= sessao.DataHoraInicio && datainicio < sessao.DataHoraFim) ||
             (datafim > sessao.DataHoraInicio && datafim <= sessao.DataHoraFim) ||
             (datainicio <= sessao.DataHoraInicio && datafim >= sessao.DataHoraFim)));


        if (Conflito)
        {
            Console.WriteLine("Não é possível criar a sessão devido a um conflito de horário na sala.");
            return;
        }
        else
        {
            int id = sessoes.Count > 0 ? sessoes.Max(s => s.Id) + 1 : 1;
            Sessao novaSessao = new Sessao(id, idfilme, idsala, datainicio, datafim, 0, false);
            sessoes.Add(novaSessao);
            Console.WriteLine(novaSessao.ToString());
            Console.WriteLine("Sessão criada com sucesso!");
        }
    }


    public void RemoverSessao(IngressoController ingressocontroller)
    {
        ListarSessoes();
        Console.Write("Digite o ID da sessão a ser removida: ");
        int id = int.Parse(Console.ReadLine() ?? "0");

        bool ExisteIngresso = ingressocontroller.ingressos.Any(i => i.SessaoId == id);
        if (ExisteIngresso)
        {
            Console.WriteLine("Não é possível remover a sessão, pois existem ingressos vendidos para ela.");
            return;
        }

        Sessao? sessaoremover = sessoes.FirstOrDefault(s => s.Id == id);

        if (sessaoremover != null)
        {
            sessoes.Remove(sessaoremover);
            Console.WriteLine("Sessão removida com sucesso!");
        }
        else
        {
            Console.WriteLine("Sessão não encontrada.");
        }
    }

    public void ListarSessoes()
    {
        Console.WriteLine("=== Lista de Sessões ===");
        foreach (var sessao in sessoes)
        {
            Console.WriteLine(sessao.ToString());
        }
    }



    public void Lotacao(int salaid, int idsessao)
    {
        foreach (var sala in salacontroller.salas)
        {
            if (sala.Id == salaid)
            {
                foreach (var sessao in sessoes)
                {
                    if (sessao.Id == idsessao)
                    {
                        if (sessao.LotacaoAtual < sala.CapacidadeTotal)
                        {
                            sessao.LotacaoAtual++;
                            Console.WriteLine("Ingresso vendido! Lotação atual: " + sessao.LotacaoAtual);
                        }
                        else
                        {
                            sessao._Lotado = true;
                            Console.WriteLine("Não é possível vender o ingresso. A sala está lotada.");
                        }
                    }
                }

            }
        }
    }
}