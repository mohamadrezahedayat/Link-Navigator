using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LinkNavigator
{
    public partial class FileNameForm : Form
    {
        public string folderName { get { return m_folderTitleTextBox.Text; } }
        public FileNameForm()
        {
            InitializeComponent();

        }

        private void m_okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
