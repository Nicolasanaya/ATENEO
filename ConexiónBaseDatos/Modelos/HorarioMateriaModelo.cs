using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConexiónBaseDatos.Modelos
{
    public class Horario_Materia
    {
        [Key]
        public int Horarios_Materias_Id { get; set; }
        public Horario Horarios { get; set; }
        public Materia Materias { get; set; }
    }
}
