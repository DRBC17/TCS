using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Lógica de interacción para Compras.xaml
    /// </summary>
    public partial class Compras : Window
    {
        double total = 0;
        SqlConnection sqlconnection;
        public Compras()
        {

            InitializeComponent();

            FechaSys.Text = DateTime.Now.ToString();

            string connectionString = ConfigurationManager.ConnectionStrings["TCSv2.Properties.Settings.TecnoCellConnectionString"].ConnectionString;
            sqlconnection = new SqlConnection(connectionString);
            ListarArticulos();
            ListarProveedor();
            ListarComprobantes();
            double isv= Mostrar_ISC() * 100;
            txtISV.Text = string.Format("{0}%",isv);
            txtISV.IsEnabled = false;
            Mostrar();
        }
        private void Mostrar()
        {
            try
            {

                string query = "SELECT * FROM Compra";

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlconnection);

                using (sqlDataAdapter)
                {

                    DataTable tabla1 = new DataTable();


                    sqlDataAdapter.Fill(tabla1);

                    dgllenar.DisplayMemberPath = "Id_Compra";
                    dgllenar.DisplayMemberPath = "Id_Proveedor";
                    dgllenar.DisplayMemberPath = "Id_Detalle_Compra";
                    dgllenar.DisplayMemberPath = "Serie";
         
                    dgllenar.DisplayMemberPath = "Id_ISV";
                    dgllenar.DisplayMemberPath = "Estado";
                    dgllenar.DisplayMemberPath = "Fecha";


                    dgllenar.SelectedValuePath = "Id_Compra";
                    dgllenar.ItemsSource = tabla1.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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

        private void ListarProveedor()
        {
            try
            {
                // El query ha realizar en la BD
                string query = "SELECT * FROM Proveedor";

                // SqlDataAdapter es una interfaz entre las tablas y los objetos utilizables en C#
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlconnection);

                using (sqlDataAdapter)
                {
                    // Objecto en C# que refleja una tabla de una BD
                    DataTable tablaP = new DataTable();

                    // Llenar el objeto de tipo DataTable
                    sqlDataAdapter.Fill(tablaP);

                    // ¿Cuál información de la tabla en el DataTable debería se desplegada en nuestro ListBox?
                    cbProveedor.DisplayMemberPath = "Nombre";
                    // ¿Qué valor debe ser entregado cuando un elemento de nuestro ListBox es seleccionado?
                    cbProveedor.SelectedValuePath = "Id_Proveedor";
                    // ¿Quién es la referencia de los datos para el ListBox (popular)
                    cbProveedor.ItemsSource = tablaP.DefaultView;
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

        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            txtStockInicial.Text = String.Empty;
            txtNumero.Text = String.Empty;
            txtPrecioCompra.Text = String.Empty;
            txtPrecioVenta.Text = String.Empty;
            cbArticulo.SelectedValue = null;
            cbProveedor.SelectedValue = null;
            cbComprobante.SelectedValue = null;
            txttotal.Text = String.Format("0");
            dgDetalle.Columns.Clear();
            btnGuardar.IsEnabled = true;
            btnAgregar.IsEnabled = false;
            Mostrar();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string query = "INSERT INTO Compra(Id_Proveedor, Id_Comprobante,Serie, Id_ISV,Estado) VALUES( @Id_Proveedor, @Id_Comprobante,@serie,@Id_ISV,@estado)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);

                // Abrir la conexión
                sqlconnection.Open();

                // Reemplazar el parámetro con su valor respectivo

                sqlCommand.Parameters.AddWithValue("@Id_Proveedor", cbProveedor.SelectedValue.ToString());
                sqlCommand.Parameters.AddWithValue("@Id_Comprobante", cbComprobante.SelectedValue.ToString());
                sqlCommand.Parameters.AddWithValue("@Id_ISV", "1");
                sqlCommand.Parameters.AddWithValue("@serie", txtNumero.Text.ToString());
                sqlCommand.Parameters.AddWithValue("@estado", "Emitido");
             
           
               // sqlCommand.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("DD/MM/YY"));
                // Ejecutamos el query de inserción
                // https://docs.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlcommand.executescalar
              


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
                // Actualizar el ListBox de Articulos
                btnAgregar.IsEnabled = true;
                btnGuardar.IsEnabled = false;

            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            txtStockInicial.Text = String.Empty;
            txttotal.Text = String.Format("0");
            dgDetalle.Columns.Clear();
            txtNumero.Text = String.Empty;
            txtPrecioCompra.Text = String.Empty;
            txtPrecioVenta.Text = String.Empty;
            btnGuardar.IsEnabled = true;
            btnAgregar.IsEnabled = false;
            ListarArticulos();
            ListarProveedor();
            Mostrar();
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "INSERT INTO Detalle_Compra(Id_Compra, Id_Articulo,Precio_Compra,Precio_Venta,Stock) VALUES(@Id_Compra, @Id_Articulo,@Precio_Compra,@Precio_Venta,@Stock)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);

                // Abrir la conexión


                // @Id_Compra, @Id_Articulo,@Detalle,@Precio_Compra,@Precio_Venta,@Stock

                sqlCommand.Parameters.AddWithValue("@Id_Compra",MostrarId());
                sqlCommand.Parameters.AddWithValue("@Id_Articulo", cbArticulo.SelectedValue.ToString());
                sqlCommand.Parameters.AddWithValue("@Precio_Compra",txtPrecioCompra.Text);
                sqlCommand.Parameters.AddWithValue("@Precio_Venta", txtPrecioVenta.Text);
                sqlCommand.Parameters.AddWithValue("@Stock", txtStockInicial.Text);
               


                // sqlCommand.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("DD/MM/YY"));
                // Ejecutamos el query de inserción
                // https://docs.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlcommand.executescalar

                  sqlconnection.Open();

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
                // Actualizar el ListBox de Articulos
                ListarDetalle_Compra();
                MostrarTotal();
                ListarArticulos();
                txtStockInicial.Text = String.Empty;
                txtPrecioCompra.Text = String.Empty;
                txtPrecioVenta.Text = String.Empty;

            }
        }

        private void MostrarTotal()
        {
            double amt=0;
            try
            {
                string query = "SELECT SUM(Precio_Compra) FROM Detalle_Compra Where Id_Compra=@id";
                SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);
                sqlCommand.Parameters.AddWithValue("@Id", MostrarId());
                sqlconnection.Open();
              amt = (double)sqlCommand.ExecuteScalar();   //arror is at this part
                sqlconnection.Close();
                //total = total + int.Parse(txtPrecioCompra.Text);
                //txttotal.Text = total.ToString();
            }
            catch (Exception ex){
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                txttotal.Text = amt.ToString();
            }

        }

        private void ListarDetalle_Compra()
        {

            try
            {

                string query = "SELECT * FROM Detalle_Compra WHERE Id_Compra=@Id";


                SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlCommand.Parameters.AddWithValue("@Id", MostrarId());
                using (sqlDataAdapter)
                {

                    DataTable tabla1 = new DataTable();


                    sqlDataAdapter.Fill(tabla1);

                    dgDetalle.DisplayMemberPath = "Id_Compra";
                    dgDetalle.DisplayMemberPath = "Id_Articulo";
             
                    dgDetalle.DisplayMemberPath = "Precio_Compra";
                    dgDetalle.DisplayMemberPath = "Precio_Venta";
                    dgDetalle.DisplayMemberPath = "Stock";


                    dgDetalle.SelectedValuePath = "Id_Compra";
                    dgDetalle.ItemsSource = tabla1.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private string MostrarId()
        {
            string x = "";
        

            try
            {
                string query = "select Id_Compra from Compra where Id_Compra=(select MAX(Id_Compra) from Compra)";

                sqlconnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);
                // Reemplazar el parámetro con su valor respectivo

                sqlCommand.ExecuteNonQuery();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                  
                    x = reader["Id_Compra"].ToString();
                  

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



            return x;
        }
    }
}
