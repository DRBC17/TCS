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
        public WindowContenedorPrincipal()
        {
            InitializeComponent();
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

        private void Button_GotFocus(object sender, RoutedEventArgs e)
        {
            
        }

       
        private void BtnCategoria_Click(object sender, RoutedEventArgs e)
        {
            Categoria ventana = new Categoria();
            ventana.Show();
           
        }

        private void BtnCategoria_MouseLeave(object sender, MouseEventArgs e)
        {
            btnCategoria.Background = new SolidColorBrush(Color.FromRgb(27, 100, 207));

            // Background = "#FF1B64CF" 27, 100, 207
        }



        private void BtnAticulos_MouseLeave(object sender, MouseEventArgs e)
        {
            btnAticulos.Background = new SolidColorBrush(Color.FromRgb(27, 100, 207));

        }

        private void BtnCategoria_MouseEnter(object sender, MouseEventArgs e)
        {
            btnCategoria.Background = Brushes.Blue;
           
        }
    }
}
