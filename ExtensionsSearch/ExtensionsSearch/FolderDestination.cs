using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchExtensions
{
    /* Copia os arquivos procurados em uma pasta específica*/
    public class FolderDestination
    {
        public void CopyPasteArchiveFiles(string file, string destinationFolder)
        {
            string fileName = file.Split('\\').Last();
            string newFile = Path.Combine(destinationFolder, fileName);
            try
            {
                if (!Directory.Exists(destinationFolder))
                {
                    Directory.CreateDirectory(destinationFolder);
                }
                if (!File.Exists(newFile))

                    File.Copy(file, newFile, true);
                else
                    Console.WriteLine("O arquivo " + fileName + " já foi copiado.");
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
