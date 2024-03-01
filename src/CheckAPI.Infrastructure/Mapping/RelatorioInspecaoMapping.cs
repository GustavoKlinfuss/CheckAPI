using CheckAPI.Domain.Inspecoes.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CheckAPI.Infrastructure.Mapping
{
    public class RelatorioInspecaoMapping : IEntityTypeConfiguration<RelatorioDeInspecao>
    {
        public void Configure(EntityTypeBuilder<RelatorioDeInspecao> builder)
        {
            builder.ToTable("relatorios_inspecao");

            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("UNIQUEIDENTIFIER");

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
                .Property(x => x.InspecaoId)
                .HasColumnName("id_inspecao")
                .HasColumnType("UNIQUEIDENTIFIER");

            builder
                .Property(x => x.Titulo)
                .HasColumnName("titulo")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder
                .Property(x => x.Valor)
                .HasColumnName("valor")
                .HasColumnType("varchar(512)")
                .IsRequired();

            builder
                .Property(x => x.Observacao)
                .HasColumnName("observacao")
                .HasColumnType("varchar(512)");
        }
    }
}
