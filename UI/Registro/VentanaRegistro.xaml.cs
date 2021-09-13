using Registro.BLL;
using Registro.Entidades;
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

namespace Registro.UI.Registro
{
    /// <summary>
    /// Interaction logic for VentanaRegistro.xaml
    /// </summary>
    public partial class VentanaRegistro : Window
    {
        //Creams una instancia de la clase Roll para poder utlizar el objeto y accerdes a la clase;
        Roll R = new Roll();
        public VentanaRegistro()
        {
            InitializeComponent();
            this.DataContext = R;
        }


        //Metodos
        public void Limpiar()
        {
            this.R = new Roll();
            this.DataContext = R;

            TextID.Text = String.Empty;
            TextCreacion.Text = string.Empty;
            TextNombre.Text = String.Empty;
            TextCorreo.Text = String.Empty;
            TextContraseña.Password = string.Empty;
            TextDireccion.Text = string.Empty;
        }
        //
        private bool Validar()
        {
            bool esValido = true;
            if (TextID.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ingrese El Roll ID", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (TextNombre.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ingrese el Nombre", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (TextCorreo.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ingrese el correo", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (TextContraseña.Password.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ingrese la Contraseña", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (TextDireccion.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ingrese la Direccion", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return esValido;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            //Aqui agregamos los campos de texto
            R.RolID = Convert.ToInt32(TextID.Text);
            R.FechaCreacion = Convert.ToInt32(TextCreacion.Text);
            R.Nombre = TextNombre.Text;
            R.Correo = TextCorreo.Text;
            R.Contraseña = TextContraseña.Password;
            R.Direccion = TextDireccion.Text;
            var paso = RollBLL.Guardar(R);
            ////////////////////////////////////

            if (paso)
            {
                //Limpiar();
                MessageBox.Show("Guardado!!", "Exito!!",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Guardado Negado", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void BuscarButButton_Click(object sender, RoutedEventArgs e)
        {
            if (TextID.Text.Length == 0)
            {
                return;
            }
            var roll = RollBLL.Buscar(Convert.ToInt32(TextID.Text));


            //roll = RollBLL.Buscar(Convert.ToInt32(TextCreacion.Text));
            if (roll != null)
            {
                this.R = roll;
                //Agregado
                TextCreacion.Text = Convert.ToString(roll.FechaCreacion);
                TextNombre.Text = roll.Nombre;
                TextCorreo.Text = roll.Correo;
                TextDireccion.Text = roll.Direccion;
                TextContraseña.Password = roll.Contraseña;
            }
            else
            {
                MessageBox.Show("Este ID  No Existe", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (TextID.Text.Length == 0)
            {
                return;
            }
            if (RollBLL.Eliminar(Convert.ToInt32(TextID.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
               
            }
            else
            {
                MessageBox.Show("No fue posible eliminar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
    }
