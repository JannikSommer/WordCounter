using System;
using WordCounter.Counter;

namespace WordCounter.Output
{
	public interface IOutput
	{
		public bool Validate();
		public void GenerateOutput(CountResult result);
	}
}

