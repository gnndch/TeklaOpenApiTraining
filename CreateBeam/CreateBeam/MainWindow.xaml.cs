using System;
using System.Windows;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;
using TSG = Tekla.Structures.Geometry3d;

namespace CreateBeam
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
                //TSG.Point point = new TSG.Point(0, 0, 0);
                //TSG.Point point2 = new TSG.Point(1000, 0, 0);

                try
                {
                    Picker picker = new Picker();
                    TSG.Point point = picker.PickPoint("Укажите первую точку");
                    TSG.Point point2 = picker.PickPoint("Укажите вторую точку");

                    Beam beam = new Beam();
                    beam.StartPoint = point;
                    beam.EndPoint = point2;
                    beam.Profile.ProfileString = "I30K1_57837_2017";
                    beam.Finish = "PAINT";
                    beam.Class = BeamClass.Text;
                    bool result = false;
                    result = beam.Insert();

                    model.CommitChanges();
                }
                catch (Exception ex)
                {
                    if (ex.Message == "User interrupt")
                    {
                    }
                }
            }
            else
            {
                MessageBox.Show("Модель не открыта.");
            }
        }
    }
}
