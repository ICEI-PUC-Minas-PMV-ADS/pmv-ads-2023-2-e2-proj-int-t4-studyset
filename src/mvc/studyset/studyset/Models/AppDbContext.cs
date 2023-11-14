using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace studyset.Models
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Aluno> Usuarios { get; set; }

        public DbSet<Evento> Agenda { get; set; }

        public DbSet<Cronograma> Cronogramas { get; set; }

        public DbSet<Sessao> Sessoes { get; set; }
    }
}
