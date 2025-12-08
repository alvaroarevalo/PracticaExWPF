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

namespace PracticaEx.MVVM.View
{
    /// <summary>
    /// Lógica de interacción para ListaTareas.xaml
    /// </summary>
    public partial class ListaTareas : Page
    {
        public ListaTareas()
        {
            InitializeComponent();
        }

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {
            MainFrame.Navigate(new TareasCompletas());
        }
    }
}
