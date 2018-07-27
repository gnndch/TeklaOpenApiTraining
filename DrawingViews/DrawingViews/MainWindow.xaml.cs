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
using TSG = Tekla.Structures.Geometry3d;

namespace DrawingViews
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
            
            // Получить чертеж.
            TSD.Drawing drawing = handler.GetActiveDrawing();
            
            // Получить лист.
            TSD.ContainerView sheet = drawing.GetSheet();

            // Получить виды.
            TSD.DrawingObjectEnumerator views = sheet.GetViews();
            while (views.MoveNext())
            {
                if (views.Current is TSD.View view)
                {
                    s += view.Attributes.Scale + "\r\n";
                }
            }

            MessageBox.Show(s);
        }
    }
}
