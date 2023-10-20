﻿using Microsoft.EntityFrameworkCore;

namespace studyset.Models
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Aluno> Usuarios { get; set; }
    }
}
