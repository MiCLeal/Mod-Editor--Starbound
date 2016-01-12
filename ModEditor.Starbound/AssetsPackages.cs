using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModEditor.Starbound
{
    /// <summary>
    /// Classe com métodos para manusear os pacotes de assets.
    /// </summary>
    internal static class AssetsPackages
    {
        /// <summary>
        /// Variável com diretório do arquivo "unpack_assets.bat".
        /// </summary>
        private static String unpackDirectory = Directories.StarboundDirectory + @"\win32\unpack_assets.bat";

        /// <summary>
        /// Variávelcom diretório do arquivo "packer_assets.bat".
        /// </summary>
        private static String packerDirectory = Directories.ModsDirectory + @"\packer_assets.bat";

        /// <summary>
        /// Variável de StreamWriter que irá escrever o bat.
        /// </summary>
        private static StreamWriter stwEscreverBat;

        /// <summary>
        /// Este método extrai os assets do pacote de assets do Starbound, para que possam ser editados ou usados como referência.
        /// </summary>
        public static void unpackAssets()
        {
            Directory.SetCurrentDirectory(Directories.StarboundDirectory + @"\win32");

            if (!File.Exists(unpackDirectory))
            {                
                stwEscreverBat = new StreamWriter(unpackDirectory);
                stwEscreverBat.WriteLine("@echo off");
                stwEscreverBat.WriteLine("echo Unpacking ..\\assets\\packed.pak into ..\\assets\\unpacked\\");
                stwEscreverBat.WriteLine("echo This may take a long time.");
                stwEscreverBat.WriteLine("start /wait /min .\\asset_unpacker.exe ..\\assets\\packed.pak ..\\assets\\unpacked");
                stwEscreverBat.WriteLine("echo Done.");
                stwEscreverBat.WriteLine("pause");
                stwEscreverBat.Close();

                if(Directory.Exists(Directories.StarboundDirectory + "\\assets\\Unpacked"))
                {
                    System.Windows.Forms.MessageBox.Show("The folder \"unpaked\" already exists in " + Directories.StarboundDirectory + "\\assets\\" + ". Please, delete it.");
                    System.Diagnostics.Process.Start("Explorer", Directories.StarboundDirectory + @"\assets");
                }
                else
                {
                    System.Diagnostics.Process.Start(unpackDirectory);
                }                
            }
            else
            {
                if (Directory.Exists(Directories.StarboundDirectory + @"\assets\Unpacked"))
                {
                    System.Windows.Forms.MessageBox.Show("The folder \"unpaked\" already exists in \"" + Directories.StarboundDirectory + "\\assets\\\"" + ". Please, delete it.");
                    System.Diagnostics.Process.Start("Explorer", Directories.StarboundDirectory + @"\assets");
                }
                else
                {
                    System.Diagnostics.Process.Start(unpackDirectory);
                }
            }
        }

        public static void unpackAssets(int n)
        {
            Directory.SetCurrentDirectory(Directories.StarboundDirectory + @"\win32");

            System.Diagnostics.ProcessStartInfo unpackInfo = new System.Diagnostics.ProcessStartInfo("cmd", "@echo off");
            System.Diagnostics.Process unpack = new System.Diagnostics.Process();
            unpackInfo.UseShellExecute = false;
            unpackInfo.RedirectStandardInput = true;
            unpackInfo.RedirectStandardOutput = true;
            unpackInfo.WorkingDirectory = Directory.GetCurrentDirectory();
            unpack.StartInfo = unpackInfo;
            unpack.Start();
            System.Windows.Forms.MessageBox.Show("Please wait... (It could take a while!)");
            
            unpack.StandardInput.WriteLine("call .\\asset_unpacker.exe ..\\assets\\packed.pak ..\\assets\\unpacked");
            unpack.StandardInput.Close();
            // Console.Out.WriteLine(unpack.StandardOutput.ReadToEnd());
            // Console.In.ReadLine();
            System.Windows.Forms.MessageBox.Show("Assets successfuly unpacked to \"" + Directories.StarboundDirectory + "\\assets\\unpacked" + "\"");

        }

        /// <summary>
        /// Método responsável de colocar os mods feitos em pacotes.
        /// </summary>
        /// <param name="mod">Parâmetro onde deve ir o nome do "mod"</param>
        public static void packMod(String mod)
        {
            Directory.SetCurrentDirectory(Directories.StarboundDirectory + @"\win32");

            // Teste
            // mod = "Outpost Items Early";

            if (!File.Exists(packerDirectory))
            {
                stwEscreverBat = new StreamWriter(packerDirectory);
                stwEscreverBat.WriteLine("@echo off");
                stwEscreverBat.WriteLine("start .\\asset_packer.exe " + mod + " " + mod +  ".modpak");
                stwEscreverBat.WriteLine("echo Done.");
                stwEscreverBat.WriteLine("pause");
                stwEscreverBat.Close();

                if (File.Exists(Directories.ModsDirectory + "\\" + mod + ".modpak"))
                {
                    System.Windows.Forms.MessageBox.Show("The mod pak \"" + mod + ".modpak\" already exists in " + Directories.ModsDirectory + ". Please, delete it or rename it.");
                    System.Diagnostics.Process.Start("Explorer", Directories.ModsDirectory);
                }
                else
                {
                    System.Diagnostics.Process.Start(packerDirectory);
                }
            }
            else
            {
                if (File.Exists(Directories.ModsDirectory + "\\" + mod + ".modpak"))
                {
                    System.Windows.Forms.MessageBox.Show("The mod pak \"" + mod + ".modpak\" already exists in " + Directories.ModsDirectory + ". Please, delete it or rename it.");
                    System.Diagnostics.Process.Start("Explorer", Directories.ModsDirectory);
                }
                else
                {
                    System.Diagnostics.Process.Start(packerDirectory);
                }
            }
        }

    }
}