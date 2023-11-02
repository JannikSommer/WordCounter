using System;
using System.Collections.Concurrent;

namespace WordCounter.Counter
{
    public class WordFrequencyCounter : Counter
    {
        public WordFrequencyCounter(IEnumerable<string> excludedWords) : base(excludedWords)
		{
		}

        /// <summary>
        /// Counts the individual word frequency from the specified texts and counts how many
        /// exluded words are encountered. Runs concurrently for each text. 
        /// </summary>
        /// <param name="texts"><see cref="IEnumerable{string}"/> with texts which words should be counted.</param>
        /// <returns><see cref="CountResult"/> with the results of the count from all texts.</returns>
        public override CountResult Count(IEnumerable<string> texts)
        {
            int excludedWordsCounter = 0;
            ConcurrentDictionary<string, int> wordFrequencyCount = new ConcurrentDictionary<string, int>();
            Parallel.ForEach(texts, text =>
            {
                IEnumerable<string> words = text.Split();
                foreach (string word in words)
                {
                    string trimmedWord = TrimWord(word);
                    if (_excludedWords.Contains(trimmedWord.ToUpper()))
                    {
                        Interlocked.Increment(ref excludedWordsCounter);
                        continue;
                    }
                    wordFrequencyCount.AddOrUpdate(trimmedWord.ToUpper(), 1, (key, oldValue) => oldValue + 1);
                }
            });
            return new CountResult(wordFrequencyCount.ToDictionary(entry => entry.Key, entry => entry.Value), excludedWordsCounter);
        }

        private static string TrimWord(string word)
        {
            return word.TrimEnd(',').TrimEnd('.');
        }
    }
}
