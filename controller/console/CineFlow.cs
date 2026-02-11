using System.Diagnostics;
using CineFlow.model;
using Cineflow.controller.console;

namespace CineFlow.controller.console;

public class CineFlow
{


    private SessaoController sessaocontroller;
    private FilmeController filmecontroller;
    private IngressoController ingressocontroller;
    private SalaController salacontroller;
    private MenuController menucontroller;

    public CineFlow()
    {

        filmecontroller = new FilmeController(sessaocontroller);
        salacontroller = new SalaController(sessaocontroller);
        sessaocontroller = new SessaoController(filmecontroller, salacontroller, ingressocontroller);
        ingressocontroller = new IngressoController(sessaocontroller, salacontroller);
        menucontroller = new MenuController(sessaocontroller, filmecontroller, ingressocontroller, salacontroller);

    }

    static void Main(string[] args)
    {
        CineFlow app = new CineFlow();
        app.Executar();

    }




    public void Executar()
    {
        while (menucontroller._executando)
        {
            menucontroller.MostrarMenu();
            int opcao = menucontroller.LerOpcao();
            menucontroller.ProcessarOpcao(opcao);
        }
    }
}