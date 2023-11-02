using System;
namespace WordCounter.Counter
{
	public abstract class Counter : ICounter
	{
		public Counter(IEnumerable<string> excludedWords)
		{
            _excludedWords = new List<string>();
            foreach (string word in excludedWords)
            {
                _excludedWords.Add(word.ToUpper());
            }
        }

        protected readonly List<string> _excludedWords;

        public virtual CountResult Count(IEnumerable<string> input)
        {
            throw new NotImplementedException();
        }
    }
}

