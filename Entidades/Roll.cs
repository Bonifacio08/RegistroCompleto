using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Registro.Entidades
{
    public class Roll
    {
        [Key]
        public int RolID { get; set; }
        public int FechaCreacion { get; set; }
        public int Descripcion { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string Contraseña { get; set; }
    }
}

