﻿using System;
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
    /// Lógica de interacción para FormularioEspecialidades.xaml
    /// </summary>
    public partial class FormularioEspecialidades : Page
    {
        public int id = 0;
        public int ID;
        
        public FormularioEspecialidades(int id=0)
        {
            InitializeComponent();
            this.id = id;
            if(this.id!=0)
            {
                using(Model.ClinicaEntities db= new Model.ClinicaEntities())
                {
                    var especialidades = db.Especialidad.Find(this.id);
                    
                    txtNombreEspecialidad.Text = especialidades.Nombre_Especialidad.ToString();
                }
            }

        }
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (id == 0)
            {
                using (Model.ClinicaEntities db = new Model.ClinicaEntities())
                {
                    var especialidad = id == 0 ? new Model.Especialidad() : db.Especialidad.Find(id);
                    
                    especialidad.Nombre_Especialidad = txtNombreEspecialidad.Text;

                    db.Especialidad.Add(especialidad);
                    db.SaveChanges();
                    MainWindow.StaticMainFrame.Content = new ListaEspecialidades();
                }
            }
            else
            {
                using (Model.ClinicaEntities db = new Model.ClinicaEntities())
                {

                    var especialidad = id == 0 ? new Model.Especialidad() : db.Especialidad.Find(id);
                    
                    especialidad.Nombre_Especialidad = txtNombreEspecialidad.Text;

                    db.Entry(especialidad).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    MainWindow.StaticMainFrame.Content = new ListaEspecialidades();
                }
            }
            
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿De verdad desea cancelar?",
              "Confirmación", MessageBoxButton.YesNo,
              MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                MainWindow.StaticMainFrame.Content = new ListaEspecialidades();
            }
        }
    }
}