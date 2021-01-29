
using CadastroUsuario.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroUsuario.Repository
{
   public class CadastroUsuarioContext:DbContext
    {

        public CadastroUsuarioContext(DbContextOptions<CadastroUsuarioContext> options) : base(options) { }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Sexo> Sexo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
            .HasOne<Sexo>()
            .WithMany()
            .HasForeignKey(p => p.IdSexo);
        }
    }
}
