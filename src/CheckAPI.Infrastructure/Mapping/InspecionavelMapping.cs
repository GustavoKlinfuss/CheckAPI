using CheckAPI.Domain.Configuracoes.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CheckAPI.Infrastructure.Mapping
{
    public class InspecionavelMapping : IEntityTypeConfiguration<Inspecionavel>
    {
        public void Configure(EntityTypeBuilder<Inspecionavel> builder)
        {
            builder.ToTable("inspecionaveis");

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
                .Property(x => x.Titulo)
                .HasColumnName("titulo")
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.Descricao)
                .HasColumnName("descricao")
                .HasColumnType("varchar(256)");

            builder
                .Property(x => x.TipoPreenchimento)
                .HasColumnName("tipo_preenchimento")
                .HasColumnType("tinyint");

            builder
                .Property(x => x.IdConfiguracaoInspecao)
                .HasColumnName("id_configuracao_inspecao")
                .HasColumnType("UNIQUEIDENTIFIER");

            builder
                .HasOne(x => x.ConfiguracaoInspecao)
                .WithMany(x => x.Inspecionaveis)
                .HasForeignKey(x => x.IdConfiguracaoInspecao);
        }
    }
}
