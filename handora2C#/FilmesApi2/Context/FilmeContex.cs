using Models.Filme;
using Microsoft.EntityFrameworkCore;

public class FilmeContex : DbContext
{
    public FilmeContex(DbContextOptions<FilmeContex> options)
        : base(options)
    {   
    }

    public DbSet<Filmes> Filmes { get; set; }
}