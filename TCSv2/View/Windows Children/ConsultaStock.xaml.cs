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
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TCSv2.View.Windows_Children
{
    /// <summary>
    /// Lógica de interacción para ConsultaStock.xaml
    /// </summary>
    public partial class ConsultaStock : Window
    {
        SqlConnection sqlconnection;
        public ConsultaStock()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TCSv2.Properties.Settings.TecnoCellConnectionString"].ConnectionString;
            sqlconnection = new SqlConnection(connectionString);
            InitializeComponent();
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


       

        #endregion

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //DragMove();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        #region  Efectos Brillo al Pasar el Mouse







        #endregion

        private void BtnRest_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void BtnRest_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void BtnMax_MouseEnter_1(object sender, MouseEventArgs e)
        {

        }

        private void BtnListado_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnListado_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlconnection.Open();
                string query = "SELECT a.Id_Articulo as Id,a.Codigo,a.Nombre,a.Descripcion,a.Fecha,a.Stock,b.Nombre as Marca,b.Descripcion as Descripcion_Marca FROM Articulo a INNER JOIN Categoria b ON a.Id_Articulo=b.Id_Categoria";
                SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlconnection);

                using (sqlDataAdapter)
                {
                    DataTable tabla1 = new DataTable();

                    sqlDataAdapter.Fill(tabla1);

                    dgcstock.DisplayMemberPath = "Id";
                    dgcstock.DisplayMemberPath = "Codigo";
                    dgcstock.DisplayMemberPath = "Nombre";
                    dgcstock.DisplayMemberPath = "Descripcion";
                    dgcstock.DisplayMemberPath = "Fecha";
                    dgcstock.DisplayMemberPath = "Stock";
                    dgcstock.SelectedValuePath = "Marca";
                    dgcstock.SelectedValuePath = "Descripcion de Marca";
                    dgcstock.ItemsSource = tabla1.DefaultView;
      
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlconnection.Close();
            }
        }
    }
}
