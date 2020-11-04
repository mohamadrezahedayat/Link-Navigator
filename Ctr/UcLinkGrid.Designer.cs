namespace LinkNavigator
{
    partial class UcLinkGrid
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
            this.gridLinks = new System.Windows.Forms.DataGridView();
            this.txtNameFilter = new System.Windows.Forms.TextBox();
            this.lblNameFilter = new System.Windows.Forms.Label();
            this.lblUrl = new System.Windows.Forms.Label();
            this.txtUrlFilter = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtCategory = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridLinks)).BeginInit();
            this.SuspendLayout();
            // 
            // gridLinks
            // 
            this.gridLinks.AccessibleRole = System.Windows.Forms.AccessibleRole.Link;
            this.gridLinks.AllowUserToOrderColumns = true;
            this.gridLinks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridLinks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridLinks.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.gridLinks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLinks.Location = new System.Drawing.Point(0, 81);
            this.gridLinks.Name = "gridLinks";
            this.gridLinks.Size = new System.Drawing.Size(300, 377);
            this.gridLinks.TabIndex = 0;
            this.gridLinks.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLinks_CellDoubleClick);
            this.gridLinks.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridLinks_DataBindingComplete);
            // 
            // txtNameFilter
            // 
            this.txtNameFilter.Location = new System.Drawing.Point(73, 3);
            this.txtNameFilter.Name = "txtNameFilter";
            this.txtNameFilter.Size = new System.Drawing.Size(181, 20);
            this.txtNameFilter.TabIndex = 1;
            this.txtNameFilter.TextChanged += new System.EventHandler(this.txtNameFilter_TextChanged);
            // 
            // lblNameFilter
            // 
            this.lblNameFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNameFilter.Location = new System.Drawing.Point(0, 3);
            this.lblNameFilter.Name = "lblNameFilter";
            this.lblNameFilter.Size = new System.Drawing.Size(67, 20);
            this.lblNameFilter.TabIndex = 2;
            this.lblNameFilter.Text = "Link Name:";
            this.lblNameFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUrl
            // 
            this.lblUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblUrl.Location = new System.Drawing.Point(0, 29);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(67, 20);
            this.lblUrl.TabIndex = 4;
            this.lblUrl.Text = "Link URL:";
            this.lblUrl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUrlFilter
            // 
            this.txtUrlFilter.Location = new System.Drawing.Point(73, 29);
            this.txtUrlFilter.Name = "txtUrlFilter";
            this.txtUrlFilter.Size = new System.Drawing.Size(181, 20);
            this.txtUrlFilter.TabIndex = 3;
            this.txtUrlFilter.TextChanged += new System.EventHandler(this.txtUrlFilter_TextChanged);
            // 
            // lblCategory
            // 
            this.lblCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCategory.Location = new System.Drawing.Point(0, 55);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(67, 20);
            this.lblCategory.TabIndex = 6;
            this.lblCategory.Text = "Category:";
            this.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(73, 55);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(181, 20);
            this.txtCategory.TabIndex = 5;
            this.txtCategory.TextChanged += new System.EventHandler(this.txtCategory_TextChanged);
            // 
            // UcLinkGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.txtUrlFilter);
            this.Controls.Add(this.lblNameFilter);
            this.Controls.Add(this.txtNameFilter);
            this.Controls.Add(this.gridLinks);
            this.Name = "UcLinkGrid";
            this.Size = new System.Drawing.Size(300, 461);
            ((System.ComponentModel.ISupportInitialize)(this.gridLinks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtNameFilter;
        private System.Windows.Forms.Label lblNameFilter;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.TextBox txtUrlFilter;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.DataGridView gridLinks;
    }
}
