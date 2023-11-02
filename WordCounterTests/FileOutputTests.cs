using System;

namespace WordCounterTests
{
	[TestClass]
	public class FileOutputTests
	{
		public class MockFileWriter : IOutputWriter
		{
			public List<string> SimulatedFileContent = new List<string>();

            public void WriteOutput(string data, string fileName)
			{
				SimulatedFileContent.Add(data);
			}
		}

		[TestMethod]
		[DataRow("TestOutputDir/", true)]
		[DataRow("", false)]
		public void Validate_CanValidateOutputPaths(string path, bool expectedValidation)
		{
			IOutput output = new FileOutput(path, new MockFileWriter());
			bool actual = output.Validate();
			Assert.AreEqual(expectedValidation, actual);
		}

		[TestMethod]
		[DataRow(new string[] { "DANSKE" })]
        [DataRow(new string[] { "DANSKE", "BANK" })]
        [DataRow(new string[] { })]
        public void CreateOutput_CanCreateOutputContent(IEnumerable<string> words)
		{
			MockFileWriter fileWriter = new MockFileWriter();
			FileOutput output = new FileOutput("", fileWriter);
			Dictionary<string, int> dict = new Dictionary<string, int>();
			foreach (string word in words)
			{
				dict.Add(word, 999);
			}

            CountResult result = new CountResult(dict, 0);
			output.GenerateOutput(result);

			foreach (string word in words)
			{
                Assert.IsTrue(
					fileWriter.SimulatedFileContent.Any(
						str => str.Contains(word)));
            }
		}
	}
}

