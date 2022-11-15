using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPoeClinica.Clases
{
    public class UsuarioModel
    {
        
        public int id_usuario { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public int id_doctor { get; set; }
        
    }
}
