using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConexiónBaseDatos.Modelos
{
    public class Tipo_Usuario
    {
        [Key]
        public int TU_Id { get; set; }
        [Required]
        public string TU_Identificador { get; set; }
        public List<Usuario> TU_Usuarios { get; set; }
    }
}
