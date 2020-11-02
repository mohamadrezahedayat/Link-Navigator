using Autodesk.Navisworks.Api;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;


namespace Training.Ctr
{
    public partial class UcProperty : UserControl
    {
        public UcProperty()
        {
            InitializeComponent();
            ListenSelection(null, null);
            Autodesk.Navisworks.Api.Application.ActiveDocumentChanged += ListenSelection;
        }

        private void ListenSelection(object sender, EventArgs e)
        {
            Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentSelection.Changed += GetProperties;
        }

        private void GetProperties(object sender, EventArgs e)
        {
            tbOut.Clear();

            var result = new List<string>();

            foreach (var item in Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentSelection.SelectedItems)
            {
                result.Add(item.DisplayName);
                foreach (var cat in item.PropertyCategories)
                {
                    result.Add(string.Concat(". ", cat.DisplayName));
                    foreach (var prop in cat.Properties)
                    {
                        result.Add(string.Concat(". .   ", prop.DisplayName, "> ", GetPropertyValue(prop)));
                    }
                }
                result.Add(Environment.NewLine);

            }
            tbOut.Text = string.Join(Environment.NewLine, result);
        }

        private string GetPropertyValue(DataProperty prop)
        {
            return prop.Value.IsDisplayString ? prop.Value.ToDisplayString() : prop.Value.ToString().Split(':')[1];
        }

        private void btnFind_MouseUp(object sender, MouseEventArgs e)
        {
            var r = new List<ModelItem>();
            foreach (var item in Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentSelection.SelectedItems)
            {
                var cat = item.DescendantsAndSelf.Where(i => i.PropertyCategories.FindCategoryByDisplayName(tbCategoryName.Text) != null);
                var pro = cat.Where(m => m.PropertyCategories.FindCategoryByDisplayName(tbCategoryName.Text).Properties.FindPropertyByDisplayName
                    (tbPropertyName.Text) != null);

                r.AddRange(pro.Where(m => GetPropertyValue(m.PropertyCategories.FindCategoryByDisplayName(tbCategoryName.Text).Properties.FindPropertyByDisplayName
                   (tbPropertyName.Text)) == tbPropertyValue.Text));

            }
            Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentSelection.Clear();
            Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentSelection.AddRange(r);

        }
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            Dock = DockStyle.Fill;
        }
    }
}
