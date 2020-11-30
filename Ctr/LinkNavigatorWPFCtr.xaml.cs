using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

using System.Windows.Input;
using System.Windows.Media;

namespace LinkNavigator.Ctr
{
    /// <summary>
    /// Interaction logic for LinkNavigatorWPFCtr.xaml
    /// </summary>
    /// 

    public partial class LinkNavigatorWPFCtr : UserControl
    {

        #region Constructor
        public LinkNavigatorWPFCtr()
        {
            InitializeComponent();
            ListenSelection(null, null);
            Autodesk.Navisworks.Api.Application.ActiveDocumentChanged += ListenSelection;
        }
        #endregion

        #region Link Navigator Plugin
        private List<DataProperty> getlinks()
        {
            var linkProps = new List<DataProperty>();

            foreach (var item in Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentSelection.SelectedItems)
            {
                if (item.PropertyCategories.FindCategoryByDisplayName("Hyperlinks") != null)
                {
                    linkProps.AddRange(item.PropertyCategories.FindCategoryByDisplayName("Hyperlinks").Properties);
                }
            }
            return linkProps;
        }
        private List<stringedLink> linkgenerator(List<DataProperty> linkprops)
        {
            var links = new List<stringedLink>();
            var linkPropNames = new List<DataProperty>();
            var linkpropUrls = new List<DataProperty>();
            var linkPropsCategories = new List<DataProperty>();

            int linkCount = linkprops.Where(i => i.DisplayName.StartsWith("Name")).Count();

            linkPropNames.AddRange(linkprops.Where(i => i.DisplayName.StartsWith("Name")));
            linkpropUrls.AddRange(linkprops.Where(i => i.DisplayName.StartsWith("URL")));
            linkPropsCategories.AddRange(linkprops.Where(i => i.DisplayName.StartsWith("Category")));

            for (int i = 0; i < linkCount; i++)
            {
                links.Add(new stringedLink(new Link(linkPropNames[i], linkpropUrls[i], linkPropsCategories[i])));
            }
            return links;
        }
        private void getHyperlinks(object sender, EventArgs e)
        {
            var linkprops = getlinks();
            var links = linkgenerator(linkprops);
            gridLinks.ItemsSource = links;


        }
        private void clearField(object sender, EventArgs e)
        {
            txtCategory.Text = string.Empty;
            txtUrlFilter.Text = string.Empty;
            txtNameFilter.Text = string.Empty;
        }
        private void ListenSelection(object sender, EventArgs e)
        {
            try
            {
                Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentSelection.Changed += getHyperlinks;
                Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentSelection.Changed += clearField;

            }
            catch (Exception)
            {

                return;
            }

        }
        #endregion

        #region Finder text field change events
        private void txtNameFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            var linkprops = getlinks();
            var links = linkgenerator(linkprops);

            var newSource = (from i in links
                             where i.Link_Name.ToLower().Contains(txtNameFilter.Text.ToLower())
                             && i.Link_URL.ToLower().Contains(txtUrlFilter.Text.ToLower())
                             && i.Link_Category.ToLower().Contains(txtCategory.Text.ToLower())
                             select i).ToList();
            gridLinks.ItemsSource = newSource;
        }

        private void txtUrlFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            var linkprops = getlinks();
            var links = linkgenerator(linkprops);
            var newSource = (from i in links
                             where i.Link_Name.ToLower().Contains(txtNameFilter.Text.ToLower())
                             && i.Link_URL.ToLower().Contains(txtUrlFilter.Text.ToLower())
                             && i.Link_Category.ToLower().Contains(txtCategory.Text.ToLower())
                             select i).ToList();
            gridLinks.ItemsSource = newSource;
        }

        private void txtCategory_TextChanged(object sender, TextChangedEventArgs e)
        {
            var linkprops = getlinks();
            var links = linkgenerator(linkprops);

            var newSource = (from i in links
                             where i.Link_Name.ToLower().Contains(txtNameFilter.Text.ToLower())
                             && i.Link_URL.ToLower().Contains(txtUrlFilter.Text.ToLower())
                             && i.Link_Category.ToLower().Contains(txtCategory.Text.ToLower())
                             select i).ToList();
            gridLinks.ItemsSource = newSource;
        }
        #endregion

        #region Vault link click handler
        /// <summary>
        /// Open Vault viewer plugin from link navigator plugin and handle link
        /// </summary>
        /// <param name="link"></param>
        private void OpenVaultPluginAndShowFile(string link)
        {
            if (!Autodesk.Navisworks.Api.Application.IsAutomated)
            {
                var pluginRecord = Autodesk.Navisworks.Api.Application.Plugins.FindPlugin("VaultViewer.MohamadrezaHedayat");
                if (pluginRecord != null && pluginRecord is DockPanePluginRecord && pluginRecord.IsEnabled)
                {
                    var docPanel = (DockPanePlugin)(pluginRecord.LoadedPlugin ?? pluginRecord.LoadPlugin());

                    if (docPanel != null)
                    {
                        //switch the Visible flag
                        docPanel.Visible = true;
                    }
                }
                var loadedPlugin = (VaultViewerPlugin)pluginRecord.LoadedPlugin;
                vaultViewerctr vaultViewerctr = loadedPlugin.formControl;
                vaultViewerctr.showSelectedLink(link);

            }

        }

        /// <summary>
        /// click handler for links
        /// </summary>
        /// <param name="currentLink"></param>
        private void cellClickHandler(string currentLink)
        {

            if (!String.IsNullOrWhiteSpace(currentLink))
            {
                if (currentLink.Contains("/AutodeskDM/Services/"))
                {
                    try
                    {
                        OpenVaultPluginAndShowFile(currentLink);
                    }
                    catch (Exception)
                    {


                    }
                }
                else if (currentLink.StartsWith("www") || currentLink.StartsWith("http"))
                {
                    try
                    {
                        System.Diagnostics.Process.Start("chrome.exe", currentLink);
                    }
                    catch (Exception)
                    {


                    }


                }
                else
                {
                    try
                    {
                        System.Diagnostics.Process.Start(currentLink);
                    }
                    catch (Exception)
                    {


                    }

                }


            }
        }

        /// <summary>
        /// click handler for grid, Select cells from overal grid visual tree
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridLinks_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DependencyObject dep = (DependencyObject)e.OriginalSource;
            string link;
            // iteratively traverse the visual tree
            while ((dep != null) && !(dep is DataGridCell) && !(dep is DataGridColumnHeader))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }

            if (dep == null)
                return;

            if (dep is DataGridCell)
            {
                DataGridCell cell = dep as DataGridCell;
                link = cell.ToString().Substring(("System.Windows.Controls.DataGridCell: ").Length);

                cellClickHandler(link);
            }
        }

        #endregion
    }
}
