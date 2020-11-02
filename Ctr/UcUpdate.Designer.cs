namespace Training.Ctr
{
    partial class UcUpdate
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
            this.btUpdate = new System.Windows.Forms.Button();
            this.cbUpdate = new System.Windows.Forms.CheckBox();
            this.cbPause = new System.Windows.Forms.CheckBox();
            this.btClear = new System.Windows.Forms.Button();
            this.tbLog = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btUpdate
            // 
            this.btUpdate.Dock = System.Windows.Forms.DockStyle.Top;
            this.btUpdate.Location = new System.Drawing.Point(0, 0);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(200, 23);
            this.btUpdate.TabIndex = 0;
            this.btUpdate.Text = "Update";
            this.btUpdate.UseVisualStyleBackColor = true;
            this.btUpdate.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btmUpdate_MouseUp);
            // 
            // cbUpdate
            // 
            this.cbUpdate.AutoSize = true;
            this.cbUpdate.Location = new System.Drawing.Point(3, 29);
            this.cbUpdate.Name = "cbUpdate";
            this.cbUpdate.Size = new System.Drawing.Size(86, 17);
            this.cbUpdate.TabIndex = 1;
            this.cbUpdate.Text = "Auto Update";
            this.cbUpdate.UseVisualStyleBackColor = true;
            // 
            // cbPause
            // 
            this.cbPause.AutoSize = true;
            this.cbPause.Location = new System.Drawing.Point(3, 48);
            this.cbPause.Name = "cbPause";
            this.cbPause.Size = new System.Drawing.Size(56, 17);
            this.cbPause.TabIndex = 2;
            this.cbPause.Text = "Pause";
            this.cbPause.UseVisualStyleBackColor = true;
            // 
            // btClear
            // 
            this.btClear.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btClear.Location = new System.Drawing.Point(0, 377);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(200, 23);
            this.btClear.TabIndex = 3;
            this.btClear.Text = "Clear Log";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btClear_MouseUp);
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(0, 71);
            this.tbLog.Name = "tbLog";
            this.tbLog.Size = new System.Drawing.Size(208, 324);
            this.tbLog.TabIndex = 4;
            this.tbLog.Text = "Monitoring Models...";
            // 
            // UcUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.cbPause);
            this.Controls.Add(this.cbUpdate);
            this.Controls.Add(this.btUpdate);
            this.Name = "UcUpdate";
            this.Size = new System.Drawing.Size(200, 400);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.CheckBox cbUpdate;
        private System.Windows.Forms.CheckBox cbPause;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.RichTextBox tbLog;
    }
}
