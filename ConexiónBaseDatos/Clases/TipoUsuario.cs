using ConexiónBaseDatos.Context;
using ConexiónBaseDatos.DTOs;
using ConexiónBaseDatos.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ConexiónBaseDatos.Clases
{
    public class TipoUsuarioClase
    {
        /// <summary>
        /// La clase devulbe la lista de objetos que contiene el identificador de usuario
        /// </summary>
        /// <returns></returns>
        public static List<TipoUsuarioDTOs> ObtenerTipoUsuario()
        {
            using (var context = new DBAteneoMySqlContext())
            {
                var TPDB = context.Tipos_Usuarios.ToList();
                var tipo = new List<TipoUsuarioDTOs>();
                foreach (var item in TPDB)
                {
                    tipo.Add(new TipoUsuarioDTOs() { TP_Identificador = item.TU_Identificador});
                }
                return tipo;
            }
        }
    }
}
