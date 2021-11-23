using AlunosApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlunosApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
         
        }
        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnModelCreating(ModelBuilder modeBuilder)
        {
            modeBuilder.Entity<Aluno>().HasData(
                new Aluno

                {
                    Id = 1,
                    Nome = "Maria da Penha",
                    Email = "maria@gmail.com",
                    Imagem = "https://dowhile.io/_next/image?url=%2Fimages%2Fbuild-the-future-hero.png&w=1920&q=100",
                    Idade = 23
                },
                new Aluno

                {
                    Id = 2,
                    Nome = "Fernando Sorrentino",
                    Email = "fernando@gmail.com",
                    Imagem = "https://dowhile.io/_next/image?url=%2Fimages%2Fbuild-the-future-hero.png&w=1920&q=100",
                    Idade = 39
                }
                );
        }
    }
}
