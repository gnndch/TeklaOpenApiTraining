using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Plugins;

namespace BeamPlugin
{
    public class PluginData
    {
        [StructuresField("beamClass")]
        public string beamClass;
    }
}
