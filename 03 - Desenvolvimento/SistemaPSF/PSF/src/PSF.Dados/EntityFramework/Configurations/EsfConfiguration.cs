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
    public class EsfConfiguration : IEntityTypeConfiguration<ESF>
    {
        public void Configure(EntityTypeBuilder<ESF> builder)
        {
            builder.ToTable("Esf", "ProjetoPSF");
            builder.HasKey(f => f.EsfId);

            builder
                .Property(f => f.EsfId)
                .UseIdentityColumn()
                .HasColumnName("EsfId")
                .HasColumnType("int");

            builder
                 .Property(f => f.Nome)
                 .HasColumnName("Nome")
                 .HasColumnType("varchar(100)");

            builder
             .Property(f => f.EnderecoId)
             .HasColumnName("EnderecoId") // Nome da coluna na tabela "Cidades" que será a FK
             .HasColumnType("int");

            // Define a relação de chave estrangeira com a tabela "Estados"
            builder
                .HasOne(c => c.Enderecos) // Propriedade de navegação para "Estados"
                .WithMany() // Indique a multiplicidade conforme necessário
                .HasForeignKey(c => c.EnderecoId); // Indique a propriedade que é a FK
        }
    
    }
}
