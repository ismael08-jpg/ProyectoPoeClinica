using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPoeClinica.Clases
{

    // Objeto hacia tabla Pacientes
    class PacientesView
    {
      public  int ID { get; set; }

      public String Dui { get; set; }

     public String Nombres { get; set; }

     public String Apellidos { get; set; }

     public String Direccion { get; set; }

     public DateTime Fecha {get; set;}

     public int Edad { get; set; }
    }
}
