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
using System.Windows.Shapes;
using ProyectoPoeClinica.Clases;

namespace ProyectoPoeClinica.Vistas
{
    /// <summary>
    /// Lógica de interacción para SeleccionarDoctorCita.xaml
    /// </summary>
    public partial class SeleccionarDoctorCita : Window
    {
        public int id_doctor_global;

        public EventHandler<MedicoSelectedEventArgs> MedicoSelected;

        

        public SeleccionarDoctorCita()
        {
            InitializeComponent();
            refresh();
        }

        private void refresh()
        {
            List<UsuarioModel> lst = new List<UsuarioModel>();
            using (Model.ClinicaEntities db = new Model.ClinicaEntities())
            {
                lst = (from u in db.Usuarios join m in db.Medicos on u.ID equals m.ID_Usuario
                       select new UsuarioModel
                       {
                           id_usuario = u.ID,
                           nombres = u.Nombres,
                           apellidos = u.Apellidos,
                           id_doctor = m.ID,
                       }).ToList();
            }

            Dg.ItemsSource = lst;
        }

        

        private void btnMostrar_Click(object sender, RoutedEventArgs e)
        {
            
            this.id_doctor_global = (int)((Button)sender).CommandParameter;
            UsuarioModel user = new UsuarioModel();
            using (Model.ClinicaEntities db = new Model.ClinicaEntities())
            {
                user = (from u in db.Usuarios
                        join m in db.Medicos on u.ID equals m.ID_Usuario
                        where m.ID == this.id_doctor_global
                        select new UsuarioModel
                        {
                            id_usuario = u.ID,
                            nombres = u.Nombres,
                            apellidos = u.Apellidos,
                            id_doctor = m.ID,
                        }).FirstOrDefault();
            }

            EventHandler<MedicoSelectedEventArgs> handler = MedicoSelected;
            if(handler != null)
            {
                handler(this, new MedicoSelectedEventArgs()
                {
                    usuariom = user
                });
            }

            this.Close();
        }

        private void btnSeleccionar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
