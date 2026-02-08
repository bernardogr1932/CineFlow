using System.Text;

namespace CineFlow.model;


public class Filme
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public int DuracaoMinutos { get; set; }
    public string Genero { get; set; }





    public Filme()
    {
        Id = 0;
        Titulo = "";
        DuracaoMinutos = 0;
        Genero = "";
    }

    public Filme(int id, string titulo, int duracaoMinutos, string genero)
    {
        Id = id;
        Titulo = titulo;
        DuracaoMinutos = duracaoMinutos;
        Genero = genero;
    }





    public virtual string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("ID: ");
        sb.Append(Id);
        sb.Append(Environment.NewLine);
        sb.Append(", Título: ");
        sb.Append(Titulo);
        sb.Append(Environment.NewLine);
        sb.Append(", Duração: ");
        sb.Append(DuracaoMinutos);
        sb.Append(Environment.NewLine);
        sb.Append(" minutos, Gênero: ");
        sb.Append(Genero);
        return sb.ToString();
    }

}