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
using TCSv2.View;
using TCSv2;
using System.Data.SqlClient;
using System.Data;

namespace TCSv2.View.Windows_Children
{
    /// <summary>
    /// Lógica de interacción para Categoria.xaml
    /// </summary>
    public partial class Categoria : Window
    {
        SqlConnection sqlconnection;
        public Categoria()
        {
            InitializeComponent();//DESKTOP-JDLKDN3\SQLEXPRESS

            string connectionString = @"server=(local)\SQLEXPRESS;Initial Catalog=TecnoCell;Integrated Security=True";
            sqlconnection = new SqlConnection(connectionString);

            Mostrar();
        }

        private void BtnListado_Click(object sender, RoutedEventArgs e)
        {


            PanelListado.Visibility = Visibility.Visible;
            PanelMantenimientoBotones.Visibility = Visibility.Hidden;
            PanelMantenimiento.Visibility = Visibility.Hidden;

        }

        private void BtnCategoria_Click(object sender, RoutedEventArgs e)
        {
            PanelMantenimiento.Visibility = Visibility.Visible;
            PanelMantenimientoBotones.Visibility = Visibility.Visible;
            PanelListado.Visibility = Visibility.Hidden;
        }

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            //WindowContenedorPrincipal VentanaPrincipal = new WindowContenedorPrincipal();
            //VentanaPrincipal.categoriaPush = false;
            //VentanaPrincipal.btnCategoria.Background = new SolidColorBrush(Color.FromRgb(27, 100, 207));
            //VentanaPrincipal.btnCategoria.IsEnabled = true;
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
        private void Mostrar()
        {
            try
            {

                string query = "SELECT * FROM Categoria";

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlconnection);

                using (sqlDataAdapter)
                {

                    DataTable tabla1 = new DataTable();


                    sqlDataAdapter.Fill(tabla1);

                    dgllenar.DisplayMemberPath = "Id_Categoria";
                    dgllenar.DisplayMemberPath = "Nombre";
                    dgllenar.DisplayMemberPath = "Descripcion";
                    dgllenar.DisplayMemberPath = "Fecha";
                    dgllenar.SelectedValuePath = "Id_Categoria";
                    dgllenar.ItemsSource = tabla1.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnLBuscarCategoria_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Categoria WHERE Nombre = @nombre ";



                SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);


                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {

                    sqlCommand.Parameters.AddWithValue("@nombre", txtNombre.Text);


                    DataTable tabla = new DataTable();


                    sqlDataAdapter.Fill(tabla);

                    dgllenar.DisplayMemberPath = "Id_Categoria";
                    dgllenar.DisplayMemberPath = "Nombre";
                    dgllenar.DisplayMemberPath = "Descripcion";
                    dgllenar.DisplayMemberPath = "Fecha";
                    dgllenar.SelectedValuePath = "Id_Categoria";
                    dgllenar.ItemsSource = tabla.DefaultView;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnLEliminarCategoria_Click(object sender, RoutedEventArgs e)
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
                    string query = "DELETE Categoria WHERE Nombre =  @nombre";

                    SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);



                    sqlconnection.Open();

                    sqlCommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
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
            txtNombreMantenimiento.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombreMantenimiento.Text == string.Empty && txtDescripcion.Text == string.Empty)
            {
                MessageBox.Show("Debe rellenar todos los campos vacios.");
                txtNombreMantenimiento.Focus();

            }
            else
            {
                try
                {
                    string query = "INSERT INTO Categoria(Nombre,Descripcion) VALUES(@nombre,@descripcion)";

                    SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);

                    sqlconnection.Open();
                    sqlCommand.Parameters.AddWithValue("@nombre", txtNombreMantenimiento.Text);
                    sqlCommand.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);


                    if (sqlCommand.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("La operación se ha completado correctamente");
                    }
                    else
                    {
                        MessageBox.Show("La operación No se ha completado correctamente");
                    }
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
            if (txtNombreMantenimiento.Text == string.Empty)
            {
                MessageBox.Show("Debes ingresar el nuevo nombre de la categoria en la caja de texto.");
                txtNombreMantenimiento.Focus();
            }
            else
            {
                try
                {
                    string query = "UPDATE Categoria SET Nombre,Descripcion = @nombre,@descripcion WHERE Nombre = @Id_Categoria";
                   
                    SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);

                    sqlconnection.Open();
                    sqlCommand.Parameters.AddWithValue("@nombre", txtNombreMantenimiento.Text);
                    sqlCommand.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
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
            txtNombreMantenimiento.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
        }
    }
}
