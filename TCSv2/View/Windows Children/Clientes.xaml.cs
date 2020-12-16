using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace TCSv2.View.Windows_Children
{
    /// <summary>
    /// Lógica de interacción para Clientes.xaml
    /// </summary>
    public partial class Clientes : Window
    {
        SqlConnection sqlconnection;
        public Clientes()
        {
            InitializeComponent();
            string connectionString = @"server=(local)\SQLEXPRESS;Initial Catalog=TecnoCell;Integrated Security=True";
            sqlconnection = new SqlConnection(connectionString);

            Mostrar();
        }

        private void Mostrar()
        {
            try
            {

                string query = "SELECT * FROM Cliente";

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlconnection);

                using (sqlDataAdapter)
                {

                    DataTable tabla1 = new DataTable();


                    sqlDataAdapter.Fill(tabla1);

                    dgllenar.DisplayMemberPath = "Id_Cliente";
                    dgllenar.DisplayMemberPath = "Nombre";
                    dgllenar.DisplayMemberPath = "Apellido";
                    dgllenar.DisplayMemberPath = "Genero";
                    dgllenar.DisplayMemberPath = "Direccion";
                    dgllenar.DisplayMemberPath = "Telefono";
                    dgllenar.DisplayMemberPath = "Correo";
                    dgllenar.DisplayMemberPath = "Fecha_Nacimiento";
                    dgllenar.DisplayMemberPath = "Fecha";



                    dgllenar.SelectedValuePath = "Id_Cliente";
                    dgllenar.ItemsSource = tabla1.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void BtnListado_Click(object sender, RoutedEventArgs e)
        {


            PanelListado.Visibility = Visibility.Visible;
            PanelMantenimientoBotones.Visibility = Visibility.Hidden;
            PanelMantenimientoPart1.Visibility = Visibility.Hidden;


        }

        private void BtnMantenimiento_Click(object sender, RoutedEventArgs e)
        {
            PanelMantenimientoPart1.Visibility = Visibility.Visible;


            PanelMantenimientoBotones.Visibility = Visibility.Visible;
            PanelListado.Visibility = Visibility.Hidden;
        }

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {

            this.Close();




        }
        private void BtnMax_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
            btnRest.Visibility = Visibility.Visible;
            btnMax.Visibility = Visibility.Collapsed;
            PanelListado.Width = 1200;
        }

        private void BtnRest_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Normal;
            btnMax.Visibility = Visibility.Visible;
            btnRest.Visibility = Visibility.Collapsed;
            PanelListado.Width = 1000;
        }

        #region  Efectos Brillo al Pasar el Mouse

        private void BtnListado_MouseEnter(object sender, MouseEventArgs e)
        {

            btnListado.Background = Brushes.Blue;

        }

        private void BtnListado_MouseLeave(object sender, MouseEventArgs e)
        {
            btnListado.Background = new SolidColorBrush(Color.FromRgb(27, 100, 207));
        }

        private void BtnCerrar_MouseLeave(object sender, MouseEventArgs e)
        {
            btnCerrar.Background = new SolidColorBrush(Color.FromRgb(27, 100, 207));
        }



        private void BtnCerrar_MouseEnter(object sender, MouseEventArgs e)
        {
            btnCerrar.Background = Brushes.Crimson;
        }



        private void BtnMax_MouseEnter(object sender, MouseEventArgs e)
        {
            btnMax.Background = Brushes.Blue;
        }

        private void BtnMax_MouseLeave(object sender, MouseEventArgs e)
        {
            btnMax.Background = new SolidColorBrush(Color.FromRgb(27, 100, 207));
        }


        private void BtnMantenimiento_MouseEnter(object sender, MouseEventArgs e)
        {
            btnMantenimiento.Background = Brushes.Blue;
        }

        private void BtnMantenimiento_MouseLeave(object sender, MouseEventArgs e)
        {
            btnMantenimiento.Background = new SolidColorBrush(Color.FromRgb(27, 100, 207));
        }

        private void BtnRest_MouseEnter(object sender, MouseEventArgs e)
        {

            btnMantenimiento.Background = Brushes.Blue;
        }


        private void BtnRest_MouseLeave(object sender, MouseEventArgs e)
        {
            btnMantenimiento.Background = new SolidColorBrush(Color.FromRgb(27, 100, 207));
        }

        #endregion

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //DragMove();
        }

        private void BtnLBuscarVentas_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Cliente WHERE Nombre = @nombre ";



                SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);


                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {

                    sqlCommand.Parameters.AddWithValue("@nombre", txtBuscar.Text);


                    DataTable tabla = new DataTable();


                    sqlDataAdapter.Fill(tabla);

                    dgllenar.DisplayMemberPath = "Id_Cliente";
                    dgllenar.DisplayMemberPath = "Nombre";
                    dgllenar.DisplayMemberPath = "Apellido";
                    dgllenar.DisplayMemberPath = "Genero";
                    dgllenar.DisplayMemberPath = "Direccion";
                    dgllenar.DisplayMemberPath = "Telefono";
                    dgllenar.DisplayMemberPath = "Correo";
                    dgllenar.DisplayMemberPath = "Fecha_Nacimiento";
                    dgllenar.DisplayMemberPath = "Fecha";



                    dgllenar.SelectedValuePath = "Id_Cliente";
                    dgllenar.ItemsSource = tabla.DefaultView;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnLEliminarVentas_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombre.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar una categoria");
                txtNombre.Focus();
            }
            else
            {
                try
                {
                    string query = "DELETE Cliente WHERE Nombre =  @nombre";

                    SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);



                    sqlconnection.Open();

                    sqlCommand.Parameters.AddWithValue("@nombre", txtBuscar.Text);
                    sqlCommand.ExecuteNonQuery();


                    txtNombre.Text = String.Empty;

                    MessageBox.Show("Se ha borrado exitosamente");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    sqlconnection.Close();
                    Mostrar();
                }
            }
        }

        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtgenero.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtIdentidad.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txbfechanacimiento.Text = string.Empty;
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombre.Text == string.Empty && txtApellido.Text == string.Empty && txtgenero.Text == string.Empty && txtDireccion.Text == string.Empty && txtIdentidad.Text == string.Empty && txtTelefono.Text == string.Empty && txtCorreo.Text==string.Empty)
            {
                MessageBox.Show("Debe rellenar todos los campos vacios.");
                txtNombre.Focus();

            }
            else
            {
                try
                {
                    string query = "INSERT INTO Cliente(Nombre,Apellido,Genero,Direccion,Telefono,Correo,Fecha_Nacimiento) VALUES(@nombre,@apellido,@genero,@direccion,@telefono,@correo,@fecha_Nacimiento)";

                    SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);

                    sqlconnection.Open();
                   
                    sqlCommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    sqlCommand.Parameters.AddWithValue("@apellido", txtApellido.Text);
                    sqlCommand.Parameters.AddWithValue("@genero", txtgenero.Text);
                    sqlCommand.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                    sqlCommand.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                    sqlCommand.Parameters.AddWithValue("@correo", txtCorreo.Text);
                    sqlCommand.Parameters.AddWithValue("@fecha_Nacimiento", DpFecha.ToString());

                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    sqlconnection.Close();
                    Mostrar();
                }
            }
        }

       private void BtnEditar_Click(object sender, RoutedEventArgs e)
         {
            if (txtNombre.Text == string.Empty)
            {
                MessageBox.Show("Debes ingresar el nuevo nombre del cliente en la caja de texto.");
                txtNombre.Focus();
            }
            else
            {
                try
                {
                    string query = "UPDATE Cliente SET Nombre,Apellido,Genero,Direccion,Telefono,Correo,Fecha_Nacimiento = @nombre,@apellido,@genero,@direccion,@telefono,@correo,@fecha_Nacimiento WHERE Nombre = @Id_Cliente";
                    
                    SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);

                    sqlconnection.Open();
                    sqlCommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    sqlCommand.Parameters.AddWithValue("@apellido", txtApellido.Text);
                    sqlCommand.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                    sqlCommand.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                    sqlCommand.Parameters.AddWithValue("@correo", txtCorreo.Text);
                    sqlCommand.Parameters.AddWithValue("@fecha_Nacimiento", txbfechanacimiento.Text);
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    sqlconnection.Close();
                    Mostrar();
                }
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtgenero.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtIdentidad.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtTelefono.Text = string.Empty;
        }
    }
}

