﻿using System;
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
    /// Lógica de interacción para Usuarios.xaml
    /// </summary>
    public partial class Usuarios : Window
    {
        int ID = 0;
        SqlConnection sqlconnection;
        public Usuarios()
        {
            InitializeComponent();
            string connectionString = @"server=(local)\SQLEXPRESS;Initial Catalog=TecnoCell;Integrated Security=True";
            sqlconnection = new SqlConnection(connectionString);

            Mostrar();
            ListarAcceso();
        }

        private void ListarAcceso()
        {
            try
            {
                // El query ha realizar en la BD
                string query = "SELECT * FROM Acceso";

                // SqlDataAdapter es una interfaz entre las tablas y los objetos utilizables en C#
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlconnection);

                using (sqlDataAdapter)
                {
                    // Objecto en C# que refleja una tabla de una BD
                    DataTable tablaP = new DataTable();

                    // Llenar el objeto de tipo DataTable
                    sqlDataAdapter.Fill(tablaP);

                    // ¿Cuál información de la tabla en el DataTable debería se desplegada en nuestro ListBox?
                    cbAcceso.DisplayMemberPath = "Cargos";
                    // ¿Qué valor debe ser entregado cuando un elemento de nuestro ListBox es seleccionado?
                    cbAcceso.SelectedValuePath = "Id_Acceso";
                    // ¿Quién es la referencia de los datos para el ListBox (popular)
                    cbAcceso.ItemsSource = tablaP.DefaultView;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void Mostrar()
        {
            try
            {

                string query = "SELECT * FROM Empleado";

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlconnection);

                using (sqlDataAdapter)
                {

                    DataTable tabla1 = new DataTable();


                    sqlDataAdapter.Fill(tabla1);

                    dgllenar.DisplayMemberPath = "Id_Empleado";
                    dgllenar.DisplayMemberPath = "Nombre";
                    dgllenar.DisplayMemberPath = "Apellido";
                    dgllenar.DisplayMemberPath = "Genero";
                    dgllenar.DisplayMemberPath = "Id_Acceso";
                    dgllenar.DisplayMemberPath = "Contraseña";
                    dgllenar.DisplayMemberPath = "Nombre_Usu";
                    dgllenar.DisplayMemberPath = "Fecha";
                    dgllenar.DisplayMemberPath = "Foto";


                    dgllenar.SelectedValuePath = "Id_Empleado";
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

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnLBuscarVentas_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Empleado WHERE Nombre = @nombre ";



                SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);


                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {

                    sqlCommand.Parameters.AddWithValue("@nombre", txtbuscar.Text);


                    DataTable tabla = new DataTable();


                    sqlDataAdapter.Fill(tabla);

                    dgllenar.DisplayMemberPath = "Id_Empleado";
                    dgllenar.DisplayMemberPath = "Nombre";
                    dgllenar.DisplayMemberPath = "Apellido";
                    dgllenar.DisplayMemberPath = "Genero";
                    dgllenar.DisplayMemberPath = "Id_Acceso";
                    dgllenar.DisplayMemberPath = "Contraseña";
                    dgllenar.DisplayMemberPath = "Nombre_Usu";
                    dgllenar.DisplayMemberPath = "Fecha";
                    dgllenar.DisplayMemberPath = "Foto";


                    dgllenar.SelectedValuePath = "Id_Empleado";
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
            if (txtbuscar.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un nombre");
                txtbuscar.Focus();
            }
            else
            {
                try
                {
                    string query = "DELETE Empleado WHERE Nombre =  @nombre";

                    SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);



                    sqlconnection.Open();

                    sqlCommand.Parameters.AddWithValue("@nombre", txtbuscar.Text);
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
            txtApellido.Text = String.Empty;
            txtNombre.Text = String.Empty;
            txtUsuario.Text = String.Empty;
            txtContra.Password = String.Empty;

        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
     
                try
                {
                    string query = "INSERT INTO Usuario(Nombre,Contraseña) VALUES(@nombre,@Contra)";

                    SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);

                    sqlconnection.Open();
                
                    sqlCommand.Parameters.AddWithValue("@Nombre", txtUsuario.Text);
                    sqlCommand.Parameters.AddWithValue("@Contra", txtContra.Password);
            
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
                AgregarEmpleado();
                Mostrar();
            }
            
        }

        private void AgregarEmpleado()
        {
            //sqlconnection.Close();
            //try
            //{
            //    string query = "INSERT INTO Empleado(Nombre,Apellido,Genero,Id_Acceso,Id_Usuario) VALUES(@Nombre,@Apellido,@Genero,@Id_Acceso,@Id_Usuario)";

            //    SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);
            //    sqlCommand.Parameters.AddWithValue("@Nombre", txtNombre.Text);
            //    sqlCommand.Parameters.AddWithValue("@Apellido", txtApellido.Text);
            //    sqlCommand.Parameters.AddWithValue("@Genero", cbGnero.SelectedValue.ToString());
            //    sqlCommand.Parameters.AddWithValue("@Id_Acceso", cbAcceso.SelectedValue.ToString());
            //    sqlCommand.Parameters.AddWithValue("@Id_Usuario", BuscarID().ToString());
            //    sqlconnection.Open();
            //    //@Nombre,@Apellido,@Genero,@Id_Acceso,@Id_Usuario
             
        

            //    sqlCommand.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
            //finally
            //{
            //    sqlconnection.Close();
            
            //    Mostrar();
            //}
        }

        private string BuscarID()
        {
            string x="";
            try
            {
                string query = "SELECT Id_Usuario FROM Usuario WHERE Nombre=@Usuario";

                sqlconnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);
                // Reemplazar el parámetro con su valor respectivo
                sqlCommand.Parameters.AddWithValue("@Usuario", txtUsuario.Text);
                sqlCommand.ExecuteNonQuery();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                
                    x = reader["Id_Usuario"].ToString();
               

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

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombre.Text == string.Empty)
            {
                MessageBox.Show("Debes ingresar el nuevo nombre del proveedor en la caja de texto.");
                txtNombre.Focus();
            }
            else
            {
                try
                {
                    string query = "UPDATE Usuario SET Id_Usuario,Nombre,Contraseña, = @Id_Usuario,@Nombre,@contra WHERE Id_Usuario = @Id_Usuario";
                    //Articulo(Codigo,Nombre,Descripcion,Id_Categoria,Fecha) VALUES(@codigo,@nombre,@descripcion,@id_Categoria)
                    SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);

                    sqlconnection.Open();
                    //string f;
                    //f = DateTime.Now.ToString();
                    sqlCommand.Parameters.AddWithValue("@Id_Usuario", txtUsuario.Text);
                    sqlCommand.Parameters.AddWithValue("@Apellido", txtApellido.Text);
                    sqlCommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    sqlCommand.Parameters.AddWithValue("@Contra", txtContra.Password);
                    //sqlCommand.Parameters.AddWithValue("@fecha", f);
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
            txtApellido.Text = String.Empty;
            txtNombre.Text = String.Empty;
            txtUsuario.Text = String.Empty;
            txtContra.Password = String.Empty;
        }
    }
}
