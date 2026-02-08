namespace Cineflow.controller.console;

using System.ComponentModel;
using CineFlow.controller.console;
using CineFlow.model;


public class IngressoController
{
    public List<Ingresso> ingressos;
    Sala sala;
    SessaoController sessaocontroller;
    Sessao sessao;
    SalaController salacontroller;
     
    private SalaController _salacontroller;
    private SessaoController _sessaocontroller;

    public IngressoController(SessaoController sessaocontroller, SalaController salacontroller)
     {
        _sessaocontroller = sessaocontroller;
        _salacontroller = salacontroller;
         ingressos = new List<Ingresso> { };
    
    
        ingressos = new List<Ingresso> { };
    }




    



    
public void CriarIngresso()
    {
        Console.Write("Digite o ID da sessão desejada: ");
        
        
        int sessaoId = int.Parse(Console.ReadLine() ?? "0");
        if (sessaoId <= 0)
        {
            Console.WriteLine("ID de sessão inválido!");
           
            return;
        }
       
        var sessao = _sessaocontroller.sessoes.FirstOrDefault(s => s.Id == sessaoId);
        
        if (sessao == null)
        {
            Console.WriteLine("Sessão não encontrada!");
            
            return;
        }
        
       
        var sala = _salacontroller.salas.FirstOrDefault(s => s.Id == sessao.SalaId);
        
        if (sala == null)
        {
            Console.WriteLine("Sala da sessão não encontrada!");
            Console.ReadKey();
            return;
        }
        
        
        int ingressosVendidos = ingressos.Count(i => i.SessaoId == sessaoId);
        
        if (ingressosVendidos < sala.CapacidadeTotal)
        {
            int novoId = ingressos.Count > 0 ? ingressos.Max(i => i.Id) + 1 : 1;
            Ingresso novoIngresso = new Ingresso(novoId, sessaoId, ingressosVendidos + 1, 25.00m);
            ingressos.Add(novoIngresso);
            
            Console.WriteLine($"Ingresso vendido! Total: {ingressosVendidos + 1}/{sala.CapacidadeTotal}");
            
        
            sessao.LotacaoAtual++;
            if (sessao.LotacaoAtual >= sala.CapacidadeTotal)
            {
                sessao._Lotado = true;
            }
        }
        else
        {
            Console.WriteLine("Sala lotada! Não é possível vender mais ingressos.");
            sessao._Lotado = true;
        }
        
    
    }
}

