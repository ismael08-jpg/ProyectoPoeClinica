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
    /// Interaction logic for VEmerEditarPaciente.xaml
    /// </summary>
    public partial class VEmerEditarPaciente : Page
    {
        public VEmerEditarPaciente()
        {
            InitializeComponent();
            ETxbxIDPaciente.IsEnabled = false;
        }

        // Variables Utilizar Obtencion de Variables a Editar
        public int ID { get; set; }

        public string NombresE { get; set; }

        public string ApellidosE { get; set; }

        public string DuiE { get; set; }

        public string DirecccionE { get; set; }

        public int EdadE { get; set; }

        public string FechaE { get; set; }

        public VEmerEditarPaciente(int ID) 
        {
            this.ID = ID;
        
        }


        private void EBtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.StaticMainFrame.Content = new Pacientes();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            ETxbxIDPaciente.Text = ID.ToString();
            ETxbxNombres.Text = NombresE;
            ETxbxApellidos.Text = ApellidosE;
            ETxbxDui.Text = DuiE;
            ETxbxDireccion.Text = DirecccionE;
            ETxbxEdad.Text = EdadE.ToString();
        }

        private void EBtnAztualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ID == 0)
                {
                    using (Model.ClinicaEntities3 db = new Model.ClinicaEntities3())
                    {

                        var paciente = new Model.Pacientes();
                        paciente.ID = int.Parse(ETxbxIDPaciente.Text);
                        paciente.Nombres = ETxbxNombres.Text;
                        paciente.Apellidos = ETxbxApellidos.Text;
                        paciente.Dui = ETxbxDui.Text;
                        paciente.Direccion = ETxbxDireccion.Text;
                        paciente.Edad = int.Parse(ETxbxEdad.Text);

                        db.Pacientes.Add(paciente);
                        db.SaveChanges();

                        MainWindow.StaticMainFrame.Content = new Pacientes();

                    }
                } else
                {
                    using (Model.ClinicaEntities3 db = new Model.ClinicaEntities3())
                    { 
                        var Paciente = db.Pacientes.Find(ID);
                    
                     if(Paciente != null) 
                        {
                            Paciente.Nombres = ETxbxNombres.Text;
                            Paciente.Apellidos = ETxbxApellidos.Text;
                            Paciente.Dui = ETxbxDui.Text;
                            Paciente.Direccion = ETxbxDireccion.Text;
                            Paciente.Edad = int.Parse(ETxbxEdad.Text);


                            db.SaveChanges();
                            MainWindow.StaticMainFrame.Content = new Pacientes();
                        }
                        else
                        {
                            MessageBox.Show("Error en actualizarcion del registro...");
                        }
                    
                    
                    }


                }


            }catch(Exception editarLog) 
            {
                MessageBox.Show("Error al Actualizar el Registro: \n" + editarLog);
            }
        }
    }
}
