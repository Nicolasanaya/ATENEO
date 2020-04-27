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
        /// Se debe ingresar los datos en formato string, el identificador es el id con el que el usuario esta registrado en la u
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="nombre"></param>
        /// <param name="apellidos"></param>
        /// <param name="correo"></param>
        /// <param name="identificador"></param>
        /// <param name="telefono"></param>
        /// <param name="contraseña"></param>
        /// <param name="tipoUsuario"></param>
        /// <param name="programa"></param>
        /// <returns></returns>
        public static async Task<string> CrearUsuario(string nombre, string apellidos, string correo,int identificador, string telefono, string contraseña, string tipoUsuario, string programa)
        {
            Estado estado;
            try
            {
                using (var context = new DBAteneoMySqlContext())
                {
                    var email = context.Usuarios.FirstOrDefault(c => c.U_Correo.Equals(correo));
                    var Id = context.Usuarios.FirstOrDefault(id => id.U_Identificador.Equals(identificador));
                    if (email == null && Id == null)
                    {
                        if (tipoUsuario.Equals("Docente"))
                        {
                            estado = context.Estados.FirstOrDefault(es => es.E_Nombre.Equals("En espera"));
                        }
                        else
                        {
                            estado = context.Estados.FirstOrDefault(es => es.E_Nombre.Equals("Aprovado"));
                        }
                        var tipo = context.Tipos_Usuarios.FirstOrDefault(tp => tp.TU_Identificador.Equals(tipoUsuario));
                        var program = context.Programas.FirstOrDefault(p => p.Pro_Nombre.Equals(programa));
                        var user = new Usuario
                        {
                            U_Nombre = nombre,
                            U_Apellidos = apellidos,
                            U_Correo = correo,
                            U_Identificador = identificador,
                            U_Telefono = telefono,
                            U_Contraseña = Encriptar.HashPassword(contraseña),
                            Tipos_Usuarios = tipo,
                            Programas = program,
                            Estados = estado
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
                    var login = await context.Usuarios.Include(es => es.Estados).FirstOrDefaultAsync(u => u.U_Correo.Equals(correo));
                    if (login != null)
                    {
                        if (Encriptar.Verify(contraseña, login.U_Contraseña))
                        {
                            if (login.Estados.E_Nombre.Equals("Aprovado"))
                            {
                                return "AAU3";
                            }
                            else if (login.Estados.E_Nombre.Equals("En espera"))
                            {
                                return "AAU6";
                            }
                            else
                            {
                                return "AAU7";
                            }
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
    }
}
