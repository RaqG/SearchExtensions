using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchExtensions
{
    public class FolderSearch
    {
        /* Lista todos os arquivos de um tipo de extensão informada,
            dentro de um caminho especificado */
        public string ListOfFiles(string sourceFolder, string extensionFiles)
        {
            // Coloca em um array, os diretorios e subdiretorios do caminho informado
            string[] dirs = null;
            try
            {
                dirs = Directory.GetDirectories(sourceFolder);
            }
            catch { }

            /* Se o array dir estiver vazio, significa que não há mais diretórios ou subdiretório
                Caso contrário, procura-se mais subdiretorios pelo método recursivo ListOfFiles*/
            /* Cria-se um array de files e coloca todos os arquivos daquele diretorio especifico
                dentro do array files */
            if (dirs == null || dirs.Length == 0)
            {
                try
                {
                    string[] files = Directory.GetFiles(sourceFolder, extensionFiles);
                    string file = "";

                    for (int i = 0; i < files.Length; i++)
                    {
                        file += files[i] + "\n";
                    }
                    return file;
                }
                catch
                {
                    return "";
                }
            }
            else
            {
                string filesFound = "";
                foreach (string dir in dirs)
                    filesFound += ListOfFiles(dir, extensionFiles);
                return filesFound;
            }
        }

    }
}