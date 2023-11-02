using System;
namespace WordCounterTests
{
	[TestClass]
	public class DirectoryInputTests
	{
		[TestMethod]
		[DataRow("TestData/", true, 2)]
        [DataRow("SomeDir/", false, 0)]
        public void RetrieveData_CanFindAndParseTextFile(string path, bool validPath, int expectedInputCount)
		{
			IInput input = new DirectoryInput(path);
			if (validPath)
			{
				IEnumerable<string> text = input.RetrieveData();
				Assert.AreEqual(expectedInputCount, text.Count());
				Assert.AreEqual("Lorem", text.First());
			}
			else
			{
				Assert.ThrowsException<DirectoryNotFoundException>(() =>
				{
                    _ = input.RetrieveData();
                });
			}
		}

		[TestMethod]
		[DataRow("TestData/", true)]
        [DataRow("InvalidDir/", false)]
        public void Validate_CanValidatePath(string path, bool expectedValidation)
		{
            IInput input = new DirectoryInput(path);
			bool actual = input.Validate();
			Assert.AreEqual(expectedValidation, actual);
        }
    }
}

