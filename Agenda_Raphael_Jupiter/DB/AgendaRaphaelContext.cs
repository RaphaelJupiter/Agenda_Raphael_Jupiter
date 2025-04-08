using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using Agenda_Raphael_Jupiter.DB;

namespace Agenda_Raphael_Jupiter.DB;

public partial class AgendaRaphaelContext : DbContext
{
    public AgendaRaphaelContext()
    {
    }

    public AgendaRaphaelContext(DbContextOptions<AgendaRaphaelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<ReseauxSociaux> ReseauxSociauxes { get; set; }

    public virtual DbSet<TodoList> TodoLists { get; set; }

    public virtual DbSet<Utilisateur> Utilisateurs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=agenda_raphael", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.21-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Idcontacts).HasName("PRIMARY");

            entity.ToTable("contacts");

            entity.Property(e => e.Idcontacts).HasColumnName("idcontacts");
            entity.Property(e => e.Nom)
                .HasMaxLength(255)
                .HasColumnName("nom");
            entity.Property(e => e.Prenom)
                .HasMaxLength(255)
                .HasColumnName("prenom");
            entity.Property(e => e.Telephone)
                .HasMaxLength(20)
                .HasColumnName("telephone");
        });

        modelBuilder.Entity<ReseauxSociaux>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("reseaux_sociaux");

            entity.HasIndex(e => e.UtilisateurId, "utilisateur_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LienProfil)
                .HasMaxLength(255)
                .HasColumnName("lien_profil");
            entity.Property(e => e.Plateforme)
                .HasMaxLength(100)
                .HasColumnName("plateforme");
            entity.Property(e => e.UtilisateurId).HasColumnName("utilisateur_id");
        });

        modelBuilder.Entity<TodoList>(entity =>
        {
            entity.HasKey(e => e.IdtodoList).HasName("PRIMARY");

            entity.ToTable("todo_list");

            entity.Property(e => e.IdtodoList).HasColumnName("idtodo_list");
            entity.Property(e => e.DateLimite)
                .HasColumnType("datetime")
                .HasColumnName("date_limite");
            entity.Property(e => e.Statut)
                .HasColumnType("enum('à faire','en cours','terminé')")
                .HasColumnName("statut");
            entity.Property(e => e.Tache)
                .HasMaxLength(255)
                .HasColumnName("tache");
            entity.Property(e => e.UtilisateurId).HasColumnName("utilisateur_id");
        });

        modelBuilder.Entity<Utilisateur>(entity =>
        {
            entity.HasKey(e => e.Idutilisateurs).HasName("PRIMARY");

            entity.ToTable("utilisateurs");

            entity.Property(e => e.Idutilisateurs).HasColumnName("idutilisateurs");
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .HasColumnName("email");
            entity.Property(e => e.Mdp)
                .HasMaxLength(45)
                .HasColumnName("mdp");
            entity.Property(e => e.Nom)
                .HasMaxLength(45)
                .HasColumnName("nom");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
