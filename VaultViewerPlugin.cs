using Autodesk.Navisworks.Api.Plugins;
using LinkNavigator.Ctr;
using System.Windows.Forms;


namespace LinkNavigator
{
    [Plugin("VaultViewer", "MohamadrezaHedayat", DisplayName = "Vault Viewer")]
    [DockPanePlugin(500, 600, AutoScroll = true, FixedSize = false, MinimumHeight = 500, MinimumWidth = 600)]
    class VaultViewerPlugin : DockPanePlugin
    {
        public override Control CreateControlPane() => new vaultViewerctr { Dock = DockStyle.Fill };

        public override void DestroyControlPane(Control pane)
        {
            pane.Dispose();
        }

    }
}
