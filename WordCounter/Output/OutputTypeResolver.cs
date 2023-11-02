using System;

namespace WordCounter.Output
{
	public static class OutputTypeResolver
	{
        public static IOutput ResolveOutputType(string outputPath)
        {
            if (outputPath.StartsWith('/'))
            {
                return new FileOutput(outputPath, new FileWriter(outputPath));
            }
            throw new Exception("No OutputType could be resolved.");
        }
    }
}

