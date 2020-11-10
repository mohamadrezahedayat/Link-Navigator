using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using ACW = Autodesk.Connectivity.WebServices;
using Framework = Autodesk.DataManagement.Client.Framework;
using Vault = Autodesk.DataManagement.Client.Framework.Vault;
using Forms = Autodesk.DataManagement.Client.Framework.Vault.Forms;
using Autodesk.DataManagement.Client.Framework.Vault.Forms.Settings;
using Autodesk.DataManagement.Client.Framework.Vault.Internal.ExtensionMethods;
using Autodesk.Connectivity.WebServices;
using Autodesk.DataManagement.Client.Framework.Vault.Currency.Properties;

namespace LinkNavigator.Ctr
{
    public partial class vaultViewerctr : UserControl
    {
        private Vault.Currency.Connections.Connection m_conn = null;
        private Vault.Forms.Models.BrowseVaultNavigationModel m_model = null;
        private List<Framework.Forms.Controls.GridLayout> m_availableLayouts = new List<Framework.Forms.Controls.GridLayout>();
        private List<ToolStripMenuItem> m_viewButtons = new List<ToolStripMenuItem>();
        private Func<Vault.Currency.Entities.IEntity, bool> m_filterCanDisplayEntity;

        public vaultViewerctr()
        {
            InitializeComponent();
            fileName_multiPartTextBox.EditMode = Framework.Forms.Controls.MultiPartTextBoxControl.EditModeOption.ReadOnly;

            //create some filetype filters, borrowing from the Select Entity dialog
            Forms.Settings.SelectEntitySettings.EntityRegularExpressionFilter filter1 = new Forms.Settings.SelectEntitySettings.EntityRegularExpressionFilter("All Files (*.*)", ".+", Vault.Currency.Entities.EntityClassIds.Files);
            fileType_comboBox.Items.Add(filter1);
            Forms.Settings.SelectEntitySettings.EntityRegularExpressionFilter filter2 = new Forms.Settings.SelectEntitySettings.EntityRegularExpressionFilter("Text Files (*.txt)", ".+txt", Vault.Currency.Entities.EntityClassIds.Files);
            fileType_comboBox.Items.Add(filter2);
            Forms.Settings.SelectEntitySettings.EntityRegularExpressionFilter filter3 = new Forms.Settings.SelectEntitySettings.EntityRegularExpressionFilter("Pictures (*.jpg, *.png, *.gif)", ".+jpg|.+png|.+gif", Vault.Currency.Entities.EntityClassIds.Files);
            fileType_comboBox.Items.Add(filter3);
            Forms.Settings.SelectEntitySettings.EntityRegularExpressionFilter filter4 = new Forms.Settings.SelectEntitySettings.EntityRegularExpressionFilter("Project Files (*.ipj)", ".+ipj", Vault.Currency.Entities.EntityClassIds.Files);
            fileType_comboBox.Items.Add(filter4);
            fileType_comboBox.SelectedItem = filter1;
            m_filterCanDisplayEntity = filter1.CanDisplayEntity;
            controlStates(m_conn != null);
        }
        /// <summary>
        /// login to vault
        /// </summary>
        private void login()
        {
            foreach (Framework.Forms.Controls.GridLayout layout in vaultBrowserControl1.AvailableLayouts)
            {
                m_availableLayouts.Add(layout);
                ToolStripMenuItem item = new ToolStripMenuItem(layout.Name);
                item.Tag = layout;
                item.CheckOnClick = true;
                item.Click += new EventHandler(switchViewDropdown_itemClick);
                switchView_toolStripSplitButton.DropDownItems.Add(item);
                m_viewButtons.Add(item);
            }
            m_conn = Vault.Forms.Library.Login(null);
            controlStates(m_conn != null);
            if (m_conn != null)
                initalizeGrid();
        }
        void switchViewDropdown_itemClick(object sender, EventArgs e)
        {
            //switch to the exact layout that was chosen with the switch view dropdown menu
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            vaultBrowserControl1.CurrentLayout = item.Tag as Framework.Forms.Controls.GridLayout;
        }
        private void logout()
        {
            m_conn = Forms.Library.Logout(m_conn, null);
            vaultBrowserControl1.SetDataSource(null, null);
            fileName_multiPartTextBox.Parts = new List<string>();
            controlStates(m_conn != null);
            if (m_conn != null)
                initalizeGrid();
        }
        private void controlStates(bool activeConnection)
        {
            login_toolStripMenuItem.Enabled = !activeConnection;
            logout_toolStripMenuItem.Enabled = activeConnection;
            vaultNavigationPathComboboxControl1.Enabled = activeConnection;
            switchView_toolStripSplitButton.Enabled = activeConnection;
            vaultBrowserControl1.Enabled = activeConnection;
            fileType_comboBox.Enabled = activeConnection;
            m_addFileToolStripMenuItem.Enabled = activeConnection;
            m_openFileToolStripMenuItem.Enabled = activeConnection && m_model != null && m_model.SelectedContent.FirstOrDefault() is Vault.Currency.Entities.FileIteration;
            m_advancedFindToolStripMenuItem.Enabled = activeConnection;

            //navigate up and back are normally handled by the model (m_model_ParentChanged), but we need to specifically disable them when we log out
            if (activeConnection == false)
            {
                navigateBack_toolStripButton.Enabled = false;
                navigateUp_toolStripButton.Enabled = false;
            }
        }

