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
using TCSv2.View.Windows_Children;

namespace TCSv2.View
{

    /// <summary>
    /// Lógica de interacción para WindowContenedorPrincipal.xaml
    /// </summary>
    public partial class WindowContenedorPrincipal : Window
    {
        public bool categoriaPush;
        public bool articuloPush;
        public bool ventasPush;
        public bool clientesPush;
        public bool comprasPush;
        public bool proveedoresPush;
        public bool usuariosPush;
        public bool cStockPush;

        public WindowContenedorPrincipal()
        {
            InitializeComponent();
            Inicializar_Push();
        }

        public void Inicializar_Push()
        {
            categoriaPush = false;
            articuloPush = false;
            ventasPush = false;
            clientesPush = false;
            comprasPush = false;
            proveedoresPush = false;
            usuariosPush = false;
            cStockPush = false;
        }

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnMin_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnCerrarSession_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ventana = new MainWindow();
            ventana.Show();
            this.Close();
        }

    

       
     

        #region Efectos Brillo al Pasar el Mouse

        private void BtnCategoria_MouseLeave(object sender, MouseEventArgs e)
        {
          
            if (categoriaPush == false)
            {
                
                btnCategoria.Background = new SolidColorBrush(Color.FromRgb(27, 100, 207));
            }
        }



        private void BtnAticulos_MouseLeave(object sender, MouseEventArgs e)
        {
            btnAticulos.Background = new SolidColorBrush(Color.FromRgb(27, 100, 207));

        }

        private void BtnCategoria_MouseEnter(object sender, MouseEventArgs e)
        {
            btnCategoria.Background = Brushes.Blue;
           
        }

        private void BtnCerrar_MouseEnter(object sender, MouseEventArgs e)
        {
            btnCerrar.Background = Brushes.Crimson;
        }

        private void BtnCerrar_MouseLeave(object sender, MouseEventArgs e)
        {
            btnCerrar.Background = new SolidColorBrush(Color.FromRgb(27, 100, 207));
        }

        private void BtnMin_MouseEnter(object sender, MouseEventArgs e)
        {
            btnMin.Background = Brushes.Blue;
        }

        private void BtnMin_MouseLeave(object sender, MouseEventArgs e)
        {
            btnMin.Background = new SolidColorBrush(Color.FromRgb(27, 100, 207));
        }

        private void BtnAticulos_MouseEnter(object sender, MouseEventArgs e)
        {
            btnAticulos.Background = Brushes.Blue;
        }

        private void BtnVentas_MouseEnter(object sender, MouseEventArgs e)
        {
            btnVentas.Background = Brushes.Blue;
        }

        private void BtnVentas_MouseLeave(object sender, MouseEventArgs e)
        {
            btnVentas.Background = new SolidColorBrush(Color.FromRgb(27, 100, 207));
        }

        private void BtnClientes_MouseEnter(object sender, MouseEventArgs e)
        {
            btnClientes.Background = Brushes.Blue;
        }

        private void BtnClientes_MouseLeave(object sender, MouseEventArgs e)
        {
            btnClientes.Background = new SolidColorBrush(Color.FromRgb(27, 100, 207));
        }

        private void BtnCpmpras_MouseEnter(object sender, MouseEventArgs e)
        {
            btnCpmpras.Background = Brushes.Blue;
        }

        private void BtnCpmpras_MouseLeave(object sender, MouseEventArgs e)
        {
            btnCpmpras.Background = new SolidColorBrush(Color.FromRgb(27, 100, 207));
        }

        private void BtnProveedores_MouseEnter(object sender, MouseEventArgs e)
        {
            btnProveedores.Background = Brushes.Blue;
        }

        private void BtnProveedores_MouseLeave(object sender, MouseEventArgs e)
        {
            btnProveedores.Background = new SolidColorBrush(Color.FromRgb(27, 100, 207));
        }

        private void BtnUsuarios_MouseEnter(object sender, MouseEventArgs e)
        {
            btnUsuarios.Background = Brushes.Blue;
        }

        private void BtnUsuarios_MouseLeave(object sender, MouseEventArgs e)
        {
            btnUsuarios.Background = new SolidColorBrush(Color.FromRgb(27, 100, 207));
        }

        private void BtnCStock_MouseEnter(object sender, MouseEventArgs e)
        {
            btnCStock.Background = Brushes.Blue;
        }

        private void BtnCStock_MouseLeave(object sender, MouseEventArgs e)
        {
            btnCStock.Background = new SolidColorBrush(Color.FromRgb(27, 100, 207));
        }

        #endregion

        private void BtnCategoria_Click(object sender, RoutedEventArgs e)
        {
            Categoria ventana = new Categoria();
            ventana.Owner = this;
            ventana.Show();
            btnCategoria.Background = Brushes.Blue;
            //btnCategoria.IsEnabled = false;
            // categoriaPush = true;

        }

        private void BtnAticulos_Click(object sender, RoutedEventArgs e)
        {
            Articulo ventana = new Articulo(); 
            ventana.Owner = this;
            ventana.Show();
        }

        private void BtnVentas_Click(object sender, RoutedEventArgs e)
        {
            Ventas ventana = new Ventas();
            ventana.Owner = this;
            ventana.Show();
        }

        private void BtnClientes_Click(object sender, RoutedEventArgs e)
        {
            Clientes ventana = new Clientes();
            ventana.Owner = this;
            ventana.Show();
            
        }

        private void BtnProveedores_Click(object sender, RoutedEventArgs e)
        {
            Proveedores ventana = new Proveedores();
            ventana.Owner = this;
            ventana.Show();
        }

        private void BtnCpmpras_Click(object sender, RoutedEventArgs e)
        {

                Compras ventana = new Compras();
                ventana.Owner = this;
                ventana.Show();
            
        }
    }
}
