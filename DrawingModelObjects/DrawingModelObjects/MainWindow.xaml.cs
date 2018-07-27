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
using Tekla.Structures.Model;

namespace DrawingModelObjects
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
            Model model = new Model();

            // Выбрать объект на чертеже.
            TSD.UI.Picker picker = handler.GetPicker();
            var p = picker.PickObject("Выберите объект");
            TSD.DrawingObject obj = p.Item1;

            // Получить объект в модели по объекту в чертеже.
            Beam beam = new Beam();
            if (obj != null)
            {
                TSD.ModelObject modelObjectInDrawing = obj as TSD.ModelObject;
                beam = model.SelectModelObject(modelObjectInDrawing.ModelIdentifier) as Beam;
                MessageBox.Show(beam.Profile.ProfileString);
            }
        }
    }
}
