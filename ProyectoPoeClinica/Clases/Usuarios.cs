using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPoeClinica.Clases
{

    // Clase Conexion Usuarios
    class UsuarioView
    {
        public int ID_User { get; set; }

        public String Nombres { get; set; }

        public String Apellidos { get; set; }

        public String Alias { get; set; }

        public String Contra { get; set; }

        public String Puesto { get; set; }

        public int Especialidad_Medicos { get; set; }

        public int ID_Rol { get; set; }

    }



    class RolView
    {
        public int ID_Rol {get; set;}
        public String Tipo_Rol { get; set; }
    }


}
