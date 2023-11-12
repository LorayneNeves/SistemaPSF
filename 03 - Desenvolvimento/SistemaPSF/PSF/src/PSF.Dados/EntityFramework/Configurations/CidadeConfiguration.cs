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
               .HasColumnName("EstadoId") 
               .HasColumnType("int");

            builder
               .HasOne(c => c.Estado) 
               .WithMany() 
               .HasForeignKey(c => c.EstadoId); 
        }      
    
    }
}
