using System;
using WordCounter.Counter;
using WordCounter.Input;
using WordCounter.Output;

namespace WordCounter
{
	public class Handler
	{
		public Handler(ICounter counter)
		{
			Counter = counter;
		}

        public Handler(ICounter counter, IInput input, IOutput output)
        {
            Counter = counter;

            if (!input.Validate())
            {
                throw new Exception("The input is not valid.");
            }
            if (!output.Validate())
            {
                throw new Exception("The output is not valid.");
            }
            Input = input;
			Output = output;
        }

        public ICounter Counter { get; set; }
		public IInput Input { get; set; }
		public IOutput Output { get; set; }

		public Handler AddInput(IInput input)
		{
			if (!input.Validate())
			{
				throw new Exception("The input is not valid.");
			}
			Input = input;
			return this;
		}

        public Handler AddOutput(IOutput output)
        {
			if (!output.Validate())
			{
				throw new Exception("The output is not valid.");
			}
			Output = output;
            return this;
        }

        public void Process()
		{
			if (Input is null || Output is null)
			{
				throw new Exception("Add IInput and IOutput before processing data");
			}
			IEnumerable<string> inputData = Input.RetrieveData();
            CountResult result = Counter.Count(inputData);
			Output.GenerateOutput(result);
        }
    }
}

