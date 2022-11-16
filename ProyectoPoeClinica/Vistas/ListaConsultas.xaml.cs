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
using ProyectoPoeClinica.Clases;

namespace ProyectoPoeClinica.Vistas
{
    /// <summary>
    /// Lógica de interacción para ListaConsultas.xaml
    /// </summary>
    public partial class ListaConsultas : Page
    {
        public ListaConsultas()
        {
            InitializeComponent();
            refresh();
        }

        private void refresh(string nombre_paciente = "")
        {
            List<Citas> lst = new List<Citas>();
            using (Model.ClinicaEntities db = new Model.ClinicaEntities())
            {
                if(nombre_paciente != "")
                {
                     lst = (from c in db.Cita
                                    where c.Expedientes.Pacientes.Nombres.Contains(nombre_paciente)
                            //|| c.nombre.Contains(txtBuscar.Text)
                            //|| c.username.Contains(txtBuscar.Text)
                            select new Citas
                            {
                                ID = c.ID,
                                Fecha_Cita = c.Fecha_Cita,
                                NConsultorio = c.NConsultorio,
                                Diagnostico = c.Diagnostico,
                                ID_Tipo_Cita = c.ID_Tipo_Cita,
                                ID_Expediente = c.ID_Expediente,
                                ID_Medico = c.ID_Medico,


                                nombres_medico = c.Medicos.Usuarios.Nombres + " " + c.Medicos.Usuarios.Apellidos,
                                tipo_cita = c.Tipo_Cita.Tipo_Cita1,
                                nombres_paciente = c.Expedientes.Pacientes.Nombres + " " + c.Expedientes.Pacientes.Apellidos


                            }).ToList();


                } else
                {
                    lst = (from c in db.Cita
                           select new Citas
                           {
                               ID = c.ID,
                               Fecha_Cita = c.Fecha_Cita,
                               NConsultorio = c.NConsultorio,
                               Diagnostico = c.Diagnostico,
                               ID_Tipo_Cita = c.ID_Tipo_Cita,
                               ID_Expediente = c.ID_Expediente,
                               ID_Medico = c.ID_Medico,


                               nombres_medico = c.Medicos.Usuarios.Nombres + " " + c.Medicos.Usuarios.Apellidos,
                               tipo_cita = c.Tipo_Cita.Tipo_Cita1,
                               nombres_paciente = c.Expedientes.Pacientes.Nombres + " " + c.Expedientes.Pacientes.Apellidos


                           }).ToList();
                }
            }

            Dg.ItemsSource = lst;
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.StaticMainFrame.Content = new SeleccionarPaciente();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            FrmCita formulario = new FrmCita(id);
            MainWindow.StaticMainFrame.Content = formulario;

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿De verdad desea eliminar este registro?",
                "Confirmación", MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                int id = (int)((Button)sender).CommandParameter;

                using (Model.ClinicaEntities db = new Model.ClinicaEntities())
                {
                    var propietario = db.Cita.Find(id);

                    db.Cita.Remove(propietario);
                    db.SaveChanges();
                }
                refresh();
            }
        }

        private void txtPaciente_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            filter();
        }


        private void filter()
        {
            string nombre_paciente = "";
            if (txtPaciente.Text != "")
                nombre_paciente = txtPaciente.Text;

            refresh(nombre_paciente);
        }
    }
}
