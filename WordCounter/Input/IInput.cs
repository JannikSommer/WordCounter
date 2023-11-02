using System;

namespace WordCounter.Input
{
	public interface IInput
	{
		public bool Validate();
		public IEnumerable<string> RetrieveData();
	}
}

