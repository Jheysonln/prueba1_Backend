using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DatoComunBE
    {
        public int? idDatoComun { get; set; }
        public string cod_tabla { get; set; }
        public string cod_fila { get; set; }
        public string descripcionCorta { get; set; }
        public string descripcionLarga { get; set; }
        public string valorTexto1 { get; set; }
        public string valorTexto2 { get; set; }
        public string valorTexto3 { get; set; }
        public string valorTexto4 { get; set; }
        public string valorTexto5 { get; set; }
        public DateTime? fechaInicio { get; set; }
        public DateTime? fechaFin { get; set; }
    }
}
