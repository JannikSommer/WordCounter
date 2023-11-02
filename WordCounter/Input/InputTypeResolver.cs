using System;

namespace WordCounter.Input
{
	public static class InputTypeResolver
	{
		public static IInput ResolveInputType(string inputPath)
		{
            if (Directory.Exists(inputPath))
			{
				return new DirectoryInput(inputPath);
			}
			throw new Exception("No InputType could be resolved");
		}
	}
}

