using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projeto_FourTask___Avaliação_Final.Models;

namespace Projeto_FourTask___Avaliação_Final.Areas.Identity.Data;

public class IdentidadeContext : IdentityDbContext<Usuario>
{

    //aqui foi criando o indentity para fazer login do usuario e registro
    public DbSet<Equipe> Equipes { get; set; }
    public DbSet<Tarefa> Tarefas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    public IdentidadeContext(DbContextOptions<IdentidadeContext> options)
        : base(options)
    {
    }


    //os relacionamentos
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder
            .Entity<Tarefa>()       //aqui uma tarefa tem um usuario e esse usuario tem muitas tarefas
            .ToTable(nameof(Tarefa))
            .HasOne(x => x.Usuario)
            .WithMany(x => x.Tarefas)
            .IsRequired(false);

        builder
            .Entity<Equipe>()       //aqui uma equipe tem muitos usuarios e um usuario tem uma equipe
            .ToTable(nameof(Equipe))
            .HasMany(x => x.Usuarios)
            .WithOne(x => x.Equipe)
            .IsRequired(false);

        builder
            .Entity<Equipe>()
            .HasKey(x => x.EquipeId);

        builder
            .Entity<Equipe>()       //equipe tem muitas tarefas e tarefa tem uma equipe
            .HasMany(x => x.Tarefas)
            .WithOne(x => x.Equipe);

        builder
            .Entity<Tarefa>()
            .HasKey(x => x.TarefaId);

        builder
            .Entity<Tarefa>()       //tarefa tem um usuario que tem muitas tarefas
            .HasOne(x => x.Usuario)
            .WithMany(x => x.Tarefas);
    }
}
