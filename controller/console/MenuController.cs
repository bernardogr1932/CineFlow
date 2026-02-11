using Cineflow.controller.console;
using CineFlow.model;

namespace CineFlow.controller.console;

public enum OpcaoMenu
{
    Sair = 0,
    CadastrarFilme = 1,
    CadastrarSala = 2,
    CriarSessao = 3,
    CriarIngresso = 4,
    RemoverFilme = 5,
    RemoverSala = 6,
    RemoverSessao = 7,
    CancelarIngresso = 8


}


public class MenuController
{

    public bool _executando;
    private SessaoController _sessaocontroller;
    private FilmeController _filmecontroller;
    private IngressoController _ingressocontroller;
    private SalaController _salacontroller;

    public MenuController(SessaoController sessaocontroller, FilmeController filmecontroller, IngressoController ingressocontroller, SalaController salacontroller)
    {
        _executando = true;
        _sessaocontroller = sessaocontroller;
        _filmecontroller = filmecontroller;
        _ingressocontroller = ingressocontroller;
        _salacontroller = salacontroller;
    }

    public void MostrarMenu()
    {
        Console.WriteLine("=== CineFlow - Sistema de Gerenciamento de Cinema ===");
        Console.WriteLine($"{(int)OpcaoMenu.Sair}) Sair");
        Console.WriteLine($"{(int)OpcaoMenu.CadastrarFilme}) Cadastrar Filmes");
        Console.WriteLine($"{(int)OpcaoMenu.CadastrarSala}) Cadastrar Salas");
        Console.WriteLine($"{(int)OpcaoMenu.CriarSessao}) Criar Sessão");
        Console.WriteLine($"{(int)OpcaoMenu.CriarIngresso}) Criar Ingresso");
        Console.WriteLine($"{(int)OpcaoMenu.RemoverFilme}) Remover Filme");
        Console.WriteLine($"{(int)OpcaoMenu.RemoverSala}) Remover Sala");
        Console.WriteLine($"{(int)OpcaoMenu.RemoverSessao}) Remover Sessão");
        Console.WriteLine($"{(int)OpcaoMenu.CancelarIngresso}) Cancelar Ingresso");
        Console.Write("Escolha uma opção: ");
    }

    public int LerOpcao()
    {
        try
        {
            int opcao = int.Parse(Console.ReadLine() ?? "");
            return opcao;
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro: Entrada inválida. Por favor, digite um número correspondente à opção.");
            return -1;
        }
        catch (OverflowException)
        {
            Console.WriteLine("Erro: Número muito grande. Por favor, digite um número válido.");
            return -1;
        }
    }

    public void ProcessarOpcao(int opcao)
    {
        try
        {
            switch ((OpcaoMenu)opcao)
            {
                case OpcaoMenu.Sair:
                    _executando = false;
                    Console.WriteLine("Encerrando o sistema. Até logo!");
                    break;
                case OpcaoMenu.CadastrarFilme:

                    _filmecontroller.CadastrarFilme();
                    break;
                case OpcaoMenu.CadastrarSala:
                    _salacontroller.CadastrarSala();
                    break;
                case OpcaoMenu.CriarSessao:
                    _sessaocontroller.CriarSessao(_filmecontroller, _salacontroller);
                    break;
                case OpcaoMenu.CriarIngresso:

                    _ingressocontroller.CriarIngresso(_sessaocontroller, _salacontroller);
                    break;
                case OpcaoMenu.RemoverFilme:
                    _filmecontroller.RemoverFilme(_sessaocontroller);
                    break;
                case OpcaoMenu.RemoverSala:
                    _salacontroller.RemoverSala(_sessaocontroller);
                    break;
                case OpcaoMenu.RemoverSessao:
                    _sessaocontroller.RemoverSessao(_ingressocontroller);
                    break;
                case OpcaoMenu.CancelarIngresso:
                    _ingressocontroller.CancelarIngresso(_sessaocontroller);
                    break;
                default:
                    if (opcao != -1)
                    {
                        Console.WriteLine("Opção inválida. Tente novamente.");
                    }
                    break;
            }
        }
        catch (InvalidCastException)
        {
            Console.WriteLine("Erro: Opção inválida. Por favor, escolha uma opção válida do menu.");
        }
    }

}