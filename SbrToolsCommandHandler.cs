using Autodesk.Navisworks.Api.Plugins;

namespace LinkNavigator
{
    [Plugin("SbrTools", "MohamadrezaHedayat", DisplayName = "Sbr Tools")]

    [RibbonLayout("Ribbon.xaml")]

    //tab id = tab Id in xaml file
    [RibbonTab("SbrTools_tab_1", DisplayName = "SBR Tools")]
  
    //add other commands here
    [Command("btnLinks", Icon = "link_16.jpg", LargeIcon = "link_32.jpg", ToolTip = "NavisWorks Links Navigator")]

    public class SbrToolsCommandHandler : CommandHandlerPlugin
    {
        public override int ExecuteCommand(string name, params string[] parameters)
        {
            switch (name)
            {
                case "btnLinks":
                    if (!Autodesk.Navisworks.Api.Application.IsAutomated)
                    {
                        var pluginRecord = Autodesk.Navisworks.Api.Application.Plugins.FindPlugin("LinkNavigator.MohamadrezaHedayat");
                        if (pluginRecord != null && pluginRecord is DockPanePluginRecord && pluginRecord.IsEnabled)
                        {
                            var docPanel = (DockPanePlugin)(pluginRecord.LoadedPlugin ?? pluginRecord.LoadPlugin());
                           
                            if (docPanel != null)
                            {
                                //switch the Visible flag
                                docPanel.Visible = !docPanel.Visible;
                            }
                        }
                    }

                //add other command handler here like: case "btnLinks":{..........}
                    break;
            }
            return 0;
        }
    }
}
