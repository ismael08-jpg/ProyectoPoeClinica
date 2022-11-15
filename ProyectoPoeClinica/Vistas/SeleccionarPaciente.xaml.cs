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
    /// Lógica de interacción para SeleccionarPaciente.xaml
    /// </summary>
    public partial class SeleccionarPaciente : Page
    {
        public SeleccionarPaciente()
        {
            InitializeComponent();
            refresh();
        }

        private void refresh()
        {
            List<Paciente> lst = new List<Paciente>();
            using (Model.ClinicaEntities db = new Model.ClinicaEntities())
            {
                lst = (from p in db.Pacientes
                       select new Paciente
                       {
                           ID = p.ID,
                           Dui = p.Dui,
                           Nombres = p.Nombres,
                           Apellidos = p.Apellidos,
                       }).ToList();
            }

            Dg.ItemsSource = lst;
        }

        public class Paciente
        {
            public int ID { get; set; }
            public string Dui { get; set; }

            public string Nombres { get; set; }
            public string Apellidos { get; set; }
        }

        private void btnSeleccionar_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            FrmCita frmCita = new FrmCita(0, id);
            MainWindow.StaticMainFrame.Content = frmCita;
        }
    }
}
