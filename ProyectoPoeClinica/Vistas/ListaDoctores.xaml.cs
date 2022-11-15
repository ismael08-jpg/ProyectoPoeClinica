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
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoPoeClinica.Vistas
{
    /// <summary>
    /// Lógica de interacción para ListaDoctores.xaml
    /// </summary>
    public partial class ListaDoctores : Page
    {
      
        public ListaDoctores()
        {
            InitializeComponent();
            

            string miConexion = ConfigurationManager.ConnectionStrings["ProyectoPoeClinica.Properties.Settings.ClinicaConnectionString"].ConnectionString;
            miConexionSql = new SqlConnection(miConexion);
           // mostrarusuarios();
          //mostrarDoctores();
        }

        
      /* private void mostrarusuarios()
        {
            string consulta = "select concat(Nombres, ' ', Apellidos) as Info from Usuarios where Puesto like '%Medico%' ";
            SqlDataAdapter adaptadorSql = new SqlDataAdapter(consulta, miConexionSql);
            using(miConexionSql)
            {
                DataTable usuariosTabla = new DataTable();
                adaptadorSql.Fill(usuariosTabla);
                listaDoctores.DisplayMemberPath = "Info";
                listaDoctores.SelectedValuePath = "ID";
                listaDoctores.ItemsSource = usuariosTabla.DefaultView;
            }
        }*/
       public void mostrarDoctores()
        {
            //List<EspecialidadViewModel> lst = new List<EspecialidadViewModel>();
            using (Model.ClinicaEntities db = new Model.ClinicaEntities())
            {
                var lst = (from p in db.Usuarios
                           select new Doctoresview
                           {
                               nombres = p.Nombres,
                               apellidos = p.Apellidos

                           }).ToList();
                           
                         
                Dg.ItemsSource = lst;
            }

            
        }
        public class Doctoresview
        {
            public string nombres { get; set; }
            public string apellidos { get; set; }
        }

        public class Especialidadview
        {
            public string especiliadad { get; set; }
        }

        SqlConnection miConexionSql;
    }
}
