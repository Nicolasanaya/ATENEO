using ConexiónBaseDatos.Context;
using ConexiónBaseDatos.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encriptar = BCrypt.Net.BCrypt;

namespace ConexiónBaseDatos.Clases
{
    public class UsuarioClase
    {
        #region Crear usuario
        /// <summary>
        /// Se debe ingresar los datos en formato string
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="nombre"></param>
        /// <param name="apellidos"></param>
        /// <param name="correo"></param>
        /// <param name="telefono"></param>
        /// <param name="contraseña"></param>
        /// <param name="tipoUsuario"></param>
        /// <param name="programa"></param>
        /// <returns></returns>
        public static async Task<string> CrearUsuario(string nombre, string apellidos, string correo, string telefono, string contraseña, string tipoUsuario, string programa)
        {
            try
            {
                using (var context = new DBAteneoMySqlContext())
                {
                    var email = context.Usuarios.FirstOrDefault(c => c.U_Correo.Equals(correo));
                    if (email == null)
                    {
                        var tipo = context.Tipos_Usuarios.FirstOrDefault(tp => tp.TU_Identificador.Equals(tipoUsuario));
                        var program = context.Programas.FirstOrDefault(p => p.Pro_Nombre.Equals(programa));
                        var user = new Usuario
                        {
                            U_Nombre = nombre,
                            U_Apellidos = apellidos,
                            U_Correo = correo,
                            U_Telefono = telefono,
                            U_Contraseña = Encriptar.HashPassword(contraseña),
                            Tipos_Usuarios = tipo,
                            Programas = program
                        };
                        context.Usuarios.Add(user);
                        await context.SaveChangesAsync();
                        return "AAU1";
                    }
                    else
                    {
                        return "AAU2";
                    }
                }
            }
            catch (Exception)
            {
                return "EAU1";
            }
        }
        #endregion

        #region Login
        /// <summary>
        /// Ingresar el correo y la contraseña
        /// </summary>
        /// <param name="correo"></param>
        /// <param name="contraseña"></param>
        /// <returns></returns>
        public static async Task<string> ValidarUsuario(string correo, string contraseña)
        {
            try
            {
                using (var context = new DBAteneoMySqlContext())
                {
                    var login = await context.Usuarios.FirstOrDefaultAsync(u => u.U_Correo.Equals(correo));
                    if (login != null)
                    {
                        if (Encriptar.Verify(contraseña, login.U_Contraseña))
                        {
                            return "AAU3";
                        }
                        else
                        {
                            return "AAU4";
                        }
                    }
                    else
                    {
                        return "AAU5";
                    }
                }
            }
            catch (Exception)
            {

                return "EAU2";
            }
        }
        #endregion

        #region Admin

        #endregion
    }
}
