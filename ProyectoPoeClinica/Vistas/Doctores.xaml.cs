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
using ProyectoPoeClinica.Vistas;

namespace ProyectoPoeClinica.Vistas
{
    /// <summary>
    /// Interaction logic for Doctores.xaml
    /// </summary>
    public partial class Doctores : Page
    {
        public Doctores()
        {
            InitializeComponent();
            Refrescar();
            Especialidad();
        }

        // ID  Global Vista
        public int ID = 0;
        ClinicaEntities3 contexto = new ClinicaEntities3();

        public void Refrescar()
        {



            using (Model.ClinicaEntities3 DBs = new Model.ClinicaEntities3())
            {


                var listado = (from d in DBs.Usuarios
                               select new UsuarioView
                               {
                                   ID_User = d.ID,
                                   Nombres = d.Nombres,
                                   Apellidos = d.Apellidos,
                                   Alias = d.Alias,
                                   Puesto = d.Puesto
                               })
                  .Join((from x in DBs.Especialidad
                         select new EspecialidadView
                         {
                             ID_Especialidad = x.ID,
                             Nombre_Especialidades = x.Nombre_Especialidad
                         }),
                        px => px.ID_User,
                        ex => ex.ID_Especialidad,
                        (px, ex) => new
                        {
                            px.ID_User,
                            px.Nombres,
                            px.Apellidos,
                            px.Alias,
                            px.Puesto,
                            ex.Nombre_Especialidades
                        }).ToList();

                DTGD.ItemsSource = listado.Where(s => s.Puesto.Contains("Doctor")).ToList();


            }

        }

        public void Especialidad()
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refrescar();
        }





        private void ButnAgregar_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
