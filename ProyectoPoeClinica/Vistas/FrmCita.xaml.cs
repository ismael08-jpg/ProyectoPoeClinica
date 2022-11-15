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

        Model.Pacientes paciente = new Model.Pacientes();
        Medicos medico = new Medicos();

        public FrmCita(int id = 0, int id_paciente = 0, string mode = "create")
        {
            InitializeComponent();

            this.id = id;
            this.id_paciente = id_paciente;
            titulo.Text = "Agendar Nueva Cita Médica";
            txtDiagnostico.Visibility = Visibility.Hidden;



            if(id_paciente != 0)
            {
                obtenerPaciente(id_paciente);
            }




            //Cuando se reciba el parametro vamos a editar
            if (id != 0)
            {
                mode = "edit";
                setEditMode(id);
            }

            llenarTipoConsulta();
        }
        
        
        private void setEditMode(int id_cita)
        {
            mode = "edit";
            using (Model.ClinicaEntities db = new Model.ClinicaEntities())
            {
                titulo.Text = "Editar Cita Médica";

                var cita = db.Cita.Find(this.id);

                paciente = cita.Expedientes.Pacientes;
                medico = cita.Medicos;

                dateFechaCita.Text = cita.Fecha_Cita.ToString();
                txtNCosnultorio.Text = cita.NConsultorio.ToString();
                comboTipoConsulta.SelectedValue = cita.Tipo_Cita.ID.ToString();
                txtPasiente.Text = paciente.Nombres + " " + paciente.Apellidos;
                txtMedico.Text = medico.Usuarios.Nombres + " " + medico.Usuarios.Apellidos;
                
                //Hacer el diagnostico visible
                txtDiagnostico.Visibility = Visibility.Visible;
                txtDiagnostico.Text = cita.Diagnostico;

                btnSeleccionarMedico.Content = "Cambiar Médico";
            }
        }

        private void obtenerPaciente(int id_paciente2)
        {
            //Obtener el paciente
            using (Model.ClinicaEntities db = new Model.ClinicaEntities())
            {

                paciente = db.Pacientes.FirstOrDefault(x => x.ID == id_paciente2);
                txtPasiente.Text = paciente.Nombres + " " + paciente.Apellidos;

                //Si no posee cuadro se lo creamos
                if (paciente.Expedientes.Count() == 0)
                {
                    Expedientes expedientes = new Expedientes();
                    expedientes.ID_Paciente = paciente.ID;
                    expedientes.Fecha = DateTime.Now;

                    paciente = db.Pacientes.FirstOrDefault(x => x.ID == id);
                }
            }
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
                
                if(mode == "edit")
                {
                    var cita = db.Cita.Find(this.id);

                    comboTipoConsulta.SelectedItem = cita.Tipo_Cita.Tipo_Cita1;
                }
                    
            }
        }
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if(dateFechaCita.Text != "" && txtNCosnultorio.Text != "" 
                && comboTipoConsulta.SelectedValue.ToString() != "" && medico.ID_Usuario != 0)
            {

                try
                {
                    using (ClinicaEntities db = new ClinicaEntities())
                    {
                        Cita cita = mode == "edit" ? new Cita()
                        : db.Cita.Find(id);

                        cita.Fecha_Cita = DateTime.Parse(dateFechaCita.Text);
                        cita.NConsultorio = int.Parse(txtNCosnultorio.Text);

                        if (txtDiagnostico.Text != "")
                            cita.Diagnostico = txtDiagnostico.Text;


                        cita.ID_Tipo_Cita = int.Parse(comboTipoConsulta.SelectedValue.ToString());
                        cita.ID_Expediente = paciente.Expedientes.First().ID;
                        cita.ID_Medico = medico.ID;


                        //Estamos editando vamos a ver si est[a modificado y guardaremos
                        if(mode == "edit")
                        {
                            db.Entry(cita).State = System.Data.Entity.EntityState.Modified;
                        } else
                        {
                            db.Cita.Add(cita);
                        }

                        if (db.SaveChanges() == 1)
                        {
                            MessageBox.Show("La cita fue creada con éxito", "Operación exitosa");

                        }
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString(), " Hubo un error");

                }
                finally
                {
                    ListaConsultas ventanaConsultas = new ListaConsultas();
                    MainWindow.StaticMainFrame.Content = ventanaConsultas;
                }
            } else
            {
                MessageBox.Show("Debes llenar todos los campos requeridos");
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            SeleccionarPaciente ventanaPaciente = new SeleccionarPaciente();
            MainWindow.StaticMainFrame.Content = ventanaPaciente;
        }



        private void btnSeleccionarMedico_Click(object sender, RoutedEventArgs e)
        {
            SeleccionarDoctorCita ventana = new SeleccionarDoctorCita();
            ventana.MedicoSelected += Find_MedicoSelected;

            ventana.ShowDialog();
        }

        private void Find_MedicoSelected(object sender, MedicoSelectedEventArgs e)
        {
            txtMedico.Text = e.usuariom.nombres;

            Model.Usuarios user = new Model.Usuarios();
            using (ClinicaEntities db = new ClinicaEntities())
            {
                medico = db.Medicos.FirstOrDefault(x => x.ID == e.usuariom.id_doctor);
            }
        }

    }
}
