using Backend.Domain.Entities;
using Backend.Infrastructure.TablesDefinition;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.EntitiesConfiguration
{
    // Configuração da entidade "ColaboradoresEntity"
    public class ColaboradoresEntityConfiguration : IEntityTypeConfiguration<ColaboradoresEntity>
    {

        public void Configure(EntityTypeBuilder<ColaboradoresEntity> builder)
        {
            // Configuração da tabela "Colaboradores"
            TablesInfo tableInfo = Tables.ColaboradoresTable;
            builder.ToTable(tableInfo.Nome, b => b.HasComment(tableInfo.Descrição));

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Nome")
                .HasComment("Nome do colaborador");
            builder.HasIndex(c => c.Nome);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Email")
                .HasComment("Email do colaborador");

            builder.Property(c => c.Cargo)
                .HasMaxLength(50)
                .HasColumnName("Cargo")
                .HasComment("Cargo do colaborador");

            builder.Property(c => c.Telefone)
                .HasMaxLength(20)
                .HasColumnName("Telefone")
                .HasComment("Telefone do colaborador");

            builder.Property(c => c.Admissao)
                .HasColumnName("Admissao")
                .HasComment("Data de admissão do colaborador");

            builder.Property(c => c.Ativo)
                .IsRequired()
                .HasColumnName("Ativo")
                .HasComment("Indica se o colaborador está ativo ou não");
        }
    }
}