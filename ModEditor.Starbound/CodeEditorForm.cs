using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModEditor.Starbound
{
    public partial class CodeEditorForm : Form
    {
        private static string filePath { get; set; }

        private static bool createTab { get; set; }

        private TabPage newTab;

        private FastColoredTextBoxNS.FastColoredTextBox coloredTextBox;

        private StreamReader strArquivo;

        public CodeEditorForm()
        {
            InitializeComponent();
            TabCreate();
        }

        public void newTabs()
        {
            tabControlCodeEditor.Controls.Add(new TabPage());   
        }

        internal static void GetTabPage(string fileName)
        {
            createTab = true;
            filePath = fileName;
        }

        private void TabCreate()
        {
            if (createTab.Equals(true))
            {
                strArquivo = new StreamReader(filePath);
                newTab = new TabPage();
                coloredTextBox = new FastColoredTextBoxNS.FastColoredTextBox();
                coloredTextBox.Dock = DockStyle.Fill;
                coloredTextBox.AutoCompleteBrackets = true;
                coloredTextBox.AutoIndent = true;
                coloredTextBox.Text = strArquivo.ReadToEnd();
                newTab.Text = Path.GetFileName(filePath);
                newTab.ToolTipText = filePath;
                newTab.AllowDrop = true;
                newTab.Controls.Add(coloredTextBox);
                this.tabControlCodeEditor.Controls.Add(newTab);
            }

            createTab = false;
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            
        }
    }
}
