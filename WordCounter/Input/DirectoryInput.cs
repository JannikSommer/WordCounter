using System;
using System.Collections.Concurrent;

namespace WordCounter.Input
{
	public class DirectoryInput :IInput
	{
		public DirectoryInput(string inputPath)
		{
            InputPath = inputPath;
		}

        public readonly string InputPath;

        /// <summary>
        /// Retires the text from all the files in the specified directory. 
        /// </summary>
        /// <param name="directoryPath"><see cref="string"/> that specifies the directory path.</param>
        /// <returns><see cref="IEnumerable{string}"/> of files content found at the directory. </returns>
        public IEnumerable<string> RetrieveData()
        {
            IEnumerable<string> filePaths = Directory.GetFiles(InputPath);
            ConcurrentBag<string> filesContent = new ConcurrentBag<string>();
            Parallel.ForEach(filePaths, file =>
            {
                string content = File.ReadAllText(file);
                filesContent.Add(content);
            });
            return filesContent;
        }

        /// <summary>
        /// Validates the specified directory path. 
        /// </summary>
        /// <param name="path"><see cref="string"/> that specifies the directory path to validate.</param>
        /// <returns><see cref="boolean"/> with value of true for successful validation.</returns>
        public bool Validate()
        {
            if (!Directory.Exists(InputPath))
            {
                return false;
            }
            return true;
        }

    }
}

