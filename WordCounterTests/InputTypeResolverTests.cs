using System;

namespace WordCounterTests
{
	[TestClass]
	public class InputTypeResolverTests
	{
		[TestMethod]
		[DataRow("/Users/", true, typeof(DirectoryInput))]
        [DataRow("http://danskebank.dk/api", false, null)]
        [DataRow("1234", false, null)]
        public void ResolveInputType(string path, bool supported, Type type)
		{
			if (supported)
			{
                IInput input = InputTypeResolver.ResolveInputType(path);
                Assert.AreEqual(type, input.GetType());
            }
			else
			{
				Assert.ThrowsException<Exception>(() =>
                    _ = InputTypeResolver.ResolveInputType(path));
            }
        }
	}
}

