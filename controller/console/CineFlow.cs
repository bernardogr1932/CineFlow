using System.Diagnostics;
using CineFlow.model;
using Cineflow.controller.console;

namespace CineFlow.controller.console;

class CineFlow
{
    static void Main(string[] args)
    {
        CineFlow cineflow = new CineFlow();
        cineflow._executando = true;
        cineflow.Executar();
    }
    public bool _executando;
    private SessaoController sessaocontroller;
    private FilmeController filmecontroller;
    private IngressoController ingressocontroller;
    private SalaController salacontroller;

    public CineFlow()
    {

        filmecontroller = new FilmeController();
        salacontroller = new SalaController();
        sessaocontroller = new SessaoController(filmecontroller, salacontroller);
        ingressocontroller = new IngressoController(sessaocontroller, salacontroller);

    }

    public enum OpcaoMenu
    {
        Sair = 0,
        CadastrarFilme = 1,
        CadastrarSala = 2,
        CriarSessao = 3,
        CriarIngresso = 4


    }


    public void Executar()
    {
        while (_executando)
        {
            MostrarMenu();
            int opcao = LerOpcao();
            ProcessarOpcao(opcao);
        }
    }



    public void MostrarMenu()
    {
        Console.WriteLine("=== CineFlow - Sistema de Gerenciamento de Cinema ===");
        Console.WriteLine($"{(int)OpcaoMenu.Sair}) Sair");
        Console.WriteLine($"{(int)OpcaoMenu.CadastrarFilme}) Cadastrar Filmes");
        Console.WriteLine($"{(int)OpcaoMenu.CadastrarSala}) Cadastrar Salas");
        Console.WriteLine($"{(int)OpcaoMenu.CriarSessao}) Criar Sessão");
        Console.WriteLine($"{(int)OpcaoMenu.CriarIngresso}) Criar Ingresso");
        Console.Write("Escolha uma opção: ");
    }

    public int LerOpcao()
    {
        int opcao = int.Parse(Console.ReadLine() ?? "");
        return opcao;
    }



    public void ProcessarOpcao(int opcao)
    {

        switch ((OpcaoMenu)opcao)
        {
            case OpcaoMenu.Sair:
                _executando = false;
                Console.WriteLine("Encerrando o sistema. Até logo!");
                break;
            case OpcaoMenu.CadastrarFilme:
                FilmeController filmecontroller = new FilmeController();
                filmecontroller.CadastrarFilme();
                break;
            case OpcaoMenu.CadastrarSala:
                salacontroller.CadastrarSala();
                break;
            case OpcaoMenu.CriarSessao:
                sessaocontroller.CriarSessao();
                break;
            case OpcaoMenu.CriarIngresso:

                ingressocontroller.CriarIngresso();
                break;
            default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
        }
    }
}