namespace LinkNavigator
{
    partial class UcLinks
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
            this.tbLinkProperty = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // tbLinkProperty
            // 
            this.tbLinkProperty.AccessibleRole = System.Windows.Forms.AccessibleRole.Link;
            this.tbLinkProperty.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLinkProperty.Location = new System.Drawing.Point(0, 0);
            this.tbLinkProperty.Name = "tbLinkProperty";
            this.tbLinkProperty.Size = new System.Drawing.Size(297, 397);
            this.tbLinkProperty.TabIndex = 0;
            this.tbLinkProperty.Text = "Link Navigator....\n* Please Select an Item.\n";
            this.tbLinkProperty.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.tbLinkProperty_LinkClicked);
            // 
            // UcLinks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbLinkProperty);
            this.Name = "UcLinks";
            this.Size = new System.Drawing.Size(300, 400);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox tbLinkProperty;
    }
}
