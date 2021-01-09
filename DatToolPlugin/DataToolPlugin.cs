using Autodesk.Navisworks.Api.Plugins;
using LinkNavigator.DatToolPlugin.Ctr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace LinkNavigator.DatToolPlugin
{
    [Plugin("DataTool", "MohamadrezaHedayat", DisplayName = "Data Tool")]
    [DockPanePlugin(400, 400, AutoScroll = true, FixedSize = false, MinimumHeight = 200, MinimumWidth = 200)]
    class DataToolPlugin : DockPanePlugin
    {
        public override Control CreateControlPane()
        {
            //create an ElementHost
            ElementHost eh = new ElementHost();
            //assign the control
            eh.AutoSize = true;
            eh.Child = new DataToolCtr();
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

