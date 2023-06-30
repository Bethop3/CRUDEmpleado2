using CRUDEmpleado.Entities;
using CRUDEmpleado.Services;
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

namespace CRUDEmpleado
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        EmpleadosServices empli = new EmpleadosServices();
        Empleado empleado = new Empleado();
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

            bool cond1 = txtApellidos.Text != null && txtNombre.Text != null && txtCorreo.Text != null;
            bool cond2 = txtApellidos.Text?.Length > 0
                && txtNombre.Text?.Length > 0 && txtCorreo.Text?.Length >0;
            if ( cond1 && cond2)
            {
                
                empleado.Nombre = txtNombre.Text!;
                empleado.Apellido = txtApellidos.Text!;
                empleado.Correo = txtCorreo.Text!;
                empli.Agregar(empleado);
            }
            else
            {
                MessageBox.Show("Ingrese todos los valores correctamente. ");
            }
            // Agregar una condicion para no validar datos nulos


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Empleado? empleadoPorId = this.empli.VerEmpleado(int.Parse(txtID.Text));

            if( empleadoPorId == null )
            {
                MessageBox.Show("Error");
                return;
            }

            txtNombre.Text = empleadoPorId?.Nombre ?? "Default";
            txtCorreo.Text = empleadoPorId?.Correo ?? "Default";
            txtApellidos.Text = empleadoPorId?.Apellido ?? "Default";
            txtFecha.Text = empleadoPorId?.FechaRegistro.ToString() ?? "Sin Fecha";

        }
    }
}
