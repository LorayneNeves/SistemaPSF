using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSF.Dominio.Entities;

namespace PSF.Dados.EntityFramework.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario", "ProjetoPSF");
            builder.HasKey(f => f.UsuarioId);

            builder
                .Property(f => f.UsuarioId)
                .UseIdentityColumn()
                .HasColumnName("UsuarioId")
                .HasColumnType("int");

            builder
               .Property(f => f.Nome)
               .HasColumnName("Nome")
               .HasColumnType("varchar(100)");

            builder
                .Property(f => f.CPF)
                .HasColumnName("CPF")
                .HasColumnType("char(11)");

            builder
                .Property(f => f.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar(100)");

            builder
                .Property(f => f.Status)
                .HasColumnName("Status")
                .HasColumnType("bit");


            builder
             .Property(f => f.UsuarioTipoId)
             .HasColumnName("EstadoId") // Nome da coluna na tabela "Cidades" que será a FK
             .HasColumnType("int");

            // Define a relação de chave estrangeira com a tabela "Estados"




            builder
            .Property(f => f.UsuarioTipoId)
            .HasColumnName("UsuarioTipoId") // Nome da coluna na tabela "Cidades" que será a FK
            .HasColumnType("int");

           
            

        }
    }
}
