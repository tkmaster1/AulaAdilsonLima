using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TKMaster.ProjetoAulaAdilson.Core.Domain.Entities;

namespace TKMaster.ProjetoAulaAdilson.Core.Data.EntityConfig
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("cliente");

            builder
                 .Property(c => c.Codigo)
                 .HasColumnName("id");

            builder
                .HasKey(c => c.Codigo);

            builder
               .Property(c => c.Nome)
               .IsRequired()
               .HasColumnName("nome");

            builder
                .Property(c => c.Documento)
                .IsRequired()
                .HasMaxLength(14)
                .HasColumnName("documento");

            builder
                .Property(c => c.TipoPessoa)
                .HasMaxLength(1)
                .HasColumnName("tipo_pessoa");

            builder
                .Property(p => p.Status)
                .IsRequired()
                .HasColumnName("status");

            builder
                .Property(c => c.DataCadastro)
                .IsRequired()
                .HasColumnName("dt_inclusao");

            builder
                .Property(c => c.DataAlteracao)
                .HasColumnName("dt_alteracao");

            builder
                .Property(c => c.DataExclusao)
                .HasColumnName("dt_exclusao");
        }
    }
}