        private void initalizeGrid()
        {
            Vault.Currency.Properties.PropertyDefinitionDictionary propDefs = m_conn.PropertyManager.GetPropertyDefinitions(null, null, Vault.Currency.Properties.PropertyDefinitionFilter.IncludeAll);

            Vault.Forms.Controls.VaultBrowserControl.Configuration initialConfig = new Vault.Forms.Controls.VaultBrowserControl.Configuration(m_conn, "VaultBrowserSample", propDefs);

            initialConfig.AddInitialColumn(Vault.Currency.Properties.PropertyDefinitionIds.Client.EntityIcon);
            initialConfig.AddInitialColumn(Vault.Currency.Properties.PropertyDefinitionIds.Client.VaultStatus);
            initialConfig.AddInitialColumn(Vault.Currency.Properties.PropertyDefinitionIds.Server.EntityName);
            initialConfig.AddInitialColumn(Vault.Currency.Properties.PropertyDefinitionIds.Server.CheckInDate);
            initialConfig.AddInitialColumn(Vault.Currency.Properties.PropertyDefinitionIds.Server.Comment);
            initialConfig.AddInitialColumn(Vault.Currency.Properties.PropertyDefinitionIds.Server.ThumbnailSystem);
            initialConfig.AddInitialSortCriteria(Vault.Currency.Properties.PropertyDefinitionIds.Server.EntityName, true);

            initialConfig.AddInitialQuickListColumn(Vault.Currency.Properties.PropertyDefinitionIds.Client.EntityIcon);
            initialConfig.AddInitialQuickListColumn(Vault.Currency.Properties.PropertyDefinitionIds.Client.VaultStatus);
            initialConfig.AddInitialQuickListColumn(Vault.Currency.Properties.PropertyDefinitionIds.Server.EntityName);
            initialConfig.AddInitialQuickListColumn(Vault.Currency.Properties.PropertyDefinitionIds.Server.CheckInDate);
            initialConfig.AddInitialQuickListColumn(Vault.Currency.Properties.PropertyDefinitionIds.Server.Comment);
            initialConfig.AddInitialQuickListColumn(Vault.Currency.Properties.PropertyDefinitionIds.Server.ThumbnailSystem);

            m_model = new Forms.Models.BrowseVaultNavigationModel(m_conn, true, true);

            m_model.ParentChanged += new EventHandler(m_model_ParentChanged);
            m_model.SelectedContentChanged += new EventHandler<Forms.Currency.SelectionChangedEventArgs>(m_model_SelectedContentChanged);


            vaultBrowserControl1.SetDataSource(initialConfig, m_model);
            vaultBrowserControl1.OptionsCustomizations.CanDisplayEntityHandler = canDisplayEntity;
            vaultBrowserControl1.OptionsBehavior.MultiSelect = false;
            vaultBrowserControl1.OptionsBehavior.AllowOverrideSelections = false;

            vaultNavigationPathComboboxControl1.SetDataSource(m_conn, m_model, null);

            m_model.Navigate(m_conn.FolderManager.RootFolder, Forms.Currency.NavigationContext.NewContext);
        }
        public void login_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            login();
        }
        void m_model_SelectedContentChanged(object sender, Forms.Currency.SelectionChangedEventArgs e)
        {
            //when the selected content changes, we need to update the filename field to reflect the selected entities
            List<Vault.Currency.Entities.IEntity> selectedEntities = new List<Vault.Currency.Entities.IEntity>(e.SelectedEntities);

            bool fileSelected = false;
            List<string> selectedEntityNames = new List<string>();
            foreach (Vault.Currency.Entities.IEntity entity in selectedEntities)
            {
                if (entity is Vault.Currency.Entities.FileIteration)
                    fileSelected = true;
                selectedEntityNames.Add(entity.EntityName);
            }
            fileName_multiPartTextBox.Parts = selectedEntityNames;

            // update availability of commands
            m_openFileToolStripMenuItem.Enabled = fileSelected;

            UpdateAssociationsTreeView();
        }
        private void UpdateAssociationsTreeView()
        {
            m_associationsTreeView.Nodes.Clear();

            Vault.Currency.Entities.FileIteration selectedFile = m_model.SelectedContent.FirstOrDefault() as Vault.Currency.Entities.FileIteration;
            if (selectedFile == null)
                return;

            this.m_associationsTreeView.BeginUpdate();

            // get all parent and child information for the file
            ACW.FileAssocArray[] associationArrays = m_conn.WebServiceManager.DocumentService.GetFileAssociationsByIds(
                new long[] { selectedFile.EntityIterationId },
                ACW.FileAssociationTypeEnum.None, false,        // parent associations
                ACW.FileAssociationTypeEnum.Dependency, true,   // child associations
                false, true);

            if (associationArrays != null && associationArrays.Length > 0 &&
                associationArrays[0].FileAssocs != null && associationArrays[0].FileAssocs.Length > 0)
            {
                ACW.FileAssoc[] associations = associationArrays[0].FileAssocs;
                m_associationsTreeView.ShowLines = true;

                // organize the return values by the parent file
                Dictionary<long, List<Vault.Currency.Entities.FileIteration>> associationsByFile = new Dictionary<long, List<Vault.Currency.Entities.FileIteration>>();
                foreach (ACW.FileAssoc association in associations)
                {
                    ACW.File parent = association.ParFile;
                    if (associationsByFile.ContainsKey(parent.Id))
                    {
                        // parent is already in the hashtable, add an new child entry
                        List<Vault.Currency.Entities.FileIteration> list = associationsByFile[parent.Id];
                        list.Add(new Vault.Currency.Entities.FileIteration(m_conn, association.CldFile));
                    }
                    else
                    {
                        // add the parent to the hashtable.
                        List<Vault.Currency.Entities.FileIteration> list = new List<Vault.Currency.Entities.FileIteration>();
                        list.Add(new Vault.Currency.Entities.FileIteration(m_conn, association.CldFile));
                        associationsByFile.Add(parent.Id, list);
                    }
                }

                // construct the tree
                if (associationsByFile.ContainsKey(selectedFile.EntityIterationId))
                {
                    TreeNode rootNode = new TreeNode(selectedFile.EntityName);
                    rootNode.Tag = selectedFile;
                    m_associationsTreeView.Nodes.Add(rootNode);
                    AddChildAssociation(rootNode, associationsByFile);
                }
            }
            else
            {
                m_associationsTreeView.ShowLines = false;
                m_associationsTreeView.Nodes.Add("<< no children >>");
            }

            m_associationsTreeView.EndUpdate();
        }
        private void AddChildAssociation(TreeNode parentNode,
           Dictionary<long, List<Vault.Currency.Entities.FileIteration>> associationsByFile)
        {
            // get the File object for the Node
            Vault.Currency.Entities.FileIteration parentFile = (Vault.Currency.Entities.FileIteration)parentNode.Tag;

            // if associations exist, create a Node for each one
            if (associationsByFile.ContainsKey(parentFile.EntityIterationId))
            {
                List<Vault.Currency.Entities.FileIteration> list = associationsByFile[parentFile.EntityIterationId];
                foreach (Vault.Currency.Entities.FileIteration childFile in list)
                {
                    TreeNode childNode = new TreeNode(childFile.EntityName);
                    childNode.Tag = childFile;
                    parentNode.Nodes.Add(childNode);

                    // add all of the Nodes for the children's children
                    AddChildAssociation(childNode, associationsByFile);
                }
            }
        }
        private bool canDisplayEntity(Vault.Currency.Entities.IEntity entity)
        {
            if (m_filterCanDisplayEntity != null)
            {
                if (!m_filterCanDisplayEntity(entity))
                {
                    return false;
                }
            }

            return true;
        }
        void m_model_ParentChanged(object sender, EventArgs e)
        {
            navigateBack_toolStripButton.Enabled = m_model.CanMoveBack;
            navigateUp_toolStripButton.Enabled = m_model.CanMoveUp;
        }

        private void navigateBack_toolStripButton_Click(object sender, EventArgs e)
        {
            m_model.MoveBack();
        }

        private void navigateUp_toolStripButton_Click(object sender, EventArgs e)
        {
            m_model.MoveUp();
        }

        private void logout_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            logout();
        }

        private void switchView_toolStripSplitButton_ButtonClick(object sender, EventArgs e)
        {

            //cycle through the list of available layouts when the switch view button is pressed without using the dropdown
            int setIdx = (m_availableLayouts.IndexOf(vaultBrowserControl1.CurrentLayout) + 1) % m_availableLayouts.Count;
            vaultBrowserControl1.CurrentLayout = m_availableLayouts[setIdx];
        }

        private void switchView_toolStripSplitButton_DropDownOpening(object sender, EventArgs e)
        {
            //Check the currenly visible view in the menu
            foreach (ToolStripMenuItem button in m_viewButtons)
            {
                button.Checked = button.Tag.Equals(vaultBrowserControl1.CurrentLayout);
            }
        }
    }
}
