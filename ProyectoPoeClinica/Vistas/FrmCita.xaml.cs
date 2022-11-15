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
using ProyectoPoeClinica.Model;

namespace ProyectoPoeClinica.Vistas
{
    /// <summary>
    /// Lógica de interacción para FrmCita.xaml
    /// </summary>
    public partial class FrmCita : Page
    {
        public int id = 0;
        public int id_paciente = 0;
        public string mode = "create";

       

        public FrmCita(int id = 0, int id_paciente = 0, string mode = "create")
        {
            InitializeComponent();

            this.id = id;
            this.id_paciente = id_paciente;
            titulo.Text = "Agendar Nueva Consulta";


           
            //Obtener el paciente
            using (Model.ClinicaEntities db = new Model.ClinicaEntities())
            {

                var pasiente = db.Pacientes.FirstOrDefault(x => x.ID == id_paciente);
                txtPasiente.Text = (pasiente.Nombres + " " + pasiente.Apellidos);
            }

            llenarTipoConsulta();

            //txtMedico.Text = usuariog.nombres;

        }

        private void llenarTipoConsulta()
        {
            //lenar el combobox de tipo de cita
            List<Tipo_Cita> clientes = new List<Tipo_Cita>();
            using (ClinicaEntities db = new ClinicaEntities())
            {

                clientes = db.Tipo_Cita.ToList();

                

                comboTipoConsulta.ItemsSource = clientes;
                comboTipoConsulta.DisplayMemberPath = "Tipo_Cita1";
                comboTipoConsulta.SelectedValuePath = "ID";

            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            // Instancia hacia Ventana Principal
            
            //Mostrando Vnetana Principal

            
            
        }


        public static void PasarDatos(object sender, RoutedEventArgs e)
        {
            UsuarioModel usuario = (UsuarioModel)((Button)sender).CommandParameter;

            //usuariog = usuario;
            //ventana.Hide();

            //MessageBox.Show("Event passed " + usuario.nombres);
            //txtMedico.Text = usuario.nombres + " " + usuario.apellidos;
        }

        private void Page_GotFocus(object sender, RoutedEventArgs e)
        {
            //txtMedico.Text = usuariog.nombres;
        }

        private void Page_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //txtMedico.Text = usuariog.nombres;
        }

        private void btnSeleccionarMedico_Click(object sender, RoutedEventArgs e)
        {
            SeleccionarDoctorCita ventana = new SeleccionarDoctorCita();
            ventana.MedicoSelected += Find_MedicoSelected;

            ventana.ShowDialog();
            //ventana.Show();
        }

        private void Find_MedicoSelected(object sender, MedicoSelectedEventArgs e)
        {
            txtMedico.Text = e.usuariom.nombres;
        }
        //
    }
}
