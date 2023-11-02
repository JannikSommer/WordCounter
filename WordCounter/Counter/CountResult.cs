using System;

namespace WordCounter.Counter
{
	public class CountResult
	{
		public CountResult(Dictionary<string, int> frequencyCounter, int excludedCounter)
		{
			FrequencyCounter = frequencyCounter;
            ExcludedCounter = excludedCounter;
		}

		public Dictionary<string, int> FrequencyCounter { get; set; }

		public int ExcludedCounter { get; set; }
	}
}

