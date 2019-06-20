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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TCSv2.View;

namespace TCSv2
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void BtnIniciar_Click(object sender, RoutedEventArgs e)
        {
            WindowContenedorPrincipal ventana = new WindowContenedorPrincipal();
            ventana.Show();
            this.Close();
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnIniciar_MouseEnter(object sender, MouseEventArgs e)
        {
            btnIniciar.Background = Brushes.Blue;
        }

        private void BtnIniciar_MouseLeave(object sender, MouseEventArgs e)
        {
            btnIniciar.Background = new SolidColorBrush(Color.FromRgb(27, 100, 207));
        }

        private void BtnSalir_MouseEnter(object sender, MouseEventArgs e)
        {
            btnSalir.Background = Brushes.Crimson;
        }

        private void BtnSalir_MouseLeave(object sender, MouseEventArgs e)
        {
            btnSalir.Background = new SolidColorBrush(Color.FromRgb(27, 100, 207));
        }
    }
}
