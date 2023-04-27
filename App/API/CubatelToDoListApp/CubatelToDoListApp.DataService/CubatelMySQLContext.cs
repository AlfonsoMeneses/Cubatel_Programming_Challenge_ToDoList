using System;
using System.Collections.Generic;
using CubatelToDoListApp.DataService.Entities;
using Microsoft.EntityFrameworkCore;

namespace CubatelToDoListApp.DataService;

public partial class CubatelMySQLContext : DbContext
{
    public CubatelMySQLContext()
    {
    }

    public CubatelMySQLContext(DbContextOptions<CubatelMySQLContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Entities.Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseMySql("server=amenesesdb.ch8babiaex5t.us-east-1.rds.amazonaws.com;database=todolistapp;uid=admin;password=auto_4dm1n", ServerVersion.Parse("8.0.28-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.IdItem).HasName("PRIMARY");

            entity.HasIndex(e => e.TaskId, "Fk_Items_Task_Id_idx");

            entity.Property(e => e.IdItem).HasColumnName("idItem");
            entity.Property(e => e.Description)
                .HasMaxLength(45)
                .HasColumnName("description");
            entity.Property(e => e.IsCompleted).HasColumnName("isCompleted");
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .HasColumnName("name");
            entity.Property(e => e.TaskId).HasColumnName("taskId");

            entity.HasOne(d => d.Task).WithMany(p => p.Items)
                .HasForeignKey(d => d.TaskId)
                .HasConstraintName("Fk_Items_Task_Id");
        });

        modelBuilder.Entity<Entities.Task>(entity =>
        {
            entity.HasKey(e => e.IdTask).HasName("PRIMARY");

            entity.Property(e => e.IdTask).HasColumnName("idTask");
            entity.Property(e => e.Description)
                .HasMaxLength(45)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
