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
    public partial class MainForm : Form
    {
        private SetStarboundDirectory setDirectory = new SetStarboundDirectory();

        public MainForm()
        {
            InitializeComponent();
        }

        private void unpackAssetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AssetsPackages.unpackAssets();
        }

        private void packToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AssetsPackages.packMod("");
        }

        private void aboutModEditorStarboundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void unpackAssetsBetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AssetsPackages.unpackAssets(2);
        }

        private void newModToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists(Directories.AssetsDorectory + @"\unpacked"))
            {
                SetModNameTest();
            }
            else
            {
                MessageBox.Show("Please, first unpack the assets.");
            }
        }

        public void SetModNameTest()
        {
            NewModUserControl newMod = new NewModUserControl();
            newMod.Dock = DockStyle.Fill;
            panel1.Controls.Add(newMod);
            
            SettingModName setModName = new SettingModName();
            setModName.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
        }
    }
}
