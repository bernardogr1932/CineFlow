namespace Cineflow.controller.console;

using CineFlow.model;


public class IngressoController
{
    public List<Ingresso> ingressos;

    public IngressoController()
    {
        ingressos = new List<Ingresso>{};
    }



    public void CriarIngresso()
    {
        Console.Write("Digite o ID da sessão para a qual deseja comprar o ingresso: ");
        int idsessao = int.Parse(Console.ReadLine());

        Console.Write("Digite o número do lugar marcado: ");
        int lugarmarcado = int.Parse(Console.ReadLine());

        Console.Write("Digite o preço do ingresso: ");
        decimal preco = decimal.Parse(Console.ReadLine());

        Ingresso ingresso = new Ingresso(0, idsessao, lugarmarcado, preco);
        ingressos.Add(ingresso);

        Console.WriteLine("Ingresso criado com sucesso!");
    }
}

