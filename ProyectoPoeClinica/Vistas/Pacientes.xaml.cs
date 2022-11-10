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

            using (Model.ClinicaEntities2 DBs = new Model.ClinicaEntities2())
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


                       }).ToList();

                DTG.ItemsSource = lst;

            }








            // Botonews insertados registros 
         

            

            }

        private void DGT_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }















    }

