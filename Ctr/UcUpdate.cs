using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Training.Ctr
{
    public partial class UcUpdate : UserControl
    {
        public Timer UpTimer = new Timer { Enabled = true, Interval = 1000 };

        public List<FileInfo> ListInfos = new List<FileInfo>();

        public UcUpdate()
        {
            InitializeComponent();
            btUpdate.Enabled = false;

            UpTimer.Tick += UpTimerOnTick;

            Autodesk.Navisworks.Api.Application.ActiveDocumentChanged += ApplicationOnActiveDocumentChanged;
        }

        private void ApplicationOnActiveDocumentChanged(object sender, EventArgs e)
        {
            ListInfos.Clear();
        }

        private void UpTimerOnTick(object sender, EventArgs e)
        {
            if (cbPause.Checked) return;

            if (Autodesk.Navisworks.Api.Application.ActiveDocument == null) return;

            var activeDocument = Autodesk.Navisworks.Api.Application.ActiveDocument;

            foreach (var model in activeDocument.Models)
            {
                var currentInfo = new FileInfo(model.SourceFileName);

                var lastInfo = ListInfos.FirstOrDefault(i => i.FullName == currentInfo.FullName);

                if (lastInfo != null)
                {
                    var time = Math.Abs((lastInfo.LastWriteTime - currentInfo.LastWriteTime).TotalSeconds);

                    if (time > 1)
                    {
                        ListInfos.Remove(lastInfo);
                        ListInfos.Add(currentInfo);

                        tbLog.AppendText(string.Concat(currentInfo.Name, "was updated!", Environment.NewLine));

                        if (cbUpdate.Checked)
                        {
                            UpdateModel();
                        }
                    }
                }
                else
                {
                    ListInfos.Add(currentInfo);
                }
            }
        }

        private void UpdateModel()
        {
            Autodesk.Navisworks.Api.Application.ActiveDocument.UpdateFiles();
            tbLog.AppendText(string.Concat("The active document was updated!", Environment.NewLine));
            btUpdate.Enabled = false;

        }




        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            Dock = DockStyle.Fill;
        }

        private void btmUpdate_MouseUp(object sender, MouseEventArgs e)
        {
            UpdateModel();
        }

        private void btClear_MouseUp(object sender, MouseEventArgs e)
        {
            tbLog.Clear();
        }
    }
}
