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
using TSD = Tekla.Structures.Drawing;

namespace DrawingDrawings
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
            string s = string.Empty;

            TSD.DrawingHandler handler = new TSD.DrawingHandler();

            // Получить чертежи в модели.
            TSD.DrawingEnumerator drawings = handler.GetDrawings();
            while (drawings.MoveNext())
            {
                if (drawings.Current is TSD.Drawing drawing)
                {
                    s += drawing.Name + "\r\n";
                }
            }

            MessageBox.Show(s);
        }
    }
}
