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
    public class EstadoConfiguration : IEntityTypeConfiguration<Estados>
    {
        public void Configure(EntityTypeBuilder<Estados> builder)
        {
            builder.ToTable("Estados", "ProjetoPSF");
            builder.HasKey(f => f.EstadoId);

            builder
                .Property(f => f.EstadoId)
                .UseIdentityColumn()
                .HasColumnName("EstadoId")
                .HasColumnType("int");

            builder
               .Property(f => f.Nome)
               .HasColumnName("Nome")
               .HasColumnType("varchar(50)");
          
        }
    
    }
}
