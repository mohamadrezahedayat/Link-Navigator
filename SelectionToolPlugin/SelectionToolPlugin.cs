using Autodesk.Navisworks.Api.Plugins;
using navisApp = Autodesk.Navisworks.Api;
using LinkNavigator.Ctr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using Autodesk.Navisworks.Api;

namespace LinkNavigator.SelectionToolPlugin
{

    public static class SelectionToolPlugin
    {
        public static void goToParent()
        {
            ModelItemCollection selectionModelItems = new ModelItemCollection();

            if (!navisApp.Application.ActiveDocument.CurrentSelection.SelectedItems.IsEmpty)
            {
                //Copy the selection into a new ModelItemCollection
                navisApp.Application.ActiveDocument.CurrentSelection.SelectedItems.CopyTo(selectionModelItems);
                //Clear the current selection
                Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentSelection.Clear();

                //iterate through the ModelItem's in the selection
                foreach (ModelItem modelItem in selectionModelItems)
                {
                    //Add the ModelItem to the current selection
                    navisApp.Application.ActiveDocument.CurrentSelection.Add(modelItem.Parent);
                }
            }
        }
        public static void addParent()
        {
            ModelItemCollection selectionModelItems = new ModelItemCollection();

            if (!navisApp.Application.ActiveDocument.CurrentSelection.SelectedItems.IsEmpty)
            {
                //Copy the selection into a new ModelItemCollection
                navisApp.Application.ActiveDocument.CurrentSelection.SelectedItems.CopyTo(selectionModelItems);
                //Clear the current selection
                Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentSelection.Clear();

                //iterate through the ModelItem's in the selection
                foreach (ModelItem modelItem in selectionModelItems)
                {
                    //Add the ModelItem to the current selection
                    navisApp.Application.ActiveDocument.CurrentSelection.Add(modelItem.Parent); navisApp.Application.ActiveDocument.CurrentSelection.Add(modelItem);
                }
            }
        }
        public static void selectChilds()
        {
            ModelItemCollection selectionModelItems = new ModelItemCollection();

            if (!navisApp.Application.ActiveDocument.CurrentSelection.SelectedItems.IsEmpty)
            {
                
                //Copy the selection into a new ModelItemCollection
                navisApp.Application.ActiveDocument.CurrentSelection.SelectedItems.CopyTo(selectionModelItems);
                //Clear the current selection
                Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentSelection.Clear();

                //iterate through the ModelItem's in the selection
                foreach (ModelItem modelItem in selectionModelItems)
                {
                    //Add the ModelItem to the current selection
                    foreach (ModelItem childModelItem in modelItem.Children)
                    {
                        //Add the ModelItem to the current selection
                        Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentSelection.Add(childModelItem);
                    }
                }
            }
        }
        public static void addChilds()
        {
            ModelItemCollection selectionModelItems = new ModelItemCollection();

            if (!navisApp.Application.ActiveDocument.CurrentSelection.SelectedItems.IsEmpty)
            {
                //Copy the selection into a new ModelItemCollection
                navisApp.Application.ActiveDocument.CurrentSelection.SelectedItems.CopyTo(selectionModelItems);
                //Clear the current selection
                Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentSelection.Clear();

                //iterate through the ModelItem's in the selection
                foreach (ModelItem modelItem in selectionModelItems)
                {
                    navisApp.Application.ActiveDocument.CurrentSelection.Add(modelItem);

                    //Add the ModelItem to the current selection
                    foreach (ModelItem childModelItem in modelItem.Children)
                    {
                        //Add the ModelItem to the current selection
                        Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentSelection.Add(childModelItem);
                    }
                }
            }
        }


    }
}








