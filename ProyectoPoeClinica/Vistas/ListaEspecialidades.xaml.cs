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
    /// Lógica de interacción para ListaEspecialidades.xaml
    /// </summary>
    public partial class ListaEspecialidades : Page
    {
        public ListaEspecialidades()
        {
            InitializeComponent();
            refresh();
        }
        private void refresh()
        {
            List<EspecialidadViewModel> lst = new List<EspecialidadViewModel>();
            using (Model.ClinicaEntities db = new Model.ClinicaEntities())
            {
                lst = (from p in db.Especialidad
                       select new EspecialidadViewModel
                       {
                           ID = p.ID,
                           Nombre_Espe=p.Nombre_Especialidad,

                       }).ToList();
            }
            Dg.ItemsSource = lst;
        }

        public class EspecialidadViewModel
        {
            public int ID { get; set; }
            public string Nombre_Espe { get; set; }
        }
        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            frPrincipal.Content = new FormularioEspecialidades();         

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
                    var especilidades = db.Especialidad.Find(id);
                    db.Especialidad.Remove(especilidades);
                    db.SaveChanges();
                }
                refresh();
            }
        }
        private void btnEditar_Click(object sender, RoutedEventArgs e)
        { 
        int id=(int)((Button)sender).CommandParameter;
            FormularioEspecialidades formularioEspecialidades = new FormularioEspecialidades(id);
            MainWindow.StaticMainFrame.Content = formularioEspecialidades;
        }


    }

}
