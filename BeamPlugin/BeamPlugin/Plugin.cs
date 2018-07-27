using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;
using Tekla.Structures.Plugins;

namespace BeamPlugin
{
    [Plugin("BeamPlugin")]
    [PluginUserInterface("BeamPlugin.MainWindow")]
    public class Plugin : PluginBase
    {
        private PluginData data;

        public Plugin(PluginData data)
        {
            this.data = data;
        }

        public override List<InputDefinition> DefineInput()
        {
            Picker picker = new Picker();
            List<InputDefinition> inputList = new List<InputDefinition>();
            Tekla.Structures.Geometry3d.Point p1 = picker.PickPoint("Укажите точку");
            InputDefinition input1 = new InputDefinition(p1);
            inputList.Add(input1);

            return inputList;
        }

        public override bool Run(List<InputDefinition> Input)
        {
            Tekla.Structures.Geometry3d.Point point = Input[0].GetInput() as Tekla.Structures.Geometry3d.Point;
            Tekla.Structures.Geometry3d.Point point2 = new Tekla.Structures.Geometry3d.Point(1000, 0, 0);
            Beam beam = new Beam { StartPoint = point, EndPoint = point2 };
            beam.Profile.ProfileString = "I30K1_20_93";
            beam.Finish = "PAINT";
            beam.Class = data.beamClass;
            bool result = false;
            result = beam.Insert();

            return true;
        }
    }
}
