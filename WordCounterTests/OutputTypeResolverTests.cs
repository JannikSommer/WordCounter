using System;

namespace WordCounterTests
{
	[TestClass]
	public class OutputTypeResolverTests
	{
		[TestMethod]
        [DataRow("/Users/", true, typeof(FileOutput))]
        [DataRow("http://danskebank.dk/api", false, null)]
        [DataRow("1234", false, null)]
        public void ResolveOutputType(string path, bool supported, Type type)
		{
            if (supported)
            {
                IOutput output = OutputTypeResolver.ResolveOutputType(path);
                Assert.AreEqual(type, output.GetType());
            }
            else
            {
                Assert.ThrowsException<Exception>(() =>
                    _ = OutputTypeResolver.ResolveOutputType(path));
            }
        }
	}
}

