using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ModEditor.Starbound
{
    /// <summary>
    /// Classe que cria o Controle de Usuário para visualizar pastas e arquivos dos Assets.
    /// </summary>
    public partial class NewModUserControl : UserControl
    {
        /// <summary>
        /// Váriavel com caminho raíz do arquivo.
        /// </summary>
        private string path = Directories.AssetsDorectory;

        /// <summary>
        /// Variável com caminho do diretório "pai".
        /// </summary>
        private string upLevel = null;

        /// <summary>
        /// Variável com caminho completo do diretório "pai".
        /// </summary>
        private static string sub = null;

        /// <summary>
        /// Variável que deve ser carregado com o nome do mod.
        /// </summary>
        private string modName = null;

        private string[] extesoes = { ".config", ".weather", ".lua", ".frames", ".aicommand", ".aimission",
            ".animation", ".behavior", ".biome", ".configfunctions", ".cinematic", ".disabled", ".codex", ".codexitem",
            ".cursor", ".damage",".json", ".dungeon", ".effectsource", ".activeitem", ".item", ".chest", ".legs", ".head",
            ".back", ".coinitem", ".sword", ".consumable", ".unlock", ".gun", ".sapling", ".generatedgun", ".instrument", ".liqitem",
            ".matitem", ".staff", ".throwitem", ".beamaxe", "miningtool", ".flashlight", ".painttool", ".grapplinghook", ".wiretool",
            ".tillingtool", ".harvestingtool", ".function", ".2function", ".liquid", ".monstertype", ".monsterskill", ".monsterpart",
            ".namesource", ".npctype", ".object", ".parallax", ".particle", ".bush", ".grass", ".modularstem", ".modularfoliage", ".projectile",
            ".questtemplate", ".recipe", ".structure", ".spawntypes", ".species", ".stagehand", ".statuseffect", ".tech", ".techitem", ".tenant",
            ".terrain", ".ridgeblocks", ".material", ".matmod", ".treasurepool", ".vehicle", ".treasurepools" };

        public NewModUserControl()
        {
            InitializeComponent();

            PopulateTreeView();
        }

        /// <summary>
        /// Checa e retorna uma string com o caminho do Sub Diretório do atual selecionado.
        /// </summary>
        /// <param name="child">TreeNode selecionado.</param>
        private string CheckParent(TreeNode child)
        {
            if(child.Parent!= null)
            {
                TreeNode temp = child.Parent;
                upLevel = this.CheckParent(temp) + @"\" + child.Text;
            }
            else
            {
                upLevel = child.Text;
            }

            return upLevel;
        }

        /// <summary>
        /// Método para popular a TreeView com as pastas do diretório "Unpacked".
        /// </summary>
        private void PopulateTreeView()
        {
            TreeNode rootnode;
            DirectoryInfo info = new DirectoryInfo(Directories.AssetsDorectory + @"\unpacked");
            if (info.Exists)
            {
                rootnode = new TreeNode(info.Name);
                rootnode.Tag = info;
                GetDirectories(info.GetDirectories(), rootnode);
                assetsTreeView.Nodes.Add(rootnode);
            }
        }

        /// <summary>
        /// Método para carregar os diretórios para a TreeView
        /// </summary>
        /// <param name="subsDirs">Parâmetro Array de diretórios (DirectoryInfo)</param>
        /// <param name="nodeToAddTo">Parâmetro com da árvore (TreeNode)</param>
        private void GetDirectories(DirectoryInfo[] subsDirs, TreeNode nodeToAddTo)
        {
            TreeNode aNode;
            DirectoryInfo[] subSubDirs;
            foreach (DirectoryInfo subDir in subsDirs)
            {
                aNode = new TreeNode(subDir.Name, 0, 2);
                aNode.Tag = subDir;
                aNode.ImageKey = "folder";

                subSubDirs = subDir.GetDirectories();

                if (subSubDirs.Length != 0)
                {
                    GetDirectories(subSubDirs, aNode);
                }

                nodeToAddTo.Nodes.Add(aNode);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void assetsTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            #region CheckParent
            upLevel = "";
            TreeNode newSelected = e.Node;
            sub = CheckParent(newSelected);
           // textBox1.Text = sub; // For Tests
            #endregion

            assetsListView.Items.Clear();
            DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item = null;

            foreach (DirectoryInfo dir in nodeDirInfo.GetDirectories())
            {
                item = new ListViewItem(dir.Name, 0);
                subItems = new ListViewItem.ListViewSubItem[]
                {
                    new ListViewItem.ListViewSubItem(item, "Directory"),
                    new ListViewItem.ListViewSubItem(item, dir.LastAccessTime.ToShortDateString())
                };
                item.SubItems.AddRange(subItems);
                assetsListView.Items.Add(item);
            }

            foreach (FileInfo file in nodeDirInfo.GetFiles())
            {
                item = new ListViewItem(file.Name, 1);
                subItems = new ListViewItem.ListViewSubItem[]
                {
                    new ListViewItem.ListViewSubItem(item, "file"),
                    new ListViewItem.ListViewSubItem(item, file.LastAccessTime.ToShortDateString())
                };

                item.SubItems.AddRange(subItems);
                assetsListView.Items.Add(item);
            }

            assetsListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }


        private void assetsListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button.Equals(MouseButtons.Left))
                {
                    GetModName(Directories.NewModName);

                    foreach (ListViewItem listViewItem in assetsListView.SelectedItems)
                    {
                        string extensao = Path.GetExtension(path + @"\" + sub + @"\" + assetsListView.FocusedItem.Text);

                        if (extesoes.Contains<string>(extensao))
                        {
                            string arquivoDir = Path.GetFullPath(path + @"\" + sub + @"\" + assetsListView.FocusedItem.Text);
                            Directory.CreateDirectory(Directories.ModsDirectory + @"\" + modName + @"\" + sub.Remove(0, 9));
                            File.Copy(arquivoDir, Directories.ModsDirectory + @"\" + modName + @"\" + sub.Remove(0, 9) + @"\" + Path.GetFileName(arquivoDir));
                            CodeEditorForm.GetTabPage(Directories.ModsDirectory + @"\" + modName + @"\" + sub.Remove(0, 9) + @"\" + Path.GetFileName(arquivoDir));
                            CodeEditorForm codeForm = new CodeEditorForm();
                            codeForm.Show();

                        }
                        else
                        {
                            MessageBox.Show("Arquivo não suportado.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                
            }
        }

        private void assetsListView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Right))
            {
                assetsListViewRightClick();
            }
        }

        /// <summary>
        /// Método para criar e mostrar o ContextMenu e seus items qunado botão direito do mouse for pressionado no ListView.
        /// </summary>
        private void assetsListViewRightClick()
        {
            try {
                foreach (ListViewItem listViewItem in assetsListView.SelectedItems)
                {
                    string extensao = Path.GetExtension(path + @"\" + sub + @"\" + assetsListView.FocusedItem.Text);

                    if (extesoes.Contains<string>(extensao))
                    {
                        ToolStripMenuItem open = new ToolStripMenuItem();
                        open.Text = "Open";
                        open.Click += Open_Click;
                        assetsListViewContextMenu.Items.Add(open);
                        assetsListViewContextMenu.Show();
                    }
                    else
                    {
                        MessageBox.Show("Arquivo não suportado.");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Open_Click(object sender, EventArgs e)
        {
            try
            {
                GetModName(Directories.NewModName);
                foreach (ListViewItem listViewItem in assetsListView.SelectedItems)
                {
                    string arquivoDir = Path.GetFullPath(path + @"\" + sub + @"\" + assetsListView.FocusedItem.Text);
                    Directory.CreateDirectory(Directories.ModsDirectory + @"\" + modName + @"\" + sub.Remove(0, 9));
                    File.Copy(arquivoDir, Directories.ModsDirectory + @"\" + modName + @"\" + sub.Remove(0, 9) + @"\" + Path.GetFileName(arquivoDir));
                    System.Diagnostics.Process.Start("notepad++", Directories.ModsDirectory + @"\" + modName + @"\" + sub.Remove(0, 9) + @"\" + Path.GetFileName(arquivoDir));
                    CodeEditorForm.GetTabPage(Directories.ModsDirectory + @"\" + modName + @"\" + sub.Remove(0, 9) + @"\" + Path.GetFileName(arquivoDir));
                    CodeEditorForm codeForm = new CodeEditorForm();
                    codeForm.Show();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                
            }
        }

        private void assetsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
           // textBox1.Text = path + @"\" + sub + @"\" + assetsListView.FocusedItem.Text; // For Tests
        }

        public void GetModName(string modName)
        {
            this.modName = modName;
        }
    }
}

