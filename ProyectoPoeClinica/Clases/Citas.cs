using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPoeClinica.Clases
{
    class Citas
    {
        public int ID { get; set; }
        public DateTime? Fecha_Cita { get; set; }
        public int? NConsultorio { get; set; }
        public string Diagnostico { get; set; }
        public int? ID_Tipo_Cita { get; set; }
        public int? ID_Expediente { get; set; }
        public int? ID_Medico { get; set; }

        public string nombres_medico { get; set; }
        public string tipo_cita { get; set; }
        public string nombres_paciente { get; set; }
    }
}
