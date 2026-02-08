using System.Diagnostics;
using CineFlow.model;

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

    public CineFlow()
    {
        
        filmecontroller = new FilmeController();
        sessaocontroller = new SessaoController(filmecontroller);
    }

    public enum OpcaoMenu
    {
        Sair = 0,
        CadastrarFilme = 1,
        GerenciarSalas = 2,
        CriarSessao = 3,
        GerenciarIngressos = 4


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
        Console.WriteLine($"{(int)OpcaoMenu.GerenciarSalas}) Gerenciar Salas");
        Console.WriteLine($"{(int)OpcaoMenu.CriarSessao}) Criar Sessão");
        Console.WriteLine($"{(int)OpcaoMenu.GerenciarIngressos}) Gerenciar Ingressos");
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
            case OpcaoMenu.GerenciarSalas:
                Console.WriteLine("Gerenciando salas...");
                // Lógica para gerenciar salas
                break;
            case OpcaoMenu.CriarSessao:
                sessaocontroller.CriarSessao();
                break;
            case OpcaoMenu.GerenciarIngressos:
                Console.WriteLine("Gerenciando ingressos...");
                // Lógica para gerenciar ingressos
                break;
            default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
        }
    }
}