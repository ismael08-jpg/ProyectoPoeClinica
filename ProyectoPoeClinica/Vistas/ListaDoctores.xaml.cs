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
            refresh();
            
        }
        private void refresh()
        {
            List<DoctorViewModel> lst = new List<DoctorViewModel>();
            using (Model.ClinicaEntities db = new Model.ClinicaEntities())
            {
                lst = (from p in db.Medicos
                       select new DoctorViewModel
                       {
                           ID_Medicos=p.ID,
                           
                           Nombre=p.Usuarios.Nombres,
                           Apellido=p.Usuarios.Apellidos,
                           Especialidad=p.Usuarios.Especialidad.Nombre_Especialidad,
                           

                       }).ToList();
            }
            Dg.ItemsSource = lst;
        }
        
        public class DoctorViewModel
        {
            public int ID_Medicos { get; set; }
            
            public string Nombre { get; set;  }
            public string Apellido { get; set; }
            public string Especialidad { get; set; }            
            
        }
       


        }
}
