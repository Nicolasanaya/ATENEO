using ConexiónBaseDatos.Clases;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleAteneo
{
    class Program
    {
        static List<string> programas = new List<string>();
        static List<string> typeUser = new List<string>();
        static void Main(string[] args)
        {
            //LlamarTipoUsuarioAdmin();
            LlamarUsuarioEstudiante();
            //LlamarUsuarioDocente();
            //LlamarTipoUsuario();
            //LlamarProgramas();
            //CrearUsuario();
            //Login();

        }

        private static void LlamarUsuarioEstudiante()
        {
            var estudiantes = Administrador.ListUsuariosEstudiante();
            foreach (var item in estudiantes)
            {
                Console.WriteLine(string.Concat("Nombre: ", item.Nombre));
                Console.WriteLine(string.Concat("Apellidos: ", item.Apellidos));
                Console.WriteLine(string.Concat("Correo: ", item.Correo));
                Console.WriteLine(string.Concat("ID: ", item.Identificador));
                Console.WriteLine(string.Concat("Telefono: ", item.Telefono));
                Console.WriteLine(string.Concat("Programa: ", item.Programa));
                Console.WriteLine(string.Concat("Tipo de usuario: ", item.TipoUsuario));
                Console.WriteLine(string.Concat("Estado: ", item.Estado, "\n"));
            }
        }

        private static void LlamarTipoUsuarioAdmin()
        {
            var tipoUsuario = Administrador.ObtenerTipoUsuario();
            foreach (var item in tipoUsuario)
            {
                Console.WriteLine(item.TP_Identificador);
                typeUser.Add(item.TP_Identificador);
            }
            Console.WriteLine("\n\n");
        }

        private static void LlamarUsuarioDocente()
        {
            var docentes = Administrador.ListUsuariosDocente();
            foreach (var item in docentes)
            {
                Console.WriteLine(string.Concat("Nombre: ", item.Nombre));
                Console.WriteLine(string.Concat("Apellidos: ", item.Apellidos));
                Console.WriteLine(string.Concat("Correo: ", item.Correo));
                Console.WriteLine(string.Concat("ID: ", item.Identificador));
                Console.WriteLine(string.Concat("Telefono: ", item.Telefono));
                Console.WriteLine(string.Concat("Tipo de usuario: ", item.TipoUsuario));
                Console.WriteLine(string.Concat("Estado: ", item.Estado, "\n"));
            }
        }

        private static void Login()
        {
            var respuesta = UsuarioClase.ValidarUsuario("leo@hotmail.com", "123456789");
            Console.WriteLine(respuesta.Result);
        }

        private static void CrearUsuario()
        {
            Task.Delay(3000);
            //var respuesta = UsuarioClase.CrearUsuario("leonardo", "Torres Garnica", "leo@hotmail.com",000657963 ,"3132261326", "123456789",typeUser[1],"");
            var respuesta = UsuarioClase.CrearUsuario("Ivan", "Torres Garnica", "ivantorres@hotmail.com", 000296435, "3132261326", "123456789", typeUser[0], programas[5]);
            //var respuesta = UsuarioClase.CrearUsuario("upb", "bga", "admin@upb.edu.com", 000000000,"45646416", "123456789", "", "");
            Console.WriteLine(respuesta.Result);
        }

        private static void LlamarProgramas()
        {
            var programa = ProgramaClase.ObtenerTipoUsuario();
            int cont = 0;
            foreach (var item in programa)
            {
                Console.WriteLine(string.Concat(cont, ").", item.Name));
                programas.Add(item.Name);
                cont += 1;
            }
        }

        private static void LlamarTipoUsuario()
        {
            var tipoUsuario = TipoUsuarioClase.ObtenerTipoUsuario();
            int cont = 0;
            foreach (var item in tipoUsuario)
            {
                Console.WriteLine(string.Concat(cont, ").", item.TP_Identificador));
                typeUser.Add(item.TP_Identificador);
                cont += 1;
            }
            Console.WriteLine("\n\n");
        }
    }
}
