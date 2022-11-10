using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPoeClinica.Clases
{

    // Clase Conexion Usuarios
    class Usuarios
    {
        int ID { get; set; }

        String Nombres { get; set; }

        String Apellidos { get; set; }

        String Alias { get; set; }

        String Contra { get; set; }

        String Puesto { get; set; }

        int Especialidad_Medicos { get; set; }

        int ID_Rol { get; set; }

    }
}
