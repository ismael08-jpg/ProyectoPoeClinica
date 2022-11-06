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
using ProyectoPoeClinica.Vistas;

namespace ProyectoPoeClinica
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Abre la vista de consultas
        private void btnConsultas_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ListaConsultas();
        }

        //Abre la vista de especialidades
        private void btnEspecialidades_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ListaEspecialidades();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Home();
        }
    }
}
