using System;

namespace WordCounter.Output
{
	public interface IOutputWriter
	{
        public void WriteOutput(string data, string fileName);
	}
}

