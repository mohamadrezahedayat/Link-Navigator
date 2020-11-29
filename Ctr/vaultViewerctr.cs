using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ACW = Autodesk.Connectivity.WebServices;
using Framework = Autodesk.DataManagement.Client.Framework;
using Vault = Autodesk.DataManagement.Client.Framework.Vault;
using Forms = Autodesk.DataManagement.Client.Framework.Vault.Forms;

using Autodesk.DataManagement.Client.Framework.Vault.Currency.Entities;


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
            generateHyperlinkToolStripMenuItem.Enabled = activeConnection;

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


        private void m_openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }
        private void OpenFile()
        {
            Vault.Currency.Entities.FileIteration file = m_model.SelectedContent.FirstOrDefault() as Vault.Currency.Entities.FileIteration;
            if (file != null)
                OpenFileCommand.Execute(file, m_conn);
        }

        private void m_advancedFindToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdvancedSearch();
        }
        private void AdvancedSearch()
        {
            FinderForm finderForm = new FinderForm(m_conn);
            finderForm.Show();
        }
        private void getToolStripMenuItem_Click(object sender, EventArgs e)
        {
            get();
        }
        private void get()
        {
            Vault.Settings.AcquireFilesSettings setting = new Vault.Settings.AcquireFilesSettings(m_conn, true);
            long selectedItemId = m_model.SelectedContent.FirstOrDefault().EntityIterationId;
            Vault.Currency.Entities.FileIteration selectedItem = m_conn.FileManager.GetFilesByIterationIds(new long[] { selectedItemId }).FirstOrDefault().Value;
            setting.AddFileToAcquire(selectedItem, Vault.Settings.AcquireFilesSettings.AcquisitionOption.Download);

            m_conn.FileManager.AcquireFiles(setting);

        }

        private void addFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFolder();
        }
        private void CreateFolder()
        {
            FileNameForm form = new FileNameForm();
            form.ShowDialog();
            if (form.DialogResult != DialogResult.OK)
                return;
            try
            {
                Vault.Currency.Entities.Folder parent = m_model.Parent as Vault.Currency.Entities.Folder;
                Vault.Currency.Entities.EntityCategory category = Vault.Currency.Entities.EntityCategory.EmptyCategory;
                m_conn.FolderManager.CreateFolder(parent, form.folderName, false, category);
                m_model.Reload();
            }
            catch (Exception)
            {

            }

        }

        private void m_addFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vault.Currency.Entities.Folder parent = m_model.Parent as Vault.Currency.Entities.Folder;
            if (parent != null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] filePaths = openFileDialog.FileNames;
                    foreach (string filePath in filePaths)
                    {
                        AddFileCommand.Execute(filePath, parent, m_conn);
                    }
                    m_model.Reload();
                }
            }
        }

        #region show and focus selected link from link navigator

        private void focusSelectedFile(string[] folderAndFiles, long folderId)
        {
            var files = m_conn.WebServiceManager.DocumentService.GetLatestFilesByFolderId(folderId, true);
            long fileId = 1;
            foreach (var item in files)
            {
                if (item.Name == folderAndFiles.Last())
                {
                    fileId = item.Id;
                }


            }

            var file = m_conn.FileManager.GetFilesByIterationIds(new List<long> { fileId }).FirstOrDefault();
            m_model.SetSelectedContent(null, new List<IEntity> { file.Value });
        }
        private ACW.Folder findParentFolder(string[] fileAndFolders)
        {
            string path = "$";
            for (int i = 0; i < fileAndFolders.Length - 1; i++)
            {
                path += "/";
                path += fileAndFolders[i];
            }
            var folder = m_conn.WebServiceManager.DocumentService.GetFolderByPath(path);
            return folder;
        }
        private void navigateToSelectedFile(string[] folderAndFiles)
        {
            var folder = findParentFolder(folderAndFiles);
            if (folder != null)
            {
                List<long> ids = new List<long> { folder.Id };

                var entityFolder = m_conn.FolderManager.GetFoldersByIds(ids).FirstOrDefault().Value;

                m_model.Navigate(entityFolder, Forms.Currency.NavigationContext.DrillDown);
                focusSelectedFile(folderAndFiles, ids.FirstOrDefault());
            }
        }
        private string[] extractFileNameFromeLink(string link)
        {
            // sampleInitialLink = http://localhost/AutodeskDM/Services/EntityDataCommandRequest.aspx?Vault=VaultDemo&ObjectId=%24%2fFolderOne%2fvaultLogo.png&ObjectType=File&Command=Select
            var positionStringStart = "ObjectId=%24%2f";
            var positionStringEnd = "&ObjectType=";
            var substring1 = link.Substring(link.IndexOf(positionStringStart) + positionStringStart.Length);
            var substring2 = substring1.Remove(substring1.IndexOf(positionStringEnd));
            var extractedPathReplaceSlash = substring2.Replace("%2f", "/");
            var extractedPathReplaceplus = extractedPathReplaceSlash.Replace("+", " ");
            var fileAndFolders = extractedPathReplaceplus.Split('/');
            return fileAndFolders;
        }

        public void showSelectedLink(string link)
        {
            var folderAndFiles = extractFileNameFromeLink(link);
            if (m_conn == null)
                login();

            if (m_conn != null)
            {
                navigateToSelectedFile(folderAndFiles);

            }

        }

        #endregion
        private void generateHyperlinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string startLinkString = @"http://localhost/AutodeskDM/Services/EntityDataCommandRequest.aspx?Vault=VaultDemo&ObjectId=%24%2f";
            var folderList = m_model.NavigationPath;
            string path = "";
            foreach (var pathSection in folderList)
            {
                if (pathSection.ToString() != "$") { path += pathSection.ToString() + "%2f"; }
            }
            string fileName = m_model.SelectedContent.FirstOrDefault().EntityName;
            string endLinkString = "&ObjectType=File&Command=Select";
            path = (startLinkString + path + fileName + endLinkString).Replace(' ', '+');
            Clipboard.SetText(path);
        }
    }
}
