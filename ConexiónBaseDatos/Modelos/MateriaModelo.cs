using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConexiónBaseDatos.Modelos
{
    public class Materia
    {
        [Key]
        public int M_Id { get; set; }
        public string M_Nombre { get; set; }
        public List<Programa_Materia_Semestre> M_Programas_Materias_Semestres { get; set; }
        public List<Horario_Materia> M_Horarios_Materias { get; set; }
    }
}
