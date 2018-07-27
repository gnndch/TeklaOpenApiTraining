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
using Tekla.Structures.Model;

namespace ModelInformation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Model model = new Model();

            bool isConnected = model.GetConnectionStatus();
            if (isConnected)
            {
                //string s = model.GetInfo().ModelName;
                string s = model.GetProjectInfo().Name;

                MessageBox.Show(s);
            }
            else
            {
                MessageBox.Show("Модель не открыта.");
            }
        }
    }
}
