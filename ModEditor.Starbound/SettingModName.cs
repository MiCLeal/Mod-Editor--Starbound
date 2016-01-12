using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModEditor.Starbound
{
    public partial class SettingModName : Form
    {
        public SettingModName()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(Directories.ModsDirectory + @"\" + txtModName.Text))
            {
                Directories.NewModName = txtModName.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                DialogResult dialog =  MessageBox.Show("This Mod alredy Exists!", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.ServiceNotification);
                if (dialog.Equals(DialogResult.Yes))
                {
                    Directories.NewModName = txtModName.Text;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
