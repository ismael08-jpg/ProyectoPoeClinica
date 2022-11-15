using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPoeClinica.Clases
{
    public class MedicoSelectedEventArgs : EventArgs
    {
        public UsuarioModel usuariom { get; set; }
        
    }
}
