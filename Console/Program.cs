using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            const string inputFilePath = "C:\\\\Users\\\\weichienyap\\\\Desktop\\\\";
            var inputFile = "combine.log";
            var inputFullPath = inputFilePath + inputFile;

            var fileExtension = Path.GetExtension(inputFullPath).ToUpper();
            var validFilePath = new List<string>() { ".LOG" };

            WriteLine("Start");

            if (!validFilePath.Contains(fileExtension))
            {
                WriteLine("Invalid Extension");
                Read();
                return;
            }
            else
            {
                WriteLine("Processing");

                GetInputData(inputFullPath);
            }


            Write("Finish");
            Read();
        }

        static void GetInputData(string inputFullPath)
        {
            var inputData = new List<string>();

            using (var reader = new StreamReader(inputFullPath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    if (!string.IsNullOrEmpty(line))
                        inputData.Add(line);
                }
            }

            if (inputData.Count() > 0)
            {
                CreateOutputData(inputData);
            }
            else
            {
                WriteLine("Input file is empty");
            }
        }

        static void CreateOutputData(List<string> inputDatas)
        {
            const string outputFileDirectory = @"C:\Users\weichienyap\Desktop\log_output.txt";

            File.Delete(outputFileDirectory);

            using (var file = new StreamWriter(outputFileDirectory))
            {
                foreach (string line in inputDatas)
                {
                    if (line.Contains("\"status\":\"domestic_delivered\""))
                        file.WriteLine(line);
                }
            }

        }
    }
}
