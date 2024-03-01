using CheckAPI.Domain.Inspecoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CheckAPI.Infrastructure.Mapping
{
    public class VeiculoMapping : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("veiculo");

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
                .Property(x => x.Placa)
                .HasColumnName("placa")
                .HasColumnType("char(7)");

            builder
                .Property(x => x.Ano)
                .HasColumnName("ano")
                .HasColumnType("smallint");

            builder
                .Property(x => x.Modelo)
                .HasColumnName("modelo")
                .HasColumnType("varchar(100)");

            builder
                .Property(x => x.Marca)
                .HasColumnName("marca")
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.Cor)
                .HasColumnName("cor")
                .HasColumnType("varchar(30)");
        }
    }
}
