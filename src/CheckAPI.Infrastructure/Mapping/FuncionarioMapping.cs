using CheckAPI.Domain.Inspecoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CheckAPI.Infrastructure.Mapping
{
    public class FuncionarioMapping : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("funcionarios");

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
        }
    }
}
