using CheckAPI.Domain.Configuracoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CheckAPI.Infrastructure.Mapping
{
    public class ConfiguracaoInspecaoMapping : IEntityTypeConfiguration<ConfiguracaoInspecao>
    {
        public void Configure(EntityTypeBuilder<ConfiguracaoInspecao> builder)
        {
            builder.ToTable("configuracoes_inspecao");

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
                .Property(x => x.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(50)");

            builder
                .HasMany(x => x.Inspecionaveis)
                .WithOne(x => x.ConfiguracaoInspecao)
                .HasForeignKey(x => x.IdConfiguracaoInspecao);
        }
    }
}
