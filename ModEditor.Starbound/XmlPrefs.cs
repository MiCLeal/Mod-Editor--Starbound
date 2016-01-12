using System;

namespace ModEditor.Starbound
{
    /// <summary>
    /// Classe com métodos do arquivo XML com preferências do usuário.
    /// </summary>
    internal static class XmlPrefs
    {
        /// <summary>
        /// Método para criação do Arquivo XML com Configurações do usuário.
        /// </summary>
        public static void CriarArquivoXML()
        {
            try
            {
                System.Xml.XmlTextWriter xtrPrefs = new System.Xml.XmlTextWriter(Directories.UserPrefsDirectory + 
                    @"\UserPrefs.config", System.Text.Encoding.UTF8);

                // Inicia o documento XML.
                xtrPrefs.WriteStartDocument();

                // Escreve elemento raiz.
                xtrPrefs.WriteStartElement("Directories");
                // Escreve sub-Elementos.
                xtrPrefs.WriteElementString("Starbound", Directories.StarboundDirectory);
                xtrPrefs.WriteElementString("Mods", Directories.ModsDirectory);
                // Encerra o elemento raiz.
                xtrPrefs.WriteEndElement();
                // Escreve o XML para o arquivo e fecha o objeto escritor.
                xtrPrefs.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

            }
        }

        /// <summary>
        /// Método verifica o arquivo XML para executar o próximo necessario da aplicação.
        /// </summary>
        public static void VerificarXML()
        {
            if (System.IO.File.Exists(Directories.UserPrefsDirectory + @"\UserPrefs.config"))
            {
                System.Xml.Linq.XElement config = System.Xml.Linq.XElement.Load(Directories.UserPrefsDirectory + @"\UserPrefs.config");
                Directories.StarboundDirectory = config.Element("Starbound").Value;
                Directories.LoadDirectories();
                // Directories.ModsDirectory = config.Element("Mods").Value;
                System.Windows.Forms.Application.Run(new MainForm());
            }
            else
            {
                SetStarboundDirectory setDirectoryForm = new SetStarboundDirectory();
                System.Windows.Forms.Application.Run(setDirectoryForm);
                Directories.LoadDirectories();
                if (setDirectoryForm.DialogResult.Equals(System.Windows.Forms.DialogResult.OK))
                {
                    System.Windows.Forms.Application.Run(new MainForm());
                }
            }
        }
    }
}