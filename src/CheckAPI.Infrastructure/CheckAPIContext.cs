﻿using CheckAPI.Domain.Base;
using CheckAPI.Domain.Configuracoes;
using CheckAPI.Domain.Inspecoes;
using CheckAPI.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CheckAPI.Infrastructure
{
    public class CheckAPIContext : DbContext
    {
        public CheckAPIContext()
        {
            ChangeTracker.StateChanged += AtualizarDatas;
            ChangeTracker.Tracked += AtualizarDatas;
        }

        public DbSet<ConfiguracaoInspecao> ConfiguracoesDeInspecao { get; set; }
        public DbSet<Inspecao> Inspecoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Data Source=192.168.1.6,1433;Initial Catalog=master;User ID=sa;Password=sEnh@ComPl&xa;TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InspecaoMapping());
            modelBuilder.ApplyConfiguration(new FuncionarioMapping());
            modelBuilder.ApplyConfiguration(new RelatorioInspecaoMapping());
            modelBuilder.ApplyConfiguration(new VeiculoMapping());

            modelBuilder.ApplyConfiguration(new ConfiguracaoInspecaoMapping());
            modelBuilder.ApplyConfiguration(new InspecionavelMapping());
        }

        public void AtualizarDatas(object? sender, EntityEntryEventArgs e)
        {
            if (e.Entry.Entity is Entity ent && e.Entry.State == EntityState.Modified)
            {
                ent.DataUltimaModificacao = DateTime.Now;
            }
        }
    }
}
