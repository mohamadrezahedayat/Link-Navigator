using Autodesk.Navisworks.Api.Plugins;
using System;
using System.Windows.Forms;
using Training.Ctr;


namespace AddinRibbon
{
    [Plugin("SbrTools", "MohamadrezaHedayat", DisplayName = "Sbr Tools")]
    [RibbonLayout("Ribbon.xaml")]
    [RibbonTab("SbrTools_tab_1", DisplayName = "SBR Custom Tab")]
    [Command("btnUpdate", Icon = "update_16.png", LargeIcon = "update_32.png", ToolTip = "NavisWorks Dynamic Update")]
    [Command("btnProperty", Icon = "property_16.png", LargeIcon = "property_32.png", ToolTip = "NavisWorks Properties Finder")]
    [Command("btnLinks", Icon = "link_16.jpg", LargeIcon = "link_32.jpg", ToolTip = "NavisWorks Links Navigator")]

    public class LNAddin : CommandHandlerPlugin
    {
        public override int ExecuteCommand(string name, params string[] parameters)
        {
            switch (name)
            {
                case "btnUpdate":
                    if (!Autodesk.Navisworks.Api.Application.IsAutomated)
                    {
                        var pluginRecord = Autodesk.Navisworks.Api.Application.Plugins.FindPlugin("DockpanelUpdate.MohamadrezaHedayat");
                        if (pluginRecord is DockPanePluginRecord && pluginRecord.IsEnabled)
                        {
                            var docPanel = (DockPanePlugin)(pluginRecord.LoadedPlugin ?? pluginRecord.LoadPlugin());
                            docPanel.ActivatePane();
                        }
                    }
                    break;

                case "btnProperty":
                    if (!Autodesk.Navisworks.Api.Application.IsAutomated)
                    {
                        var pluginRecord = Autodesk.Navisworks.Api.Application.Plugins.FindPlugin("DockpanelPropery.MohamadrezaHedayat");
                        if (pluginRecord is DockPanePluginRecord && pluginRecord.IsEnabled)
                        {
                            var docPanel = (DockPanePlugin)(pluginRecord.LoadedPlugin ?? pluginRecord.LoadPlugin());
                            docPanel.ActivatePane();
                        }
                    }

                    break;
                case "btnLinks":
                    if (!Autodesk.Navisworks.Api.Application.IsAutomated)
                    {
                        var pluginRecord = Autodesk.Navisworks.Api.Application.Plugins.FindPlugin("LinkNavigator.MohamadrezaHedayat");
                        if (pluginRecord is DockPanePluginRecord && pluginRecord.IsEnabled)
                        {
                            var docPanel = (DockPanePlugin)(pluginRecord.LoadedPlugin ?? pluginRecord.LoadPlugin());
                            docPanel.ActivatePane();
                        }
                    }
                    break;

            }
            return 0;
        }
    }
}

namespace UpdateDockPanel
{
    [Plugin("DockpanelUpdate", "MohamadrezaHedayat", DisplayName = "Dynamic Update")]
    [DockPanePlugin(200, 400, AutoScroll = true, MinimumHeight = 100, MinimumWidth = 200)]
    public class DockpanelUpdate : DockPanePlugin
    {
        public override Control CreateControlPane()
        {
            return new UcUpdate { Dock = DockStyle.Fill };
        }
        public override void DestroyControlPane(Control pane)
        {
            try
            {
                var ctr = (UcUpdate)pane;
                ctr?.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
        }
    }


    public class DockPanelLinks
    {

    }
}

namespace property
{
    [Plugin("DockpanelPropery", "MohamadrezaHedayat", DisplayName = "Property Finder")]
    [DockPanePlugin(200, 400, AutoScroll = true, MinimumHeight = 100, MinimumWidth = 200)]
    public class DockpanelProperty : DockPanePlugin
    {
        public override Control CreateControlPane()
        {
            return new UcProperty { Dock = DockStyle.Fill };
        }
        public override void DestroyControlPane(Control pane)
        {
            try
            {
                var ctr = (UcProperty)pane;
                ctr?.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
        }
    }
}

namespace LinkNavigator
{
    [Plugin("LinkNavigator", "MohamadrezaHedayat", DisplayName = "Link Navigator")]
    [DockPanePlugin(200, 400, AutoScroll = true, MinimumHeight = 100, MinimumWidth = 200)]
    public class DockpanelProperty : DockPanePlugin
    {
        public override Control CreateControlPane()
        {
            //return new UcLinks { Dock = DockStyle.Fill };
            var tc = new TabControl();
            tc.ParentChanged += SetDockStyle;

            var tp1 = new TabPage("Link Grid");
            tp1.Controls.Add(new UcLinkGrid());
            tc.TabPages.Add(tp1);

            var tp2 = new TabPage("Link Logger");
            tp2.Controls.Add(new UcLinks());
            tc.TabPages.Add(tp2);

            return tc;

        }

        private void SetDockStyle(object sender, EventArgs e)
        {
            try
            {
                var tc = sender as TabControl;
                tc.Dock = DockStyle.Fill;
            }
            catch (Exception)
            {

                
            }
        }

        public override void DestroyControlPane(Control pane)
        {
            try
            {
                var ctr = (TabControl)pane;
                ctr?.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
        }
    }
}