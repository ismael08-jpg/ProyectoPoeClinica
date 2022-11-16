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
        public int ID { get; set; }

        public String Dui { get; set; }

        public String Nombres { get; set; }

        public String Apellidos { get; set; }

        public String Direccion { get; set; }

        public int Edad { get; set; }


    }


    class ExpedienteView
    {
        public int IDExpediente { get; set; }

        public int ID_Paciente { get; set; }

        public String FechaAfiliacion { get; set; }

    }

    class PacientesUpdateView
    {
        public int ID { get; set; }

        public String Dui { get; set; }

        public String Nombres { get; set; }

        public String Apellidos { get; set; }

        public String Direccion { get; set; }

        public int Edad { get; set; }

        public String FechaAfiliacion { get; set; }


    }


}
