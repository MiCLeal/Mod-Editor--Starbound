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
    /// <summary>
    /// Classe responsável por mostrar janela de requisição de directório.
    /// </summary>
    public partial class SetStarboundDirectory : Form
    {
        /// <summary>
        /// Construtor da Classe "SetStarboundDirectory" onde se inicializa os controles da janela.
        /// </summary>
        public SetStarboundDirectory()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Método mostra janela para escolher a pasta de instalaçã do Starbound.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Directory_Start(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();

            txtDirectory.Text = folderBrowserDialog1.SelectedPath;
        }

        /// <summary>
        /// Método verifica se a pasta é a mesma de instalação do Starbound.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Directory_Check(object sender, EventArgs e)
        {
            if (File.Exists(folderBrowserDialog1.SelectedPath + @"\win32\starbound.exe"))
            {
                Directories.StarboundDirectory = txtDirectory.Text;

                Directory.CreateDirectory(Directories.UserPrefsDirectory);
                XmlPrefs.CriarArquivoXML();
                MessageBox.Show("Created directory \"" + Directories.UserPrefsDirectory + "\"");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Pasta Inválida! \"" + txtDirectory.Text + "\"");
            }
        }
    }
}
