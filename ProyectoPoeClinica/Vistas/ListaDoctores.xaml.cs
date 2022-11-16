using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity.Core.Objects;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoPoeClinica.Vistas
{
    /// <summary>
    /// Lógica de interacción para ListaDoctores.xaml
    /// </summary>
    public partial class ListaDoctores : Page
    {
      
        public ListaDoctores()
        {
            InitializeComponent();            
           
          mostrarDoctores();
        }
        private void mostrarDoctores()
        {
            
            using (Model.ClinicaEntities db = new Model.ClinicaEntities())
            {
                List<Doctoresview> list = new List<Doctoresview>();
                
                list = (from c in db.Usuarios
                       where c.ID_Especialidad!=null
                       
                       select new Doctoresview
                       {
                           nombres=c.Nombres,
                           apellidos=c.Apellidos,
                           especialidad=c.Especialidad.Nombre_Especialidad
                       }).ToList();
                Dg.ItemsSource = list;

            }
            
        }
        public class Doctoresview
        {
            public string nombres { get; set; }
            public string apellidos { get; set; }
            public string alias { get; set; }
            public string contra { get; set; }
            public string puesto { get; set; }
            public int id_rol { get; set; }
            public int id_Especialidad { get; set; }
            public int ID { get; set; }
            public string especialidad { get; set; }


        }

        

        
    }
}
