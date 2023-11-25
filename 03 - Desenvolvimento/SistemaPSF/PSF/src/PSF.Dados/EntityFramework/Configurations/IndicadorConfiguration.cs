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
    public class IndicadorConfiguration : IEntityTypeConfiguration<Indicador>
    {
        public void Configure(EntityTypeBuilder<Indicador> builder)
        {
            builder.ToTable("Indicador", "ProjetoPSF");
            builder.HasKey(f => f.IndicadorId);

            builder
                .Property(f => f.IndicadorId)
                .UseIdentityColumn()
                .HasColumnName("IndicadorId")
                .HasColumnType("int");

            builder
               .Property(f => f.Titulo)
               .HasColumnName("Titulo")
               .HasColumnType("varchar(300)");


            builder
               .Property(f => f.IndicadorTipo)
               .HasColumnName("IndicadorTipo")
               .HasColumnType("int");
            builder
               .Property(f => f.Status)
               .HasColumnName("Status")
               .HasColumnType("bit");
        }
    }
}
