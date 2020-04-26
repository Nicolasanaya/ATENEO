using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConexiónBaseDatos.Modelos
{
    public class Programa
    {
        [Key]
        public int Pro_Id { get; set; }
        public string Pro_Nombre { get; set; }
        public List<Usuario> Pro_Usuarios { get; set; }
        public List<Programa_Materia_Semestre> Pro_Programas_Materias_Semestres { get; set; }
    }
}
