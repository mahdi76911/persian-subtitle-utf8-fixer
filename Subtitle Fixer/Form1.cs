using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Subtitle_Fixer
{
    public partial class Form1 : Form
    {
        string[] desiredFormat = { "srt", "ass" };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
                if (!SubFixer(file))
                    MessageBox.Show("Wrong Format (" + file.Substring(file.LastIndexOf('\\') + 1) + ")!");
        }

        /// <summary>
        /// Determines a text file's encoding by analyzing its byte order mark (BOM).
        /// Defaults to ASCII when detection of the text file's endianness fails.
        /// </summary>
        /// <param name="filename">The text file to analyze.</param>
        /// <returns>The detected encoding.</returns>
        public static Encoding GetEncoding(string filename)
        {
            // Read the BOM
            var bom = new byte[4];
            using (FileStream file = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                file.Read(bom, 0, 4);
                file.Close();
            }

            // Analyze the BOM
            if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76) return Encoding.UTF7;
            if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) return Encoding.UTF8;
            if (bom[0] == 0xff && bom[1] == 0xfe) return Encoding.Unicode; //UTF-16LE
            if (bom[0] == 0xfe && bom[1] == 0xff) return Encoding.BigEndianUnicode; //UTF-16BE
            if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) return Encoding.UTF32;
            return Encoding.ASCII;
        }

        public string persianEncoder(string inputString)
        {
            return Encoding.GetEncoding("Windows-1256").GetString(Encoding.Default.GetBytes(inputString));
            /*Encoding windowsArabic = Encoding.GetEncoding("Windows-1256");
            byte[] bytes = Encoding.Default.GetBytes(inputString);
            string resultString = windowsArabic.GetString(bytes);
            return resultString;*/
        }

        bool SubFixer(string Address)
        {
            string fileFormat = Address.Substring(Address.LastIndexOf('.') + 1);
            if (desiredFormat.Contains(fileFormat))
            {
                StreamReader MyFile = new StreamReader(Address, Encoding.Default);
                if (GetEncoding(Address) == Encoding.ASCII)
                    {
                    string inputString = "";
                    try
                    {
                        inputString = MyFile.ReadToEnd();
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }
                    finally
                    {
                        MyFile.Close();
                    }

                    //File name changing
                    FileInfo infos = new FileInfo(Address);
                    infos.MoveTo(infos.DirectoryName + '\\' + infos.Name.Substring(0, infos.Name.LastIndexOf('.')) + ".corrupted." + fileFormat);

                    //encoding
                    string resultString = persianEncoder(inputString);

                    StreamWriter sw = new StreamWriter(Address, false, Encoding.UTF8);
                    try
                    {
                        sw.Write(resultString);
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }
                    finally
                    {
                        sw.Close();
                    }
                }
                return true;
            }
            return false;
        }

    }
}
