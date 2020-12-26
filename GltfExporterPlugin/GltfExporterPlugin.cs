using Autodesk.Navisworks.Api.Plugins;
using LinkNavigator.Ctr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace LinkNavigator
{

    [Plugin("gltfExporter", "MohamadrezaHedayat", DisplayName = "Gltf Exporter")]
    [DockPanePlugin(200, 400, AutoScroll = true, FixedSize = false, MinimumHeight = 100, MinimumWidth = 200)]
    class GltfExporterPlugin:DockPanePlugin
    {

        public override Control CreateControlPane()
        {
            //create an ElementHost
            ElementHost eh = new ElementHost();
            //assign the control
            eh.AutoSize = true;
            eh.Child = new GltfExporterCtr();
            eh.CreateControl();


            //return the ElementHost
            return eh;
        }

        public override void DestroyControlPane(Control pane)
        {
            pane.Dispose();
        }
    }
}
