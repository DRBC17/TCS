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
    /// Lógica de interacción para Articulo.xaml
    /// </summary>
    public partial class Articulo : Window
    {
        SqlConnection sqlconnection;
   

        public bool IsNuevo { get; private set; }
        public bool IsEditar { get; private set; }

        public Articulo()
        {
            InitializeComponent();
            
            string connectionString = @"server=(local)\SQLEXPRESS;Initial Catalog=TecnoCell;Integrated Security=True";
            sqlconnection = new SqlConnection(connectionString);


            Mostrar();
            Mostrar_Categoria();
        }

        private void Mostrar()
        {
            try
            {

                string query = "SELECT * FROM Articulo";

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlconnection);

                using (sqlDataAdapter)
                {

                    DataTable tabla1 = new DataTable();


                    sqlDataAdapter.Fill(tabla1);

                    dgllenar.DisplayMemberPath = "Id_Articulo";
                    dgllenar.DisplayMemberPath = "Codigo";
                    dgllenar.DisplayMemberPath = "Nombre";
                    dgllenar.DisplayMemberPath = "Descripcion";
                    dgllenar.DisplayMemberPath = "Id_Categoria";
                    dgllenar.DisplayMemberPath = "Fecha";
                    dgllenar.SelectedValuePath = "Id_Articulo";
                    dgllenar.ItemsSource = tabla1.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



        private void Mostrar_Categoria()
        {
            try
            {

                string query = "SELECT * FROM Categoria";

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlconnection);

                using (sqlDataAdapter)
                {

                    DataTable tabla1 = new DataTable();


                    sqlDataAdapter.Fill(tabla1);

                    lbcate.DisplayMemberPath = "Nombre";
                    lbcate.SelectedValuePath = "Id_Categoria";
                    lbcate.ItemsSource = tabla1.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void BtnMantenimiento_Click(object sender, RoutedEventArgs e)
        {
            PanelMantenimiento.Visibility = Visibility.Visible;
            PanelMantenimientoBotones.Visibility = Visibility.Visible;
            PanelListado.Visibility = Visibility.Hidden;
        }

        private void BtnListado_Click(object sender, RoutedEventArgs e)
        {


            PanelListado.Visibility = Visibility.Visible;
            PanelMantenimientoBotones.Visibility = Visibility.Hidden;
            PanelMantenimiento.Visibility = Visibility.Hidden;

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

        private void BtnLBuscarCategoria_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Articulo WHERE Nombre = @nombre ";



                SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);


                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {

                    sqlCommand.Parameters.AddWithValue("@nombre", txtNombre.Text);


                    DataTable tabla = new DataTable();


                    sqlDataAdapter.Fill(tabla);

                    dgllenar.DisplayMemberPath = "Id_Articulo";
                    dgllenar.DisplayMemberPath = "Codigo";
                    dgllenar.DisplayMemberPath = "Nombre";
                    dgllenar.DisplayMemberPath = "Descripcion";
                    dgllenar.DisplayMemberPath = "Id_Categoria";
                    dgllenar.DisplayMemberPath = "Fecha";
                    dgllenar.SelectedValuePath = "Id_Articulo";
                    dgllenar.ItemsSource = tabla.DefaultView;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombre.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar el nombre del articulo");
                txtNombre.Focus();
            }
            else
            {
                try
                {
                    string query = "DELETE Articulo WHERE Nombre =  @nombre";

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
            txtCodigoVentas.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtNombre.Text = string.Empty;
            lbcate.SelectedValue = null;
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (txtCodigoVentas.Text != string.Empty && txtNombreMantenimiento.Text != string.Empty && txtDescripcion.Text != string.Empty && lbcate.SelectedValue==null)
            {
                MessageBox.Show("Debe rellenar todos los campos vacios.");
                txtCodigoVentas.Focus();
                
            }
            else
            {
                try
                {
                    string query = "INSERT INTO Articulo(Codigo,Nombre,Descripcion,Id_Categoria) VALUES(@codigo,@nombre,@descripcion,@id_Categoria)";

                    SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);

                    sqlconnection.Open();
                    //string f;
                    //f = DateTime.Now.ToString();
                    sqlCommand.Parameters.AddWithValue("@codigo", txtCodigoVentas.Text);
                    sqlCommand.Parameters.AddWithValue("@nombre", txtNombreMantenimiento.Text);
                    sqlCommand.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                    sqlCommand.Parameters.AddWithValue("@id_Categoria", lbcate.SelectedValue.ToString());
                    //sqlCommand.Parameters.AddWithValue("@fecha", f);


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
            if (txtCodigoVentas.Text == string.Empty)
            {
                MessageBox.Show("Debes ingresar el nuevo nombre del articulo en la caja de texto.");
                txtCodigoVentas.Focus();
            }
            else
            {
                try
                {
                    string query = "UPDATE Articulo SET Codigo,Nombre,Descripcion,Id_Categoria = @categoria,@nombre,@descripcion,@id_Categoria WHERE Codigo = @codigoVentas";
                    //Articulo(Codigo,Nombre,Descripcion,Id_Categoria,Fecha) VALUES(@codigo,@nombre,@descripcion,@id_Categoria)
                    SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);

                    sqlconnection.Open();

                    sqlCommand.Parameters.AddWithValue("@codigo", txtCodigoVentas.Text);
                    sqlCommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    sqlCommand.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                    sqlCommand.Parameters.AddWithValue("@id_Categoria", lbcate.SelectedValue);
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
            txtCodigoVentas.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtNombre.Text = string.Empty;
            lbcate.SelectedValue = null;
        }


        //private void Botones()
        //{
        //    if (this.IsNuevo || this.IsEditar) //Alt + 124
        //    {
        //        this.Habilitar(true);
        //        this.btnNuevo.IsEnabled = false;
        //        this.btnGuardar.IsEnabled = true;
        //        this.btnEditar.IsEnabled = false;
        //        this.btnCancelar.IsEnabled = true;
        //    }
        //    else
        //    {
        //        this.Habilitar(false);
        //        this.btnNuevo.IsEnabled = true;
        //        this.btnGuardar.IsEnabled = false;
        //        this.btnEditar.IsEnabled = true;
        //        this.btnCancelar.IsEnabled = false;
        //    }

        //}



        ////Limpiar todos los controles del formulario
        //private void Limpiar()
        //{
        //    this.txtCodigoVentas.Text = string.Empty;
        //    this.txtNombreMantenimiento.Text = string.Empty;
        //    this.txtDescripcion.Text = string.Empty;
        //}

        ////Habilitar los controles del formulario
        //private void Habilitar(bool valor)
        //{
        //    this.txtCodigoVentas.IsReadOnly = !valor;
        //    this.txtNombreMantenimiento.IsReadOnly = !valor;
        //    this.txtDescripcion.IsReadOnly = !valor;
        //    this.btnNuevo.IsEnabled = valor;
        //    this.btnGuardar.IsEnabled = valor;
        //    this.btnEditar.IsEnabled = valor;
        //    this.btnCancelar.IsEnabled = valor;
        //}
    }

}
