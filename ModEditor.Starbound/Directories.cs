using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModEditor.Starbound
{
    /// <summary>
    /// Classe estática com variáveis do tipo "Strings" de diretórios.
    /// </summary>
    public static class Directories
    {
        /// <summary>
        /// Variável que deverá ser preenchida com diretório do "Starbound".
        /// </summary>
        private static String starboundDirectory;

        /// <summary>
        /// Variável que contém o diretório dos Assets.
        /// </summary>
        private static String assetsDirectory = @"\assets";

        /// <summary>
        /// Variável que contém o diretório dos downloads de Mods.
        /// </summary>
        private static String downloadsDirectory;

        /// <summary>
        /// Variável com caminho do diretório dos mods na pasta de instalação do Starbound.
        /// </summary>
        private static String modsDirectory = @"\Giraffe_storage\Mods";

        /// <summary>
        /// Variável que contém o diretório do arquivo de preferências do usuário.
        /// </summary>
        private static String userPrefsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Mod Editor\Starbound";

        private static String newModName;

        /// <summary>
        /// Carrega variáveis com os diretórios.
        /// </summary>
        public static void LoadDirectories()
        {
            ModsDirectory = StarboundDirectory + ModsDirectory;
            AssetsDorectory = StarboundDirectory + AssetsDorectory;
            // DownloadDirectory
        }

        public static string ModsDirectory { get { return modsDirectory; } private set { modsDirectory = value; } }

        public static string StarboundDirectory { get { return starboundDirectory; } internal set { starboundDirectory = value; } }

        public static string AssetsDorectory { private set { assetsDirectory = value; } get { return assetsDirectory; } }

        public static string UserPrefsDirectory { private set { userPrefsDirectory = value; } get { return userPrefsDirectory; } }

        public static string DownloadDirectory { private set { downloadsDirectory = value; } get { return downloadsDirectory; } }

        public static string NewModName { internal set { newModName = value; } get { return newModName; } }
    }
}
