using System;

namespace WordCounter.Counter
{
	public interface ICounter
	{
		public CountResult Count(IEnumerable<string> input);
	}
}

