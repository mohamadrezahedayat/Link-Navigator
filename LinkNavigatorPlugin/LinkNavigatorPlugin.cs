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
    [Plugin("LinkNavigator", "MohamadrezaHedayat", DisplayName = "Link Navigator")]
    [DockPanePlugin(200, 400, AutoScroll = true, FixedSize =false,MinimumHeight = 100, MinimumWidth = 200)]

    public class DockpanelProperty : DockPanePlugin
    {
        public override Control CreateControlPane()
        {
            //create an ElementHost
            ElementHost eh = new ElementHost();
            //assign the control
            eh.AutoSize = true;
            eh.Child = new LinkNavigatorWPFCtr();
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

