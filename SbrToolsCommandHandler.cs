using Autodesk.Navisworks.Api.Plugins;

namespace LinkNavigator
{
    [Plugin("SbrTools", "MohamadrezaHedayat", DisplayName = "Sbr Tools")]

    [RibbonLayout("Ribbon.xaml")]

    //tab id = tab Id in xaml file
    [RibbonTab("SbrTools_tab_1", DisplayName = "SBR Tools")]

    //add other commands here
    [Command("btnLinks", Icon = "link_16.jpg", LargeIcon = "link_32.jpg", ToolTip = "NavisWorks Links Navigator")]
    [Command("btnVault", Icon = "vault16x16.png", LargeIcon = "vault32x32.png", ToolTip = "Vault Viewer Plugin")]
    [Command("btnGltf", Icon = "gltf16x16.png", LargeIcon = "gltf32x32.png", ToolTip = "Gltf Exporter")]

    [Command("addParent", Icon = "addParentx16.png", LargeIcon = "addParentx32.png", ToolTip = "Add Parent")]
    [Command("selectParent", Icon = "goParentx16.png", LargeIcon = "goParentx32.png", ToolTip = "Select Parent")]
    [Command("selectChilds", Icon = "gochildx16.png", LargeIcon = "gochildx32.png", ToolTip = "Select Childs")]
    [Command("addChilds", Icon = "addchildx16.png", LargeIcon = "addchildx32.png", ToolTip = "Add Childs")]

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
                
                    break;
                case "btnVault":
                    if (!Autodesk.Navisworks.Api.Application.IsAutomated)
                    {
                        var pluginRecord = Autodesk.Navisworks.Api.Application.Plugins.FindPlugin("VaultViewer.MohamadrezaHedayat");
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
                    break;
                case "btnGltf":
                    if (!Autodesk.Navisworks.Api.Application.IsAutomated)
                    {
                        var pluginRecord = Autodesk.Navisworks.Api.Application.Plugins.FindPlugin("gltfExporter.MohamadrezaHedayat");
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
                    break;
                case "selectParent":
                    if (!Autodesk.Navisworks.Api.Application.IsAutomated)
                    {
                        try
                        {
                            SelectionTool.SelectionToolPlugin.goToParent();
                        }
                        catch
                        {

                        }
                    }
                    break;
                case "addParent":
                    if (!Autodesk.Navisworks.Api.Application.IsAutomated)
                    {
                        try
                        {
                            SelectionTool.SelectionToolPlugin.addParent();
                        }
                        catch
                        {

                        }
                    }
                    break;
                case "selectChilds":
                    if (!Autodesk.Navisworks.Api.Application.IsAutomated)
                    {
                        try
                        {
                            SelectionTool.SelectionToolPlugin.selectChilds();
                        }
                        catch
                        {

                        }
                    }
                    break;
                case "addChilds":
                    if (!Autodesk.Navisworks.Api.Application.IsAutomated)
                    {
                        try
                        {
                            SelectionTool.SelectionToolPlugin.addChilds();
                        }
                        catch
                        {

                        }
                    }
                    break;
            }
            return 0;
        }
    }
}
