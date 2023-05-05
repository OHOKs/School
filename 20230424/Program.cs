using System.IO;
using System.Linq;

namespace asdasd
{
    class Fajl
    {
        static void Main(string[] args)
        {
            string inputFileName = "D://JP//asd//input.txt";
            string outputFileName = "D://JP//output//rovid.csv";
            if(!Directory.Exists("D://JP//output//")) Directory.CreateDirectory("D://JP//output//");
            if (!File.Exists("D://JP//output//rovid.csv")) { var create = File.Create("D://JP//output//rovid.csv"); create.Close(); }

            var lines = File.ReadAllLines(inputFileName).Where(arg => !string.IsNullOrWhiteSpace(arg));

            using (StreamWriter outputFile = new StreamWriter(outputFileName))
            {
                foreach (var item in lines)
                {
                    string[] line = item.Split(';');

                    outputFile.WriteLine($"{line[0]};{line[1]}");
                }
            }
        }
    }
}
