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
                 .Property(f => f.Status)
                 .HasColumnName("Status")
                 .HasColumnType("bit");

            builder
             .Property(f => f.EnderecoId)
             .HasColumnName("EnderecoId") 
             .HasColumnType("int");

            builder
                .HasOne(c => c.Enderecos)
                .WithMany() 
                .HasForeignKey(c => c.EnderecoId); 
        }
    
    }
}
