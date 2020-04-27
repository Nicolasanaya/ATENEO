using System;
using System.Collections.Generic;
using System.Text;

namespace ConexiónBaseDatos.DTOs
{
	public class UsuariosDocentes
	{
		public string Nombre { get; set; }

		public string Apellidos { get; set; }

		public string Correo { get; set; }

		public int Identificador { get; set; }

		public string Telefono { get; set; }

		public string TipoUsuario { get; set; }

		public string Estado { get; set; }
	}

	public class UsuariosEstudientes
	{
		public string Nombre { get; set; }

		public string Apellidos { get; set; }

		public string Correo { get; set; }

		public int Identificador { get; set; }

		public string Telefono { get; set; }

		public string TipoUsuario { get; set; }

		public string Programa { get; set; }

		public string Estado { get; set; }
	}
}
