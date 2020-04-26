using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConexiónBaseDatos.Modelos
{
    public class Usuario_Horario
    {
        [Key]
        public int Usuarios_Horarios_Id { get; set; }
        public Usuario Usuarios { get; set; }
        public Horario Horarios { get; set; }
    }
}
