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
    /// Lógica de interacción para Ventas.xaml
    /// </summary>
    public partial class Ventas : Window
    {

        SqlConnection sqlconnection;
        public Ventas()
        {
            InitializeComponent();
            FechaSys.Text = DateTime.Now.ToString("dd/MM/yyyy");
            string connectionString = @"server=(local)\SQLEXPRESS;Initial Catalog=TecnoCell;Integrated Security=True";
            sqlconnection = new SqlConnection(connectionString);

            Mostrar();
            ListarArticulos();
            ListarClientes();
            ListarComprobantes();
            double isv = Mostrar_ISC() * 100;
            txtISV.Text = string.Format("{0}%", isv);
            txtISV.IsEnabled = false;
        }

        private void ListarComprobantes()
        {
            try
            {
                // El query ha realizar en la BD
                string query = "SELECT * FROM Comprobante";

                // SqlDataAdapter es una interfaz entre las tablas y los objetos utilizables en C#
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlconnection);

                using (sqlDataAdapter)
                {
                    // Objecto en C# que refleja una tabla de una BD
                    DataTable tablaA = new DataTable();

                    // Llenar el objeto de tipo DataTable
                    sqlDataAdapter.Fill(tablaA);

                    // ¿Cuál información de la tabla en el DataTable debería se desplegada en nuestro ListBox?
                    cbComprobante.DisplayMemberPath = "Tipo";
                    // ¿Qué valor debe ser entregado cuando un elemento de nuestro ListBox es seleccionado?
                    cbComprobante.SelectedValuePath = "Id_Comprobante";
                    // ¿Quién es la referencia de los datos para el ListBox (popular)
                    cbComprobante.ItemsSource = tablaA.DefaultView;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void ListarArticulos()
        {
            try
            {
                // El query ha realizar en la BD
                string query = "SELECT * FROM Articulo";

                // SqlDataAdapter es una interfaz entre las tablas y los objetos utilizables en C#
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlconnection);

                using (sqlDataAdapter)
                {
                    // Objecto en C# que refleja una tabla de una BD
                    DataTable tablaA = new DataTable();

                    // Llenar el objeto de tipo DataTable
                    sqlDataAdapter.Fill(tablaA);

                    // ¿Cuál información de la tabla en el DataTable debería se desplegada en nuestro ListBox?
                    cbArticulo.DisplayMemberPath = "Nombre";
                    // ¿Qué valor debe ser entregado cuando un elemento de nuestro ListBox es seleccionado?
                    cbArticulo.SelectedValuePath = "Id_Articulo";
                    // ¿Quién es la referencia de los datos para el ListBox (popular)
                    cbArticulo.ItemsSource = tablaA.DefaultView;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void ListarClientes()
        {
            try
            {
                // El query ha realizar en la BD
                string query = "SELECT * FROM Cliente";

                // SqlDataAdapter es una interfaz entre las tablas y los objetos utilizables en C#
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlconnection);

                using (sqlDataAdapter)
                {
                    // Objecto en C# que refleja una tabla de una BD
                    DataTable tablaP = new DataTable();

                    // Llenar el objeto de tipo DataTable
                    sqlDataAdapter.Fill(tablaP);

                    // ¿Cuál información de la tabla en el DataTable debería se desplegada en nuestro ListBox?
                    cbCliente.DisplayMemberPath = "Nombre";
                    // ¿Qué valor debe ser entregado cuando un elemento de nuestro ListBox es seleccionado?
                    cbCliente.SelectedValuePath = "Id_Cliente";
                    // ¿Quién es la referencia de los datos para el ListBox (popular)
                    cbCliente.ItemsSource = tablaP.DefaultView;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private double Mostrar_ISC()
        {
            double ISV = 0;

            try
            {
                string query = "SELECT ISV FROM ISV";

                sqlconnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);
                // Reemplazar el parámetro con su valor respectivo

                sqlCommand.ExecuteNonQuery();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    string x;
                    x = reader["ISV"].ToString();
                    ISV = double.Parse(x);

                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                sqlconnection.Close();
            }



            return ISV;
        }
        private void Mostrar()
        {
            try
            {

                string query = "SELECT * FROM Venta";

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlconnection);

                using (sqlDataAdapter)
                {

                    DataTable tabla1 = new DataTable();


                    sqlDataAdapter.Fill(tabla1);

                    dgllenar.DisplayMemberPath = "Id_Venta";
                    dgllenar.DisplayMemberPath = "Id_Empleado";
                    dgllenar.DisplayMemberPath = "Id_Cliente";
                    dgllenar.DisplayMemberPath = "Id_Comprobante";
                    dgllenar.DisplayMemberPath = "Id_Detalle_Venta";
                    dgllenar.DisplayMemberPath = "Serie";
                    dgllenar.DisplayMemberPath = "Correlativo";
                    dgllenar.DisplayMemberPath = "Id_ISV";
                    dgllenar.DisplayMemberPath = "Fecha";

                    dgllenar.SelectedValuePath = "Id_Venta";
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
            PanelMantenimientoPart2.Visibility = Visibility.Hidden;
            PanelMantenimientoPart3.Visibility = Visibility.Hidden;
            PanelMantenimientoPart4.Visibility = Visibility.Hidden;
        }

        private void BtnMantenimiento_Click(object sender, RoutedEventArgs e)
        {
            PanelMantenimientoPart1.Visibility = Visibility.Visible;
            PanelMantenimientoPart2.Visibility = Visibility.Visible;
            PanelMantenimientoPart3.Visibility = Visibility.Visible;
            PanelMantenimientoPart4.Visibility = Visibility.Visible;
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
                string query = "SELECT * FROM Categoria WHERE Fecha = @fecha ";



                SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);


                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {

                    sqlCommand.Parameters.AddWithValue("@fecha", DpInicialFecha.Text);


                    DataTable tabla = new DataTable();


                    sqlDataAdapter.Fill(tabla);


                    dgllenar.DisplayMemberPath = "Id_Venta";
                    dgllenar.DisplayMemberPath = "Id_Empleado";
                    dgllenar.DisplayMemberPath = "Id_Cliente";
                    dgllenar.DisplayMemberPath = "Id_Comprobante";
                    dgllenar.DisplayMemberPath = "Id_Detalle_Venta";
                    dgllenar.DisplayMemberPath = "Serie";
                    dgllenar.DisplayMemberPath = "Correlativo";
                    dgllenar.DisplayMemberPath = "Id_ISV";
                    dgllenar.DisplayMemberPath = "Fecha";

                    dgllenar.SelectedValuePath = "Id_Venta";
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
            if (DpInicialFecha.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar una categoria");
                DpInicialFecha.Focus();
            }
            else
            {
                try
                {
                    string query = "DELETE Venta WHERE Nombre =  @nombre";

                    SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);



                    sqlconnection.Open();

                    sqlCommand.Parameters.AddWithValue("@nombre", dgllenar.SelectedValue);
                    sqlCommand.ExecuteNonQuery();


                    

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
            cbArticulo.SelectedValue = null;
            txtCantidadVentas.Text = string.Empty;
            cbCliente.SelectedValue = null;
            txtDescuento.Text = string.Empty;
            txtISV.Text = string.Empty;
            txtNumero.Text = string.Empty;
            txtPrecioCompra.Text = string.Empty;
            txtPrecioVenta.Text = string.Empty;
            cbComprobante.SelectedValue = null;
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            //if (txtArticulo.Text == string.Empty && txtCantidadVentas.Text == string.Empty && txtCliente.Text == string.Empty && txtNumero.Text == string.Empty && txtPrecioCompra.Text == string.Empty && txtPrecioVenta.Text == string.Empty && lbcate.SelectedValue == null)
            //{
            //    MessageBox.Show("Debe rellenar todos los campos vacios.");
            //    txtArticulo.Focus();

            //}
            //else
            //{
            //    try
            //    {
            //        string query = "INSERT INTO Venta (Id_Empleado,Id_Cliente,Id_Comprobante,Id_Detalle_Venta,Serie, Correlativo, Id_ISV) VALUES(@id_Empleado,@id_Cliente,@id_Comprobante,@id_Detalle_Venta,@serie,@correlativo,@id_ISV)";

            //        SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);

            //        sqlconnection.Open();
                    
            //        sqlCommand.Parameters.AddWithValue("@id_Empleado", txt.Text);
            //        sqlCommand.Parameters.AddWithValue("@id_Cliente", txtCliente.Text);
            //        sqlCommand.Parameters.AddWithValue("@id_Comprobante", lbcate.SelectedValue.ToString());
            //        sqlCommand.Parameters.AddWithValue("@id_Detalle_Venta",txtPrecioVenta.Text);
            //        sqlCommand.Parameters.AddWithValue("@serie", txtSerie.Text);
                   
            //        sqlCommand.ExecuteNonQuery();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.ToString());
            //    }
            //    finally
            //    {
            //        sqlconnection.Close();
            //        Mostrar();
            //    }
            //}

        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            cbArticulo.SelectedValue = null;
            txtCantidadVentas.Text = string.Empty;
            cbCliente.SelectedValue = null;
            txtDescuento.Text = string.Empty;
            txtISV.Text = string.Empty;
            txtNumero.Text = string.Empty;
            txtPrecioCompra.Text = string.Empty;
            txtPrecioVenta.Text = string.Empty;
            cbComprobante.SelectedValue = null;
        }
    }
}
