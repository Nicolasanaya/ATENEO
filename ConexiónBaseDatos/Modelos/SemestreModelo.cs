using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConexiónBaseDatos.Modelos
{
    public class Semestre
    {
        [Key]
        public int S_Id { get; set; }
        public string S_Nombre { get; set; }
        public List<Programa_Materia_Semestre> S_Programas_Materias_Semestres { get; set; }
    }
}
