using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class FileHelper
    {
        public static void WriteFileAsync(string dir, string file, string content)
        {
            Console.WriteLine("Async Write File has started");
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(dir, file)))
            {
                  outputFile.Write(content);
            }
            Console.WriteLine("Async Write File has completed");
            
        }
    }
}
