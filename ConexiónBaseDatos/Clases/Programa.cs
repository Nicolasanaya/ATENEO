using ConexiónBaseDatos.Context;
using ConexiónBaseDatos.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConexiónBaseDatos.Clases
{
    public class ProgramaClase
    {
        /// <summary>
        /// La clase devulbe la lista de objetos que contiene el nombre de los programas
        /// </summary>
        /// <returns></returns>
        public static List<ProgramaDTOs> ObtenerTipoUsuario()
        {
            using (var context = new DBAteneoMySqlContext())
            {
                var prodb = context.Programas.ToList();
                var program = new List<ProgramaDTOs>();
                foreach (var item in prodb)
                {
                    program.Add(new ProgramaDTOs() { Name = item.Pro_Nombre});
                }
                return program;
            }
        }
    }
}
