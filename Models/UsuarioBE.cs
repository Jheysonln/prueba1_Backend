using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class UsuarioBE
	{
		public int? cod_usuario { get; set; }
		public string nom_usuario { get; set; }
		public string descripcion { get; set; }
		public string direccion { get; set; }
		public int? telefono { get; set; }
		public string correo { get; set; }
		public string password { get; set; }
		public int? perfil { get; set; }
		public string imgPerfil { get; set; }
		public string pageState { get; set; }
		public DateTime? fechaNacimiento { get; set; }
		public DateTime? fechaRegistro { get; set; }
		public DateTime? fechaModifica { get; set; }
		//public DepartamentoBE Departamento { get; set; }
		//public ProvinciaBE Provincia { get; set; }
		//public SexoBE Sexo { get; set; }
		public DatoComunBE DatoComun { get; set; }
		public int PageNumber { get; set; } = 1;
		public int PageSize { get; set; } = 10;
	}
}
