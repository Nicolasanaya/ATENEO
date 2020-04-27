using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConexiónBaseDatos.Modelos
{
    public class CantidadCupos
    {
        [Key]
        public int CACU_Id { get; set; }
        public int CACU_Numero { get; set; }
        public List<Horario> Horario { get; set; }
    }
}
