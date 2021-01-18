using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Autodesk.Navisworks.Api;
using LinkNavigator.DatToolPlugin.Services;
//using LinkNavigator.DatToolPlugin.Models;
//using LinkNavigator.DatToolPlugin.Services;
using Hyperlink = LinkNavigator.DatToolPlugin.Models.Hyperlink;

namespace LinkNavigator.DatToolPlugin.Ctr
{
    /// <summary>
    /// Interaction logic for DataToolCtr.xaml
    /// </summary>
    public partial class DataToolCtr : UserControl
    {
        private ObservableCollection<NavisModel> NavisModels = new ObservableCollection<NavisModel>();
        //HyperlinkRepository hyperlinkRepository = new HyperlinkRepository();
        //Navis3dModelRepository navis3DModelRepository = new Navis3dModelRepository();


        public DataToolCtr()
        {
            InitializeComponent();
            ListenSelection(null, null);
            Autodesk.Navisworks.Api.Application.ActiveDocumentChanged += ListenSelection;
        }
        public void ListenSelection(object sender, EventArgs e)
        {
            try
            {
                Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentSelection.Changed += selectNamesAndHyperlinks;


            }
            catch (Exception)
            {

                return;
            }

        }
        private void selectNamesAndHyperlinks(object sender, EventArgs e)
        {
            extraxtData();
            createTreeView();

        }

        private void createTreeView()
        {
            trvItems.Items.Clear();
            foreach (var navisModel in NavisModels)
            {
                var item = new TreeViewItem();
                item.Header = navisModel.Name;
                foreach (var hyperlink in navisModel.Hyperlinks)
                {
                    var subItem = new TreeViewItem();
                    subItem.Header = hyperlink;
                    item.Items.Add(subItem);
                }
                trvItems.Items.Add(item);
            }
        }

        private void extraxtData()
        {
            NavisModels.Clear();
            foreach (var item in Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentSelection.SelectedItems)
            {
                var navisModel = new NavisModel();
                navisModel.Name = item.DisplayName;

                var UrlProperties = new List<DataProperty>();
                var UrlStrings = new List<string>();
                if (item.PropertyCategories.FindCategoryByDisplayName("Hyperlinks") != null)
                {
                    var Hyprelinks = new List<DataProperty>();
                    Hyprelinks.AddRange(item.PropertyCategories.FindCategoryByDisplayName("Hyperlinks").Properties);
                    UrlProperties.AddRange(Hyprelinks.Where(i => i.DisplayName.StartsWith("URL")));
                    foreach (var urlprop in UrlProperties)
                    {
                        var UrlString = urlprop.Value.IsDisplayString ? urlprop.Value.ToDisplayString() : urlprop.Value.ToString().Split(':')[1];
                        UrlStrings.Add(UrlString);

                        navisModel.Hyperlinks.Add(UrlString);

                    }
                }

                NavisModels.Add(navisModel);
            }
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            var navisrepo = new Navis3dModelRepositoryAdo();
            var hyperrepo = new HyperlinkRepositoryAdo();

            string a = "dummyData ";
            int b = 1;
            foreach (var navismodel in NavisModels)
            {
                var c = a + b;
                navisrepo.InsertNavis3dModel(navismodel.Name , c );
                b++;
                int modelId = navisrepo.GetNavis3dModelByName(navismodel.Name).Navis3dModelId;
                foreach (var hyperlink in navismodel.Hyperlinks)
                {
                    hyperrepo.InsertHyperlink(hyperlink, modelId);
                }
            }
        }

    }

    public class NavisModel
    {
        public NavisModel()
        {
            this.Hyperlinks = new ObservableCollection<string>();
        }

        public string Name { get; set; }

        public ObservableCollection<string> Hyperlinks { get; set; }
    }



}



