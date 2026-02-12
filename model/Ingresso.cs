namespace CineFlowAPI.model;

using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Ingresso
{
    [Key]
    public int Id { get; set; }
    public int SessaoId { get; set; }
    [ForeignKey("SessaoId")]

    [JsonIgnore]
    public Sessao Sessao { get; set; }
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

    public virtual string ToString()
    {
        return $"ID: {Id}, Sessão ID: {SessaoId}, Lugar: {LugarMarcado}, Preço: R${Preco}";
    }
}