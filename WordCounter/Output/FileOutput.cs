using System;
using WordCounter.Counter;

namespace WordCounter.Output
{
	public class FileOutput : IOutput
	{
		public FileOutput(string outputPath, IOutputWriter outputWriter)
		{
            OutputPath = outputPath;
            OutputWriter = outputWriter;
		}

        public readonly string OutputPath;

        public readonly IOutputWriter OutputWriter;

        private readonly char[] _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        private const string FILE_EXTENSION = ".txt";

        private const string FILE_PREPEND_NAME = "FILE_";

        private const string EXCLUDED_WORDS_COUNT_FILE_NAME = "EXCLUDED_WORDS_COUNT";

        /// <summary>
        /// Creates output from <see cref="CountResult"/> and uses <see cref="IOutputWriter"/>
        /// to concurrenly write the output content to files.
        /// </summary>
        /// <param name="result"></param>
        public void GenerateOutput(CountResult result)
        {
            Parallel.ForEach(_alphabet, character =>
            {
                var matchingEntries = result.FrequencyCounter.Where(entry => entry.Key.First() == character);
                string content = "";
                foreach (var entry in matchingEntries)
                {
                    string text = entry.Key + " " + entry.Value + "\n";
                    content += text;
                }
                string fileName = string.Concat(FILE_PREPEND_NAME, character, FILE_EXTENSION);
                OutputWriter.WriteOutput(content, fileName);
            });
            OutputWriter.WriteOutput(
                string.Concat("Number of words exluded: ", result.ExcludedCounter),
                string.Concat(EXCLUDED_WORDS_COUNT_FILE_NAME, FILE_EXTENSION));
        }

        public bool Validate()
        {
            try
            {
                Directory.CreateDirectory(OutputPath);
                return true;
            } catch (Exception)
            {
                return false;
            }
        }
    }
}

