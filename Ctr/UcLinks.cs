using Autodesk.Navisworks.Api;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace Training.Ctr
{
    public partial class UcLinks : UserControl
    {
        public UcLinks()
        {
            InitializeComponent();
            ListenSelection(null, null);
            Autodesk.Navisworks.Api.Application.ActiveDocumentChanged += ListenSelection;
        }
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            Dock = DockStyle.Fill;
        }
        private void ListenSelection(object sender, EventArgs e)
        {
            Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentSelection.Changed += GetProperties;
        }



        private void GetProperties(object sender, EventArgs e)
        {
            tbLinkProperty.Clear();

            var result = new List<string>();

            foreach (var item in Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentSelection.SelectedItems)
            {
                result.Add("Selected Item: " + item.DisplayName);
                //result.Add(Environment.NewLine);
                if (item.PropertyCategories.FindCategoryByDisplayName("Hyperlinks") != null)
                {
                    var HyperlinkProps = item.PropertyCategories.FindCategoryByDisplayName("Hyperlinks").Properties;
                    result.Add("    Hyperlinks: ");
                    //var i = 0;
                    foreach (var prop in HyperlinkProps)
                    {
                        if (prop.DisplayName.StartsWith("URL"))
                        {
                            result.Add(string.Concat("      \\\\", GetPropertyValue(prop)));
                        }
                        else
                        {
                            result.Add(string.Concat("      ", GetPropertyValue(prop)));
                        }


                    }
                    result.Add(Environment.NewLine);

                }
                else
                {
                    result.Add("and This Item is not Hyperlinked.... ");
                }



            }
            tbLinkProperty.Text = string.Join(Environment.NewLine, result);
        }
        private string GetPropertyValue(DataProperty prop)
        {
            return prop.Value.IsDisplayString ? prop.Value.ToDisplayString() : prop.Value.ToString().Split(':')[1];
        }

        private void tbLinkProperty_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("chrome.exe", e.LinkText);
            }
            catch (Exception)
            {

                //;
            }
            
        }
    }

}

