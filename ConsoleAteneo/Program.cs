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
            //LlamarTipoUsuario();
            //LlamarProgramas();
            //CrearUsuario();
            //Login();
            Console.ReadLine();
        }

        private static void Login()
        {
            var respuesta = UsuarioClase.ValidarUsuario("Ivantorres12@hotmail.com", "123456789");
            Console.WriteLine(respuesta.Result);
        }

        private static void CrearUsuario()
        {
            Task.Delay(3000);
            //var respuesta = UsuarioClase.CrearUsuario("Leonardo", "Torres Garnica", "Leo@hotmail.com", "3132261326", "123456789",typeUser[1],"");
            //var respuesta = UsuarioClase.CrearUsuario("Leonardo", "Torres Garnica", "Leo@hotmail.com", "3132261326", "123456789", typeUser[1], programas[5]);
            var respuesta = UsuarioClase.CrearUsuario("upb", "bga", "admin@upb.edu.com", "45646416", "123456789", "", "");
            Console.WriteLine(respuesta.Result);
        }

        private static void LlamarProgramas()
        {
            var programa = ProgramaClase.ObtenerTipoUsuario();
            int cont = 0;
            foreach (var item in programa)
            {
                Console.WriteLine(string.Concat(cont,").",item.Name));
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
