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
using ProyectoPoeClinica.Vistas;
using ProyectoPoeClinica;


namespace ProyectoPoeClinica.Vistas
{
    /// <summary>
    /// Interaction logic for Pacientes.xaml
    /// </summary>
    public partial class Pacientes : Page
    {
        public Pacientes()
        {
            InitializeComponent();
            REfrescar();
        }

        // ID  Global Vista
        public int ID = 0;


        // Metodos 
        private void Limpiar()  // Metodo de Limpieza de reggistros
        {
            TxbxDui.Text = "";
            TxbxNombres.Text = "";
            TxbxApellidos.Text = "";
            TxbxDireccion.Text = "";
            TxbxEdad.Text = "";
            Date.Text = "";
        }

        public void REfrescar()
        {

            // Instancia hacia obejeto que ese caso es Clase
            List<PacientesView> lst = new List<PacientesView>();
    
            using (Model.ClinicaEntities3 DBs = new Model.ClinicaEntities3())
            {
                lst = (from d in DBs.Pacientes
                       select new PacientesView
                       {
                           ID = d.ID,
                           Dui = d.Dui,
                           Nombres = d.Nombres,
                           Apellidos = d.Apellidos,
                           Direccion = d.Direccion,
                           Edad = d.Edad


                       }).ToList();/*.Join(from x in DBs.Expedientes
                              select new ExpedienteView
                              {

                                  IDExpediente = x.ID,
                                  FechaAfiliacion = x.Fecha

                              }).toList();*/

             
                DTG.ItemsSource = lst;

                // Boton ID PACIENTE inabilitado solo mostrara ya que es autro incrementable la base
                TexbxID.IsEnabled = false;
            }

        }


        private void BtnAfiliar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if(ID == 0)
                {
                    using (Model.ClinicaEntities3 db = new Model.ClinicaEntities3())
                    {
                        var Paciente = new Model.Pacientes();
                        Paciente.Dui = TxbxDui.Text;
                        Paciente.Nombres = TxbxNombres.Text;
                        Paciente.Apellidos = TxbxApellidos.Text;
                        Paciente.Direccion = TxbxDireccion.Text;
                        Paciente.Edad = int.Parse(TxbxEdad.Text);

                        db.Pacientes.Add(Paciente);
                        db.SaveChanges();
                        Limpiar();
                        REfrescar();
                    }
                }
                else 
                {
                    using (Model.ClinicaEntities3 db = new Model.ClinicaEntities3()) 
                    {
                        var Paciente = db.Pacientes.Find(ID);
                        Paciente.Dui = TxbxDui.Text;
                        Paciente.Nombres = TxbxNombres.Text;
                        Paciente.Apellidos = TxbxApellidos.Text;
                        Paciente.Direccion = TxbxDireccion.Text;
                        Paciente.Edad = int.Parse(TxbxEdad.Text);

                        db.SaveChanges();
                        Limpiar();
                       REfrescar();
                    }
                
                }

            }catch(Exception es)
            {
                MessageBox.Show("Oups! Algo Salio mal. \n \n Contacta Administrador comentales siguiente Error: \n" + es);
            }

        }

        private void TxbxEdad_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        // Parametros para Editar un Registro
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            // Intancia Ventana Emergente Fomrulario
            VEmerEditarPaciente hh = new VEmerEditarPaciente();

            int id = (int)((Button)sender).CommandParameter;

            foreach (var item in DTG.Items.SourceCollection) 
            {
                if (((PacientesView)item).ID.Equals(id))
                    {
                    hh.ID = ((PacientesView)item).ID;
                    hh.NombresE = ((PacientesView)item).Nombres;
                    hh.ApellidosE = ((PacientesView)item).Apellidos;
                    hh.DuiE = ((PacientesView)item).Dui;
                    hh.DirecccionE = ((PacientesView)item).Direccion;
                    hh.EdadE = ((PacientesView)item).Edad;

                    MainWindow.StaticMainFrame.Content = hh;

                }break;

            }
        }



        // Parametros para Eliminar un Registro
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                int ID_Paciente = (int)((Button)sender).CommandParameter;
                using (Model.ClinicaEntities3 db = new Model.ClinicaEntities3())
                {
                    var pacientes = db.Pacientes.Find(ID_Paciente);
                    db.Pacientes.Remove(pacientes);
                    db.SaveChanges();


                }
                REfrescar();

            }catch (Exception error)
            {
                MessageBox.Show("Error al Eliminar, Intente nuevamente \n Si proublema Persiste, Contactar Administrador \n" + error);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void DTG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                int id = (int)((Button)sender).CommandParameter;

                VEmerEditarPaciente pFormulario = new VEmerEditarPaciente(id);
                MainWindow.StaticMainFrame.Content = pFormulario;
            }catch (Exception Fallo)
            {
                MessageBox.Show("Error Controlado : \n" + Fallo);
            }
        }
    }



    }

