﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Estados> Estados { get; set; }
        public DbSet<Cidades> Cidades { get; set; }

        public Contexto() : base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data source = BANDEIRA, 1434; 
                                    Database = BD044860; 
                                    User ID = RA044860; 
                                    Password = 044860;
                                    TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new CidadeConfiguration());
            modelBuilder.ApplyConfiguration(new EstadoConfiguration());
        }
       // public List<Cidades> ObterCidades()
       // {
         //   return Set<Cidades>().ToList();
      //  }
    }
}
