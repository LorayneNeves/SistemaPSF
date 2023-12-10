using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PSF.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSF.Dominio.ValueObjects;

namespace PSF.Dados.EntityFramework.Configurations
{
    public class EventoConfiguration : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.ToTable("Evento", "ProjetoPSF");
            builder.HasKey(f => f.EventoId);

            builder
                .Property(f => f.EventoId)
                .UseIdentityColumn()
                .HasColumnName("EventoId")
                .HasColumnType("int");

            builder
             .Property(f => f.Data)
             .HasColumnName("Data")
             .HasColumnType("DateTime");

            builder
               .Property(f => f.Valor)
               .HasColumnName("Valor")
               .HasColumnType("int");

            builder
              .Property(f => f.IndicadorId)
              .HasColumnName("IndicadorId")
              .HasColumnType("int");

            builder
               .HasOne(c => c.Indicador)
               .WithMany()
               .HasForeignKey(c => c.IndicadorId);

            builder
             .Property(f => f.UsuarioId)
             .HasColumnName("UsuarioId")
             .HasColumnType("int");

            builder
               .HasOne(c => c.Usuario)
               .WithMany()
               .HasForeignKey(c => c.UsuarioId);

         
        } 
    }
}
