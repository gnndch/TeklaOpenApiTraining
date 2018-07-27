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

namespace DrawingInsertText
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
            TSD.DrawingHandler handler = new TSD.DrawingHandler();

            TSD.Drawing drawing = handler.GetActiveDrawing();

            try
            {
                // Указать точку на чертеже.
                TSD.UI.Picker picker = handler.GetPicker();
                TSG.Point point = new TSG.Point();
                picker.PickPoint("Укажите точку", out point, out TSD.ViewBase view);

                // Вставить текст.
                TSD.Text text = new TSD.Text(view, point, "Привет!");
                text.Insert();

                // Сохранить изменения.
                drawing.CommitChanges();
            }
            catch (TSD.PickerInterruptedException)
            {
            }
        }
    }
}
