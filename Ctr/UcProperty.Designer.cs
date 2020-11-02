namespace Training.Ctr
{
    partial class UcProperty
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
            this.tbOut = new System.Windows.Forms.RichTextBox();
            this.tbCategoryName = new System.Windows.Forms.TextBox();
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.lblPropertyName = new System.Windows.Forms.Label();
            this.tbPropertyName = new System.Windows.Forms.TextBox();
            this.lblValue = new System.Windows.Forms.Label();
            this.tbPropertyValue = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbOut
            // 
            this.tbOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOut.Location = new System.Drawing.Point(0, 0);
            this.tbOut.Name = "tbOut";
            this.tbOut.Size = new System.Drawing.Size(297, 302);
            this.tbOut.TabIndex = 0;
            this.tbOut.Text = "";
            // 
            // tbCategoryName
            // 
            this.tbCategoryName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCategoryName.Location = new System.Drawing.Point(95, 305);
            this.tbCategoryName.Name = "tbCategoryName";
            this.tbCategoryName.Size = new System.Drawing.Size(202, 20);
            this.tbCategoryName.TabIndex = 1;
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCategoryName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCategoryName.Location = new System.Drawing.Point(0, 305);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(89, 20);
            this.lblCategoryName.TabIndex = 2;
            this.lblCategoryName.Text = "Category Name:";
            this.lblCategoryName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPropertyName
            // 
            this.lblPropertyName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPropertyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPropertyName.Location = new System.Drawing.Point(0, 328);
            this.lblPropertyName.Name = "lblPropertyName";
            this.lblPropertyName.Size = new System.Drawing.Size(89, 20);
            this.lblPropertyName.TabIndex = 4;
            this.lblPropertyName.Text = "Property Name:";
            this.lblPropertyName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbPropertyName
            // 
            this.tbPropertyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPropertyName.Location = new System.Drawing.Point(95, 328);
            this.tbPropertyName.Name = "tbPropertyName";
            this.tbPropertyName.Size = new System.Drawing.Size(202, 20);
            this.tbPropertyName.TabIndex = 3;
            // 
            // lblValue
            // 
            this.lblValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblValue.Location = new System.Drawing.Point(0, 351);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(89, 20);
            this.lblValue.TabIndex = 6;
            this.lblValue.Text = "Property Value:";
            this.lblValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbPropertyValue
            // 
            this.tbPropertyValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPropertyValue.Location = new System.Drawing.Point(95, 351);
            this.tbPropertyValue.Name = "tbPropertyValue";
            this.tbPropertyValue.Size = new System.Drawing.Size(202, 20);
            this.tbPropertyValue.TabIndex = 5;
            // 
            // btnFind
            // 
            this.btnFind.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnFind.Location = new System.Drawing.Point(0, 374);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(300, 26);
            this.btnFind.TabIndex = 7;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnFind_MouseUp);
            // 
            // UcProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.tbPropertyValue);
            this.Controls.Add(this.lblPropertyName);
            this.Controls.Add(this.tbPropertyName);
            this.Controls.Add(this.lblCategoryName);
            this.Controls.Add(this.tbCategoryName);
            this.Controls.Add(this.tbOut);
            this.Name = "UcProperty";
            this.Size = new System.Drawing.Size(300, 400);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox tbOut;
        private System.Windows.Forms.TextBox tbCategoryName;
        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.Label lblPropertyName;
        private System.Windows.Forms.TextBox tbPropertyName;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.TextBox tbPropertyValue;
        private System.Windows.Forms.Button btnFind;
    }
}
