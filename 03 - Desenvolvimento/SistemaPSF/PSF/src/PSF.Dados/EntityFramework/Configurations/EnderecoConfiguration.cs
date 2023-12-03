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
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco", "ProjetoPSF");
            builder.HasKey(f => f.EnderecoId);

            builder
                   .Property(f => f.EnderecoId)
                   .UseIdentityColumn()
                   .HasColumnName("EnderecoId")
                   .HasColumnType("int");

            builder
                  .Property(f => f.Rua)
                  .HasColumnName("Rua")
                  .HasColumnType("varchar(100)");
            
            builder
                  .Property(f => f.Numero)
                  .HasColumnName("Numero")
                  .HasColumnType("int");
            
            builder
                 .Property(f => f.Cep)
                 .HasColumnName("CEP")
                 .HasColumnType("char(8)");

            builder
                 .Property(f => f.Bairro)
                 .HasColumnName("Bairro") 
                 .HasColumnType("varchar(50)");

            builder
                 .Property(f => f.EstadoId)
                 .HasColumnName("EstadoId") 
                 .HasColumnType("int");
           
            builder
                .HasOne(c => c.Estado) 
                .WithMany() 
                .HasForeignKey(c => c.EstadoId); 
         

            builder
                .Property(f => f.CidadeId)
                .HasColumnName("CidadeId") 
                .HasColumnType("int");

            builder
                .HasOne(c => c.Cidade)
                .WithMany()
                .HasForeignKey(c => c.CidadeId);
        }
    
    }
}
