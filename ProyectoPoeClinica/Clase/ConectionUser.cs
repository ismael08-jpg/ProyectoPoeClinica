using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPoeClinica.Clase
{

    // Conexion ala base datos
    class ConectionUser
    {
        int ID_User { get; set; }

        String Nombre_Apellido { get; set; }

        String Alias { get; set; }

        String Contra { get; set; }

        int ID_ROL { get; set; }
    }
}
