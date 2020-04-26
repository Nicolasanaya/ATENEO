using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConexiónBaseDatos.Modelos
{
    public class Usuario
    {
        [Key]
        public int U_Id { get; set; }
        [Required]
        public string U_Nombre { get; set; }
        public string U_Apellidos { get; set; }
        public string U_Correo { get; set; }
        public string U_Telefono { get; set; }
        [Required]
        public string U_Contraseña { get; set; }
        public Tipo_Usuario Tipos_Usuarios { get; set; }
        public Programa Programas { get; set; }
        public List<Usuario_Horario> U_Usuarios_Horarios { get; set; }
    }
}
