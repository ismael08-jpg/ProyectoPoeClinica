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


namespace ProyectoPoeClinica
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }


        //Inision de Secion
        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            // Instancia hacia Ventana Principal
            MainWindow vp = new MainWindow();
            //Mostrando Vnetana Principal
            vp.Show();
            //Ocultando Ventana Loging
            this.Hide();
        }
    }
}
