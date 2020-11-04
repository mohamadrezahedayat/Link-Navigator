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
        [DockPanePlugin(200, 400, AutoScroll = true, MinimumHeight = 100, MinimumWidth = 200)]
 
        public class DockpanelProperty : DockPanePlugin
    {
            public override Control CreateControlPane()
            {
            //return new UcLinks { Dock = DockStyle.Fill };
            //var tc = new TabControl();
            //tc.ParentChanged += SetDockStyle;

            //var tp1 = new TabPage("Link Grid");
            //tp1.Controls.Add(new UcLinkGrid());
            //tc.TabPages.Add(tp1);

            //var tp2 = new TabPage("Link Logger");
            //tp2.Controls.Add(new UcLinks());
            //tc.TabPages.Add(tp2);

            //return tc;


            //create an ElementHost
            ElementHost eh = new ElementHost();
            //assign the control
            eh.AutoSize = true;
            eh.Child = new LinkNavigatorWPFCtr();
            eh.CreateControl();

            //return the ElementHost
            return eh;
        }

            //private void SetDockStyle(object sender, EventArgs e)
            //{
            //    try
            //    {
            //        var tc = sender as TabControl;
            //        tc.Dock = DockStyle.Fill;
            //    }
            //    catch (Exception)
            //    {


            //    }
            //}

            public override void DestroyControlPane(Control pane)
            {
            //try
            //{
            //    var ctr = (TabControl)pane;
            //    ctr?.Dispose();
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show(e.Message);

            //}
            pane.Dispose();
        }
        }
    }

