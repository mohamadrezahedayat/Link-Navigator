using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using Autodesk.Navisworks.Api;

namespace LinkNavigator
{


    public partial class UcLinkGrid : UserControl
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
        public UcLinkGrid()
        {
            InitializeComponent();
            ListenSelection(null, null);
            Autodesk.Navisworks.Api.Application.ActiveDocumentChanged += ListenSelection;

        }

        public void getHyperlinks(object sender, EventArgs e)
        {
            var linkprops = getlinks();
            var links = linkgenerator(linkprops);
            gridLinks.DataSource = links;

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
                links.Add(new stringedLink( new Link(linkPropNames[i], linkpropUrls[i], linkPropsCategories[i])));
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
            Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentSelection.Changed += getHyperlinks;
            Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentSelection.Changed += clearField;
            
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




        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            Dock = DockStyle.Fill;
        }

        private void txtNameFilter_TextChanged(object sender, EventArgs e)
        {
            var linkprops = getlinks();
            var links = linkgenerator(linkprops);

            var newSource = (from i in links
                             where i.Link_Name.ToLower().Contains(txtNameFilter.Text.ToLower())
                             && i.Link_URL.ToLower().Contains(txtUrlFilter.Text.ToLower())
                             && i.Link_Category.ToLower().Contains(txtCategory.Text.ToLower())
                             select i).ToList();
            gridLinks.DataSource = newSource;
        }

        private void txtUrlFilter_TextChanged(object sender, EventArgs e)
        {
            var linkprops = getlinks();
            var links = linkgenerator(linkprops);
            var newSource = (from i in links
                             where i.Link_Name.ToLower().Contains(txtNameFilter.Text.ToLower())
                             && i.Link_URL.ToLower().Contains(txtUrlFilter.Text.ToLower())
                             && i.Link_Category.ToLower().Contains(txtCategory.Text.ToLower())
                             select i).ToList();
            gridLinks.DataSource = newSource;
        }

        private void txtCategory_TextChanged(object sender, EventArgs e)
        {
            var linkprops = getlinks();
            var links = linkgenerator(linkprops);

            var newSource = (from i in links 
                             where i.Link_Name.ToLower().Contains(txtNameFilter.Text.ToLower()) 
                             && i.Link_URL.ToLower().Contains(txtUrlFilter.Text.ToLower()) 
                             && i.Link_Category.ToLower().Contains(txtCategory.Text.ToLower()) 
                             select i).ToList();
            gridLinks.DataSource = newSource;
        }

        private void gridLinks_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetHyperLinkOnGrid();


        }

        private void SetHyperLinkOnGrid()
        {
            foreach (DataGridViewRow r in gridLinks.Rows)
            {
                //if (System.Uri.IsWellFormedUriString(r.Cells["Link_URL"].Value.ToString(), UriKind.Absolute))
                //{
                r.Cells["Link_URL"] = new DataGridViewLinkCell();
                DataGridViewLinkCell c = r.Cells["Link_URL"] as DataGridViewLinkCell;
                c.LinkColor = System.Drawing.Color.Green;
                //}
            }
        }

        private void gridLinks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string currentLink = gridLinks.CurrentCell.Value.ToString().ToLower();

            if (gridLinks.Columns[gridLinks.CurrentCell.ColumnIndex].HeaderText.Contains("Link_URL"))
            {
                if (!String.IsNullOrWhiteSpace(currentLink))
                {
                    if (currentLink.StartsWith("www") || currentLink.StartsWith("http"))
                    {
                        try
                        {
                            System.Diagnostics.Process.Start("chrome.exe", gridLinks.CurrentCell.Value.ToString());
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

           
        }
    }
}


