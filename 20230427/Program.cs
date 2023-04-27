using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asdasd
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFileName = "D://JP//asd//input.txt";
            string outputFileName = "D://JP//asd//kimenet.txt";
            int linesWrote = 0;

            using (StreamReader inputFile = new StreamReader(inputFileName))
            using (StreamWriter outputFile = new StreamWriter(outputFileName))
            {
                while (!inputFile.EndOfStream)
                {
                    string line = inputFile.ReadLine();
                    string[] data = line.Split(';');

                    if (int.TryParse(data[0], out int year) && year % 2 == 0)
                    {
                        linesWrote++;
                        outputFile.WriteLine(line);
                    }
                }
            }

            Console.WriteLine($"Kiírt sorok: {linesWrote}.\nNyomj egy egy gombot a bezárás érdekében.");
            Console.ReadKey();
        }
    }
}
