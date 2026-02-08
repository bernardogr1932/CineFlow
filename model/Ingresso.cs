namespace CineFlow.model;

public class Ingresso
{
    public int Id { get; set; }
    public int SessaoId { get; set; }
    public int LugarMarcado { get; set; }
    public decimal Preco { get; set; }




    public Ingresso()
    {
        Id = 0;
        SessaoId = 0;
        LugarMarcado = 0;
        Preco = 0.0m;
    }


    public Ingresso(int id, int sessaoid, int lugarmarcado, decimal preco)
    {
        Id = id;
        SessaoId = sessaoid;
        LugarMarcado = lugarmarcado;
        Preco = preco;
    }
}