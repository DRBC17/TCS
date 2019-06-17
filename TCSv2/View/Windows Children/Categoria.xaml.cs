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

        }

        private void BtnCategoria_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
