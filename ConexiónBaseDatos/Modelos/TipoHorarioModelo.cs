using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConexiónBaseDatos.Modelos
{
    public class Tipo_Horario
    {
        [Key]
        public int TH_Id { get; set; }
        public string TH_Identificador { get; set; }
        public List<Horario> TH_Horarios { get; set; }
    }
}
