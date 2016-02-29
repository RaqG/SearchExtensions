using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SearchExtensions
{
    class Program
    {
        static void Main(string[] args)
        {
            FolderSearch fs = new FolderSearch();
            FolderDestination fd = new FolderDestination();
            bool verif = true;
            string sourceFolder = "";
            string extension = "";
            string destinationFolder = "";
            string s = "";

            while (verif)
            {
                Console.WriteLine("Por favor, coloque a pasta de origem da sua procura: ");
                sourceFolder = Console.ReadLine();

                Console.WriteLine("Coloque a extensão do arquivo da sua procura: (não precisa do ponto(.))");
                extension = Console.ReadLine();

                Console.WriteLine("Coloque a pasta de destino para a cópia dos arquivos encontrados:");
                destinationFolder = Console.ReadLine();

                if (sourceFolder != "" && extension != "" && destinationFolder != "")
                {
                    verif = false;
                    Console.Clear();
                }
                else {
                    Console.Clear();
                    Console.WriteLine("Por favor, coloque as informações necessárias para fazermos sua busca. \n");
                }
            }

            s = fs.ListOfFiles(sourceFolder, "*." + extension);

            string[] lines = Regex.Split(s, "\n");

            foreach (string l in lines)
            {
                if (l != "")
                {
                    fd.CopyPasteArchiveFiles(l, destinationFolder);
                }
            }
            Console.WriteLine("Programa executado com sucesso");
        }
    }
}
