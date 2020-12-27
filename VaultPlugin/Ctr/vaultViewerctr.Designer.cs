namespace LinkNavigator.Ctr
{
    partial class vaultViewerctr
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(vaultViewerctr));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.login_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logout_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_addFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_advancedFindToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoCheckOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateHyperlinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignLinkToNavisItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.vaultNavigationPathComboboxControl1 = new Autodesk.DataManagement.Client.Framework.Vault.Forms.Controls.VaultNavigationPathComboboxControl();
            this.vaultBrowserControl1 = new Autodesk.DataManagement.Client.Framework.Vault.Forms.Controls.VaultBrowserControl();
            this.fileName_label = new System.Windows.Forms.Label();
            this.revision_label = new System.Windows.Forms.Label();
            this.fileType_comboBox = new System.Windows.Forms.ComboBox();
            this.m_tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.m_associationsTreeView = new System.Windows.Forms.TreeView();
            this.fileName_multiPartTextBox = new Autodesk.DataManagement.Client.Framework.Forms.Controls.MultiPartTextBoxControl();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.navigateBack_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.navigateUp_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.switchView_toolStripSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.actionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(344, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.login_toolStripMenuItem,
            this.logout_toolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(45, 20);
            this.toolStripMenuItem1.Text = "&Vault";
            // 
            // login_toolStripMenuItem
            // 
            this.login_toolStripMenuItem.Name = "login_toolStripMenuItem";
            this.login_toolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.login_toolStripMenuItem.Text = "Log In";
            this.login_toolStripMenuItem.Click += new System.EventHandler(this.login_toolStripMenuItem_Click);
            // 
            // logout_toolStripMenuItem
            // 
            this.logout_toolStripMenuItem.Enabled = false;
            this.logout_toolStripMenuItem.Name = "logout_toolStripMenuItem";
            this.logout_toolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.logout_toolStripMenuItem.Text = "Log Out";
            this.logout_toolStripMenuItem.Click += new System.EventHandler(this.logout_toolStripMenuItem_Click);
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_openFileToolStripMenuItem,
            this.m_addFileToolStripMenuItem,
            this.m_advancedFindToolStripMenuItem,
            this.addFolderToolStripMenuItem,
            this.checkOutToolStripMenuItem,
            this.undoCheckOutToolStripMenuItem,
            this.checkInToolStripMenuItem,
            this.getToolStripMenuItem,
            this.generateHyperlinkToolStripMenuItem,
            this.asignLinkToNavisItemToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.actionsToolStripMenuItem.Text = "Actions";
            // 
            // m_openFileToolStripMenuItem
            // 
            this.m_openFileToolStripMenuItem.Enabled = false;
            this.m_openFileToolStripMenuItem.Name = "m_openFileToolStripMenuItem";
            this.m_openFileToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.m_openFileToolStripMenuItem.Text = "Open File";
            this.m_openFileToolStripMenuItem.Click += new System.EventHandler(this.m_openFileToolStripMenuItem_Click);
            // 
            // m_addFileToolStripMenuItem
            // 
            this.m_addFileToolStripMenuItem.Enabled = false;
            this.m_addFileToolStripMenuItem.Name = "m_addFileToolStripMenuItem";
            this.m_addFileToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.m_addFileToolStripMenuItem.Text = "Add File ...";
            this.m_addFileToolStripMenuItem.Click += new System.EventHandler(this.m_addFileToolStripMenuItem_Click);
            // 
            // m_advancedFindToolStripMenuItem
            // 
            this.m_advancedFindToolStripMenuItem.Enabled = false;
            this.m_advancedFindToolStripMenuItem.Name = "m_advancedFindToolStripMenuItem";
            this.m_advancedFindToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.m_advancedFindToolStripMenuItem.Text = "Advanced Find...";
            this.m_advancedFindToolStripMenuItem.Click += new System.EventHandler(this.m_advancedFindToolStripMenuItem_Click);
            // 
            // addFolderToolStripMenuItem
            // 
            this.addFolderToolStripMenuItem.Name = "addFolderToolStripMenuItem";
            this.addFolderToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.addFolderToolStripMenuItem.Text = "Add Folder";
            this.addFolderToolStripMenuItem.Click += new System.EventHandler(this.addFolderToolStripMenuItem_Click);
            // 
            // checkOutToolStripMenuItem
            // 
            this.checkOutToolStripMenuItem.Name = "checkOutToolStripMenuItem";
            this.checkOutToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.checkOutToolStripMenuItem.Text = "CheckOut";
            // 
            // undoCheckOutToolStripMenuItem
            // 
            this.undoCheckOutToolStripMenuItem.Name = "undoCheckOutToolStripMenuItem";
            this.undoCheckOutToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.undoCheckOutToolStripMenuItem.Text = "Undo CheckOut";
            // 
            // checkInToolStripMenuItem
            // 
            this.checkInToolStripMenuItem.Name = "checkInToolStripMenuItem";
            this.checkInToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.checkInToolStripMenuItem.Text = "CheckIn";
            // 
            // getToolStripMenuItem
            // 
            this.getToolStripMenuItem.Name = "getToolStripMenuItem";
            this.getToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.getToolStripMenuItem.Text = "Get";
            this.getToolStripMenuItem.Click += new System.EventHandler(this.getToolStripMenuItem_Click);
            // 
            // generateHyperlinkToolStripMenuItem
            // 
            this.generateHyperlinkToolStripMenuItem.Name = "generateHyperlinkToolStripMenuItem";
            this.generateHyperlinkToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.generateHyperlinkToolStripMenuItem.Text = "Generate Hyperlink";
            this.generateHyperlinkToolStripMenuItem.Click += new System.EventHandler(this.generateHyperlinkToolStripMenuItem_Click);
            // 
            // asignLinkToNavisItemToolStripMenuItem
            // 
            this.asignLinkToNavisItemToolStripMenuItem.Name = "asignLinkToNavisItemToolStripMenuItem";
            this.asignLinkToNavisItemToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.asignLinkToNavisItemToolStripMenuItem.Text = "Asign Link To navis Item";
            this.asignLinkToNavisItemToolStripMenuItem.Click += new System.EventHandler(this.asignLinkToNavisItemToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.88889F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.55556F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.55556F));
            this.tableLayoutPanel1.Controls.Add(this.vaultNavigationPathComboboxControl1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.vaultBrowserControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.fileName_label, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.revision_label, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.fileType_comboBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.m_tabControl, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.fileName_multiPartTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 25);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.14286F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(337, 365);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // vaultNavigationPathComboboxControl1
            // 
            this.vaultNavigationPathComboboxControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vaultNavigationPathComboboxControl1.AutoSize = true;
            this.vaultNavigationPathComboboxControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.vaultNavigationPathComboboxControl1.Enabled = false;
            this.vaultNavigationPathComboboxControl1.Location = new System.Drawing.Point(66, 3);
            this.vaultNavigationPathComboboxControl1.Name = "vaultNavigationPathComboboxControl1";
            this.vaultNavigationPathComboboxControl1.Size = new System.Drawing.Size(181, 20);
            this.vaultNavigationPathComboboxControl1.TabIndex = 10;
            // 
            // vaultBrowserControl1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.vaultBrowserControl1, 3);
            this.vaultBrowserControl1.Location = new System.Drawing.Point(3, 29);
            this.vaultBrowserControl1.Name = "vaultBrowserControl1";
            this.vaultBrowserControl1.Size = new System.Drawing.Size(331, 102);
            this.vaultBrowserControl1.TabIndex = 11;
            // 
            // fileName_label
            // 
            this.fileName_label.AutoSize = true;
            this.fileName_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileName_label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.fileName_label.Location = new System.Drawing.Point(2, 134);
            this.fileName_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fileName_label.Name = "fileName_label";
            this.fileName_label.Size = new System.Drawing.Size(59, 26);
            this.fileName_label.TabIndex = 0;
            this.fileName_label.Text = "File name:";
            this.fileName_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // revision_label
            // 
            this.revision_label.AutoSize = true;
            this.revision_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.revision_label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.revision_label.Location = new System.Drawing.Point(2, 160);
            this.revision_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.revision_label.Name = "revision_label";
            this.revision_label.Size = new System.Drawing.Size(59, 26);
            this.revision_label.TabIndex = 2;
            this.revision_label.Text = "Files of type:";
            this.revision_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fileType_comboBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.fileType_comboBox, 2);
            this.fileType_comboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileType_comboBox.Enabled = false;
            this.fileType_comboBox.FormattingEnabled = true;
            this.fileType_comboBox.Location = new System.Drawing.Point(65, 162);
            this.fileType_comboBox.Margin = new System.Windows.Forms.Padding(2);
            this.fileType_comboBox.Name = "fileType_comboBox";
            this.fileType_comboBox.Size = new System.Drawing.Size(270, 21);
            this.fileType_comboBox.TabIndex = 3;
            // 
            // m_tabControl
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.m_tabControl, 3);
            this.m_tabControl.Controls.Add(this.tabPage1);
            this.m_tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tabControl.Location = new System.Drawing.Point(3, 189);
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.Size = new System.Drawing.Size(331, 173);
            this.m_tabControl.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_associationsTreeView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(323, 147);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Uses";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // m_associationsTreeView
            // 
            this.m_associationsTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_associationsTreeView.Location = new System.Drawing.Point(6, 6);
            this.m_associationsTreeView.Name = "m_associationsTreeView";
            this.m_associationsTreeView.Size = new System.Drawing.Size(311, 133);
            this.m_associationsTreeView.TabIndex = 0;
            // 
            // fileName_multiPartTextBox
            // 
            this.fileName_multiPartTextBox.AutoSize = true;
            this.fileName_multiPartTextBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.fileName_multiPartTextBox, 2);
            this.fileName_multiPartTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileName_multiPartTextBox.EditMode = Autodesk.DataManagement.Client.Framework.Forms.Controls.MultiPartTextBoxControl.EditModeOption.FullEdit;
            this.fileName_multiPartTextBox.Location = new System.Drawing.Point(65, 136);
            this.fileName_multiPartTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.fileName_multiPartTextBox.Name = "fileName_multiPartTextBox";
            this.fileName_multiPartTextBox.Parts = ((System.Collections.Generic.IEnumerable<string>)(resources.GetObject("fileName_multiPartTextBox.Parts")));
            this.fileName_multiPartTextBox.Size = new System.Drawing.Size(270, 22);
            this.fileName_multiPartTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(1, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 24);
            this.label1.TabIndex = 12;
            this.label1.Text = "Look For:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.navigateBack_toolStripButton,
            this.navigateUp_toolStripButton,
            this.switchView_toolStripSplitButton});
            this.toolStrip1.Location = new System.Drawing.Point(250, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(87, 26);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // navigateBack_toolStripButton
            // 
            this.navigateBack_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.navigateBack_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("navigateBack_toolStripButton.Image")));
            this.navigateBack_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.navigateBack_toolStripButton.Name = "navigateBack_toolStripButton";
            this.navigateBack_toolStripButton.Size = new System.Drawing.Size(28, 23);
            this.navigateBack_toolStripButton.Text = "Back";
            this.navigateBack_toolStripButton.Click += new System.EventHandler(this.navigateBack_toolStripButton_Click);
            // 
            // navigateUp_toolStripButton
            // 
            this.navigateUp_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.navigateUp_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("navigateUp_toolStripButton.Image")));
            this.navigateUp_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.navigateUp_toolStripButton.Name = "navigateUp_toolStripButton";
            this.navigateUp_toolStripButton.Size = new System.Drawing.Size(28, 23);
            this.navigateUp_toolStripButton.Text = "Up";
            this.navigateUp_toolStripButton.Click += new System.EventHandler(this.navigateUp_toolStripButton_Click);
            // 
            // switchView_toolStripSplitButton
            // 
            this.switchView_toolStripSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.switchView_toolStripSplitButton.Image = global::LinkNavigator.Resource1.ViewOptions_16;
            this.switchView_toolStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.switchView_toolStripSplitButton.Name = "switchView_toolStripSplitButton";
            this.switchView_toolStripSplitButton.Size = new System.Drawing.Size(40, 28);
            this.switchView_toolStripSplitButton.Text = "Switch View";
            this.switchView_toolStripSplitButton.ButtonClick += new System.EventHandler(this.switchView_toolStripSplitButton_ButtonClick);
            this.switchView_toolStripSplitButton.DropDownOpening += new System.EventHandler(this.switchView_toolStripSplitButton_DropDownOpening);
            // 
            // vaultViewerctr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "vaultViewerctr";
            this.Size = new System.Drawing.Size(344, 390);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.m_tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem login_toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logout_toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_addFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_advancedFindToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoCheckOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label fileName_label;
        private System.Windows.Forms.Label revision_label;
        private System.Windows.Forms.ComboBox fileType_comboBox;
        private System.Windows.Forms.TabControl m_tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TreeView m_associationsTreeView;
        private Autodesk.DataManagement.Client.Framework.Forms.Controls.MultiPartTextBoxControl fileName_multiPartTextBox;
        private Autodesk.DataManagement.Client.Framework.Vault.Forms.Controls.VaultBrowserControl vaultBrowserControl1;
        private Autodesk.DataManagement.Client.Framework.Vault.Forms.Controls.VaultNavigationPathComboboxControl vaultNavigationPathComboboxControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton navigateBack_toolStripButton;
        private System.Windows.Forms.ToolStripButton navigateUp_toolStripButton;
        private System.Windows.Forms.ToolStripSplitButton switchView_toolStripSplitButton;
        private System.Windows.Forms.ToolStripMenuItem generateHyperlinkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asignLinkToNavisItemToolStripMenuItem;
    }
}
