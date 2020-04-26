using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConexiónBaseDatos.Modelos
{
    public class Horario
    {
        [Key]
        public int H_Is { get; set; }
        public Tipo_Horario Tipos_Horarios { get; set; }
        public List<Usuario_Horario> H_Usuarios_Horarios { get; set; }
        public List<Horario_Materia> H_Horarios_Materias { get; set; }
    }
}
