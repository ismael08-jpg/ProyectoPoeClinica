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
using ProyectoPoeClinica.Model;
using ProyectoPoeClinica.Vistas;


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

        public int ID = 0;
        ClinicaEntities contexto = new ClinicaEntities();
        // Variables de usuario
        public String alias, conta;


        //Inision de Secion
        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            Usuarios loginUser = contexto.Usuarios.FirstOrDefault(x => x.Alias == TxbxAlias.Text
            && x.Contra == TxbxContra.Password);

            if (TxbxAlias.Text == "" && TxbxContra.Password == "")
            {
                MessageBox.Show("Ingrese Todos Los Campos");

            }
            else
            {
                if (TxbxAlias.Text == "")
                {
                    MessageBox.Show("Alias esta Vacio");
                }
                if (TxbxContra.Password == "")
                {
                    MessageBox.Show("Contra esta Vacio");
                }
                else
                {
                    if (loginUser != null)
                        if (loginUser.Alias == TxbxAlias.Text && loginUser.Contra == TxbxContra.Password)
                        {

                            // Instancia hacia Ventana Principal
                            MainWindow vp = new MainWindow();
                            //Mostrando Vnetana Principal
                            vp.Show();
                            //Ocultando Ventana Loging
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Usuario O Contraseña Erronea...");
                            TxbxAlias.Text = "";
                            TxbxContra.Password = "";
                        }
                    else
                    {
                        MessageBox.Show("Los datos ingresados son incorrectos", "Error de inicio de sesion", MessageBoxButton.OK, MessageBoxImage.Error);
                        TxbxAlias.Text = "";
                        TxbxContra.Password = "";
                    }
                }


            }




        }
    }
}
