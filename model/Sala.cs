namespace CineFlowAPI.model;

using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Text;
public class Sala
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; }
    public int CapacidadeTotal { get; set; }

    








    public Sala()
    {
        Id = 0;
        Nome = "";
        CapacidadeTotal = 0;

    }


    public Sala(int id, string nome, int capacidadetotal)
    {
        Id = id;
        Nome = nome;
        CapacidadeTotal = capacidadetotal;


    }


    public virtual string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("ID: ");
        sb.Append(Id);
        sb.Append(Environment.NewLine);
        sb.Append(", Nome: ");
        sb.Append(Nome);
        sb.Append(Environment.NewLine);
        sb.Append(", Capacidade Total: ");
        sb.Append(CapacidadeTotal);

        return sb.ToString();
    }

}