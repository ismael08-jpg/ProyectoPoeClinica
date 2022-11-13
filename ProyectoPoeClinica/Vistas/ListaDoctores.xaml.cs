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
using System.Data.Entity.Core.Objects;

namespace ProyectoPoeClinica.Vistas
{
    /// <summary>
    /// Lógica de interacción para ListaDoctores.xaml
    /// </summary>
    public partial class ListaDoctores : Page
    {
        Model.ClinicaEntities clinica = new Model.ClinicaEntities();
        public ListaDoctores()
        {
            InitializeComponent();
            refresh();
            
        }
        /* private void refresh()
         {
             List<DoctorViewModel> lst = new List<DoctorViewModel>();
             using (Model.ClinicaEntities db = new Model.ClinicaEntities())
             {
                 lst = (from p1 in db.Usuarios
                        where Puesto=='Medico'
                        select new DoctorViewModel
                        {
                            //ID=p1.ID,
                            Nombres=p1.Nombres,
                            Apellidos=p1.Apellidos,

                        }).ToList();
             }
             Dg.ItemsSource = lst;
         }*/
        private void refresh()
        {
            var query =
            from usuario in clinica.Usuarios
            where usuario.Puesto == "Medico"
            orderby usuario.Rol
            select new { usuario.Nombres, usuario.Apellidos, usuario.Puesto, usuario.Rol, usuario.ID };

           Dg.ItemsSource = query.ToList();
        }

        public class DoctorViewModel
        {
            public int ID { get; set; }          
            public string Nombres { get; set; }
            public string Apellidos { get; set; }
            public string Especialidad { get; set; }            
            
        }
       


        }
}
