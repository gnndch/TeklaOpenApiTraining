using System.Windows;
using Tekla.Structures.Model;
using TSG = Tekla.Structures.Geometry3d;
using TSUI = Tekla.Structures.Model.UI;

namespace CoordinateSystems
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
                // Запомнить текущую систему координат.
                TransformationPlane currentPlane = model.GetWorkPlaneHandler().GetCurrentTransformationPlane();

                TSUI.ModelObjectSelector selector = new TSUI.ModelObjectSelector();
                ModelObjectEnumerator objs = selector.GetSelectedObjects();

                while (objs.MoveNext())
                {
                    if (objs.Current is Beam beam)
                    {
                        // Установить систему координат в систему координат балки.
                        model.GetWorkPlaneHandler().SetCurrentTransformationPlane(new TransformationPlane(beam.GetCoordinateSystem()));

                        TSG.Point point = new TSG.Point(2000, 0, 0);
                        TSG.Point point2 = new TSG.Point(2000, 0, 1000);

                        Beam beam2 = new Beam();
                        beam2.StartPoint = point;
                        beam2.EndPoint = point2;
                        beam2.Profile.ProfileString = "I30K1_57837_2017";
                        beam2.Finish = "PAINT";
                        bool result = false;
                        result = beam2.Insert();
                    }
                }

                model.CommitChanges();

                // Восстановить систему координат.
                model.GetWorkPlaneHandler().SetCurrentTransformationPlane(currentPlane);
            }
            else
            {
                MessageBox.Show("Модель не открыта");
            }
        }
    }
}
