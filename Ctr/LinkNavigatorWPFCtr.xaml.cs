using Autodesk.Navisworks.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;

using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LinkNavigator.Ctr
{
    /// <summary>
    /// Interaction logic for LinkNavigatorWPFCtr.xaml
    /// </summary>
    public partial class LinkNavigatorWPFCtr : UserControl
    {
        public class Link
        {
            public DataProperty Name { get; set; }
            public DataProperty URL { get; set; }
            public DataProperty Category { get; set; }

            public Link(DataProperty name, DataProperty url, DataProperty category)
            {
                this.Name = name;
                this.URL = url;
                this.Category = category;
            }
        }
        public class stringedLink
        {
            public string Link_Name { get; set; }
            public string Link_URL { get; set; }
            public string Link_Category { get; set; }


            public stringedLink(Link link)
            {
                this.Link_Name = GetPropertyValue(link.Name);
                this.Link_URL = GetPropertyValue(link.URL);
                this.Link_Category = GetPropertyValue(link.Category).Split('(')[1].Split(')')[0];

            }
        }


        public LinkNavigatorWPFCtr()
        {
            InitializeComponent();
            ListenSelection(null, null);
            Autodesk.Navisworks.Api.Application.ActiveDocumentChanged += ListenSelection;
        }


        public void getHyperlinks(object sender, EventArgs e)
        {
            var linkprops = getlinks();
            var links = linkgenerator(linkprops);
            gridLinks.ItemsSource = links;


        }
        public List<stringedLink> linkgenerator(List<DataProperty> linkprops)
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

        private void ListenSelection(object sender, EventArgs e)
        {
            try
            {
                Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentSelection.Changed += getHyperlinks;
                Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentSelection.Changed += clearField;

            }
            catch (Exception ex)
            {

                return;
            }

        }

        private void clearField(object sender, EventArgs e)
        {
            txtCategory.Text = string.Empty;
            txtUrlFilter.Text = string.Empty;
            txtNameFilter.Text = string.Empty;
        }

        private static string GetPropertyValue(DataProperty prop)
        {
            return prop.Value.IsDisplayString ? prop.Value.ToDisplayString() : prop.Value.ToString().Split(':')[1];
        }
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


        private void cellClickHandler(string currentLink)
        {
            
            if (!String.IsNullOrWhiteSpace(currentLink))
            {
                if (currentLink.Contains("/AutodeskDM/Services/"))
                {
                    System.Windows.Forms.MessageBox.Show("vault service is running");
                }
                else if ( currentLink.StartsWith("www") || currentLink.StartsWith("http"))
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
                    System.Diagnostics.Process.Start(currentLink);
                }


            }
        }

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
              link = cell.ToString().Substring(("System.Windows.Controls.DataGridCell: ").Length );
                
            cellClickHandler(link);
            }
        }
    }
}
