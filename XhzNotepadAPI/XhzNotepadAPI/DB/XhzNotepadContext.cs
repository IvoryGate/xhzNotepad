using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace XhzNotepadAPI.DB;

public partial class XhzNotepadContext : DbContext
{
    public XhzNotepadContext()
    {
    }

    public XhzNotepadContext(DbContextOptions<XhzNotepadContext> options)
        : base(options) 
    {
    }

    public virtual DbSet<Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=14.29.226.117;uid=root;password=@asd123asd456;database=XhzNotepad");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Task>(entity =>
        //{
        //    entity.HasKey(e => e.Id).HasName("PRIMARY");

        //    entity.Property(e => e.Id)
        //        .HasColumnType("datetime")
        //        .HasColumnName("id");
        //    entity.Property(e => e.Task1)
        //        .HasMaxLength(255)
        //        .HasColumnName("task");
        //});

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
