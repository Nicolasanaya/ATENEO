using ConexiónBaseDatos.Context;
using ConexiónBaseDatos.DTOs;
using ConexiónBaseDatos.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConexiónBaseDatos.Clases
{
    public class Administrador
    {
        #region Traer tipos de usuario
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
                    if (!item.TU_Id.Equals(2))
                    {
                        tipo.Add(new TipoUsuarioDTOs() { TP_Identificador = item.TU_Identificador });
                    }
                }
                return tipo;
            }
        }
        #endregion

        #region Traer lo docentes
        public static List<UsuariosDocentes> ListUsuariosDocente()
        {
            using (var context = new DBAteneoMySqlContext())
            {
                var usuarioDocente = context.Usuarios.Include(es => es.Estados).Include(tp => tp.Tipos_Usuarios).Where(ud => ud.Tipos_Usuarios.TU_Identificador.Equals("Docente"));
                var usuariosDocentes = new List<UsuariosDocentes>();
                foreach (var item in usuarioDocente)
                {
                    usuariosDocentes.Add
                        (new UsuariosDocentes()
                        {
                            Nombre = item.U_Nombre,
                            Apellidos = item.U_Apellidos,
                            Correo = item.U_Correo,
                            Identificador = item.U_Identificador,
                            Telefono = item.U_Telefono,
                            TipoUsuario = item.Tipos_Usuarios.TU_Identificador,
                            Estado = item.Estados.E_Nombre
                        });
                }
                return usuariosDocentes;
            }
        }
        #endregion

        #region Traer estudiantes
        public static List<UsuariosEstudientes> ListUsuariosEstudiante()
        {
            using (var context = new DBAteneoMySqlContext())
            {
                var usuarioDocente = context.Usuarios.Include(es => es.Estados).Include(tp => tp.Tipos_Usuarios).Include(p=>p.Programas).Where(ud => ud.Tipos_Usuarios.TU_Identificador.Equals("Estudiante"));
                var usuariosDocentes = new List<UsuariosEstudientes>();
                foreach (var item in usuarioDocente)
                {
                    usuariosDocentes.Add
                        (new UsuariosEstudientes()
                        {
                            Nombre = item.U_Nombre,
                            Apellidos = item.U_Apellidos,
                            Correo = item.U_Correo,
                            Identificador = item.U_Identificador,
                            Telefono = item.U_Telefono,
                            TipoUsuario = item.Tipos_Usuarios.TU_Identificador,
                            Programa = item.Programas.Pro_Nombre,
                            Estado = item.Estados.E_Nombre
                        });
                }
                return usuariosDocentes;
            }
        }
        #endregion
    }
}
