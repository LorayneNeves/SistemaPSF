using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PSF.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSF.Dados.EntityFramework.Configurations
{
    public class CidadeConfiguration : IEntityTypeConfiguration<Cidades>
    {
        public void Configure(EntityTypeBuilder<Cidades> builder)
        {
            builder.ToTable("Cidades", "ProjetoPSF");
            builder.HasKey(f => f.CidadeId);

            builder
                .Property(f => f.CidadeId)
                .UseIdentityColumn()
                .HasColumnName("CidadeId")
                .HasColumnType("int");

            builder
               .Property(f => f.Nome)
               .HasColumnName("Nome")
               .HasColumnType("varchar(50)");

            builder
             .Property(f => f.EstadoId)
             .HasColumnName("EstadoId") // Nome da coluna na tabela "Cidades" que será a FK
             .HasColumnType("int");

            // Define a relação de chave estrangeira com a tabela "Estados"
            builder
                .HasOne(c => c.Estado) // Propriedade de navegação para "Estados"
                .WithMany() // Indique a multiplicidade conforme necessário
                .HasForeignKey(c => c.EstadoId); // Indique a propriedade que é a FK
        }
    
    }
}
