using Microsoft.EntityFrameworkCore;
using CineFlowAPI.model;

namespace CineFlowAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Sessao> Sessoes { get; set; }
    public DbSet<Sala> Salas { get; set; }
    public DbSet<Ingresso> Ingressos { get; set; }



}
