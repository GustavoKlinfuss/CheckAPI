using CheckAPI.Domain.Inspecoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CheckAPI.Infrastructure.Mapping
{
    public class InspecaoMapping : IEntityTypeConfiguration<Inspecao>
    {
        public void Configure(EntityTypeBuilder<Inspecao> builder)
        {
            builder.ToTable("inspecoes");

            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("UNIQUEIDENTIFIER")
                .ValueGeneratedNever();

            builder
                .Property(x => x.DataCadastro)
                .HasColumnName("data_cadastro")
                .HasColumnType("datetime")
                .IsRequired();

            builder
                .Property(x => x.DataUltimaModificacao)
                .HasColumnName("data_ultima_modificacao")
                .HasColumnType("datetime");

            builder
                .Property(x => x.Conclusao)
                .HasColumnName("conclusao")
                .HasColumnType("tinyint");

            builder
                .Property(x => x.Status)
                .HasColumnName("status")
                .HasColumnType("tinyint")
                .IsRequired();

            builder
                .Property(x => x.IdExecutor)
                .HasColumnName("id_executor")
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired();

            builder
                .Property(x => x.IdSupervisor)
                .HasColumnName("id_supervisor")
                .HasColumnType("UNIQUEIDENTIFIER");

            builder
                .Property(x => x.IdVeiculo)
                .HasColumnName("id_veiculo")
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired();

            builder
                .HasOne(x => x.Executor)
                .WithMany(x => x.Inspecoes)
                .HasForeignKey(x => x.IdExecutor);

            builder
                .HasOne(x => x.Supervisor)
                .WithMany(x => x.Inspecoes)
                .HasForeignKey(x => x.IdSupervisor);

            builder
                .HasMany(x => x.Relatorios)
                .WithOne(x => x.Inspecao)
                .HasForeignKey(x => x.InspecaoId);

            builder
                .HasOne(x => x.Veiculo)
                .WithMany(x => x.Inspecoes)
                .HasForeignKey(x => x.IdVeiculo);
        }
    }
}
