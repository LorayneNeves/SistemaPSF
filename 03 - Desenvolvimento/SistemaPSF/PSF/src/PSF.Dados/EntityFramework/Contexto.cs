using Microsoft.EntityFrameworkCore;
using PSF.Dados.EntityFramework.Configurations;
using PSF.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PSF.Dados.EntityFramework
{
    public class Contexto : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public Contexto() : base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data source = 10.107.176.41.14; 
                                    Database = BD044860; 
                                    User ID = RA04486; 
                                    Password = 044860;
                                    TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfigurations());
        }
    }
}
