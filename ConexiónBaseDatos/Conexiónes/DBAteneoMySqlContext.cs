using ConexiónBaseDatos.Modelos;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.BC;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConexiónBaseDatos.Context
{
    public class DBAteneoMySqlContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=db-ateneo-dev1;user=root;password=ivantorres");
            //optionsBuilder.UseMySQL("server=db-project-ateneo.cl3mygglzjuv.us-east-2.rds.amazonaws.com;database=db_ateneo_dev1;user=admin;password=Ivan_3132291329");
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Tipo_Usuario> Tipos_Usuarios { get; set; }

        public DbSet<Programa> Programas { get; set; }

        public DbSet<Materia> Materias { get; set; }

        public DbSet<Semestre> Semestres { get; set; }

        public DbSet<Horario> Horarios { get; set; }

        public DbSet<Tipo_Horario> Tipos_Horarios { get; set; }

        public DbSet<Usuario_Horario> Usuarios_Horarios { get; set; }

        public DbSet<Horario_Materia> Horarios_Materias { get; set; }

        public DbSet<Programa_Materia_Semestre> Programas_Materias_Semestres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
