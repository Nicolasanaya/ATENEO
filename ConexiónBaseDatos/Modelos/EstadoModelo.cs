using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConexiónBaseDatos.Modelos
{
    public class Estado
    {
        [Key]
        public int E_Id { get; set; }
        public string E_Nombre { get; set; }
        public List<Usuario> Usuario { get; set; }
    }
}
