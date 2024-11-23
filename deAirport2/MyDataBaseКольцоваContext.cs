using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace deAirport2;

public partial class MyDataBaseКольцоваContext : DbContext
{
    public MyDataBaseКольцоваContext()
    {
    }

    public MyDataBaseКольцоваContext(DbContextOptions<MyDataBaseКольцоваContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Авиакомпании> Авиакомпанииs { get; set; }

    public virtual DbSet<Билеты> Билетыs { get; set; }

    public virtual DbSet<Пассажиры> Пассажирыs { get; set; }

    public virtual DbSet<Рейсы> Рейсыs { get; set; }

    public virtual DbSet<Самолеты> Самолетыs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=C:\\Users\\Andrey\\source\\repos\\MyDataBase_Кольцова.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Авиакомпании>(entity =>
        {
            entity.HasKey(e => e.КодАвиакомпании);

            entity.ToTable("Авиакомпании");

            entity.Property(e => e.КодАвиакомпании).ValueGeneratedNever();
        });

        modelBuilder.Entity<Билеты>(entity =>
        {
            entity.HasKey(e => e.НомерБилета);

            entity.ToTable("Билеты");

            entity.Property(e => e.НомерБилета).ValueGeneratedNever();
            entity.Property(e => e.Стоимость).HasColumnType("NUMERIC");

            entity.HasOne(d => d.КодПассажираNavigation).WithMany(p => p.Билетыs).HasForeignKey(d => d.КодПассажира);

            entity.HasOne(d => d.НомерРейсаNavigation).WithMany(p => p.Билетыs).HasForeignKey(d => d.НомерРейса);
        });

        modelBuilder.Entity<Пассажиры>(entity =>
        {
            entity.HasKey(e => e.КодПассажира);

            entity.ToTable("Пассажиры");

            entity.Property(e => e.КодПассажира).ValueGeneratedNever();
            entity.Property(e => e.ДатаРождения).HasColumnType("INTEGER");
            entity.Property(e => e.ФиоПассажира).HasColumnName("ФИО_Пассажира");
        });

        modelBuilder.Entity<Рейсы>(entity =>
        {
            entity.HasKey(e => e.НомерРейса);

            entity.ToTable("Рейсы");

            entity.HasOne(d => d.КодАвиакомпанииNavigation).WithMany(p => p.Рейсыs).HasForeignKey(d => d.КодАвиакомпании);

            entity.HasOne(d => d.КодСамолетаNavigation).WithMany(p => p.Рейсыs).HasForeignKey(d => d.КодСамолета);
        });

        modelBuilder.Entity<Самолеты>(entity =>
        {
            entity.HasKey(e => e.КодСамолета);

            entity.ToTable("Самолеты");

            entity.Property(e => e.КодСамолета).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
