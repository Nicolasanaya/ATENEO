using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConexiónBaseDatos.Modelos
{
    public class Programa_Materia_Semestre
    {
        [Key]
        public int Programas_Materias_Semestres_Id { get; set; }
        public Programa Programas { get; set; }
        public Materia Materias { get; set; }
        public Semestre Semestres { get; set; }
    }
}
