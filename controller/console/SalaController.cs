namespace CineFlow.controller.console;
using model;

public class SalaController
{
    private List<Sala> salas;


    public SalaController()
    {
        salas = new List<Sala>
        {
            new Sala(1, "Sala 1", 100),
            new Sala(2, "Sala 2", 150),
            new Sala(3, "Sala 3", 200)
        };
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

}