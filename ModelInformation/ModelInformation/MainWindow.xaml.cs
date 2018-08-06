using System.Windows;
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
