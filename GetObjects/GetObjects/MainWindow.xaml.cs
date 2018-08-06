using System.Windows;
using Tekla.Structures.Model;
using TSUI = Tekla.Structures.Model.UI;

namespace GetObjects
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

            Model model = new Model();
            bool isConnected = model.GetConnectionStatus();
            if (isConnected)
            {
                // Получить все объекты в модели.
                //ModelObjectEnumerator objs = model.GetModelObjectSelector().GetAllObjects();

                // Получить выбранные объекты в модели.
                TSUI.ModelObjectSelector selector = new TSUI.ModelObjectSelector();
                ModelObjectEnumerator objs = selector.GetSelectedObjects();

                while (objs.MoveNext())
                {
                    if (objs.Current is Part part)
                    {
                        // Получить имя детали.
                        //s += part.Name + "\r\n";

                        // Получить свойство отчетов.
                        //double value = 0.0;
                        //part.GetReportProperty("LENGTH", ref value);
                        //s += value.ToString() + "\r\n";

                        // Получить пользовательский атрибут.
                        string value = string.Empty;
                        part.GetUserProperty("USER_FIELD_1", ref value);
                        s += value + "\r\n";
                    }
                }

                MessageBox.Show(s);
            }
            else
            {
                MessageBox.Show("Модель не открыта");
            }
        }
    }
}
