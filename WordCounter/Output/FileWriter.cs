using System;

namespace WordCounter.Output
{
	public class FileWriter : IOutputWriter
	{
		public FileWriter(string path)
		{
            OutputPath = path;
		}

        public readonly string OutputPath;


        public void WriteOutput(string data, string fileName)
        {
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(OutputPath, fileName)))
            {
                outputFile.WriteLine(data);
            }
        }
    }
}

