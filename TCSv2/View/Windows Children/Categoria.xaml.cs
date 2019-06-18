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

namespace TCSv2.View.Windows_Children
{
    /// <summary>
    /// Lógica de interacción para Categoria.xaml
    /// </summary>
    public partial class Categoria : Window
    {
        public Categoria()
        {
            InitializeComponent();
        }

        private void BtnListado_Click(object sender, RoutedEventArgs e)
        {
            

            PanelListado.Visibility = Visibility.Visible;
            PanelMantenimiento.Visibility = Visibility.Hidden;

        }

        private void BtnCategoria_Click(object sender, RoutedEventArgs e)
        {
            PanelMantenimiento.Visibility = Visibility.Visible;
            PanelListado.Visibility = Visibility.Hidden;
        }

        private void BtnListado_MouseEnter(object sender, MouseEventArgs e)
        {
           // btnListado.Background = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
           btnListado.Background= Brushes.Crimson;

        }

        private void BtnListado_MouseLeave(object sender, MouseEventArgs e)
        {
            btnListado.Background = Brushes.Blue;
        }
    }
}
