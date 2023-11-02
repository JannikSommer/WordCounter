using System;
namespace WordCounterTests
{
	[TestClass]
	public class WordCounterTests
	{
		[TestMethod]
		[DataRow(new[] { "Danske Bank interView" }, new [] {"hund"} , 3)]
        [DataRow(new[] { "Danske Bank interView" }, new[] { "bank" }, 2)]
        [DataRow(new[] { "" }, new[] { "" }, 0)]
        [DataRow(new[] { "Bank BANK BAnk BANK" }, new[] { "hund" }, 1)]
        public void Count_CanCountWords(string[] text, string[] excludedWords, int wordsCount)
		{
            WordFrequencyCounter counter = new WordFrequencyCounter(excludedWords);
			var result = counter.Count(text);
			Assert.AreEqual(wordsCount, result.FrequencyCounter.Count);
		}

        [TestMethod]
        [DataRow(new[] { "Danske Bank interView" }, new[] { "hund" }, 0)]
        [DataRow(new[] { "Danske Bank interView" }, new[] { "danske", "bank" }, 2)]
        [DataRow(new[] { "" }, new[] { "danske" }, 0)]
        [DataRow(new[] { "Bank bank bank bank" }, new[] { "bank" }, 4)]
        [DataRow(new[] { "Bank bank bank bank" }, new[] { "danske" }, 0)]
        public void Count_CanExcludeWords(string[] text, string[] excludedWords, int excludedWordsCount)
		{
            WordFrequencyCounter counter = new WordFrequencyCounter(excludedWords);
            var result = counter.Count(text);
            Assert.AreEqual(excludedWordsCount, result.ExcludedCounter);
        }

        [TestMethod]
        [DataRow(new[] { "Danske Bank interView" }, "bank", 1)]
        [DataRow(new[] { "Danske Bank bank" }, "bank", 2)]
        [DataRow(new[] { "" }, "bank", 0)]
        [DataRow(new[] { "Bank bank bank bank" }, "bank", 4)]
        public void Count_CanCountWordFrequency(string[] text, string key, int expectedCount)
        {
            WordFrequencyCounter counter = new WordFrequencyCounter(new string[] {""});
            var result = counter.Count(text);

            if (expectedCount != 0)
            {
                Assert.AreEqual(expectedCount, result.FrequencyCounter[key.ToUpper()]);
            }
            else
            {
                Assert.ThrowsException<KeyNotFoundException>(() =>
                _ = result.FrequencyCounter[key.ToUpper()]);
            }
        }

        [TestMethod]
        [DataRow(new[] { "" }, "bank", 0)]
        [DataRow(new[] { "Danske Bank" }, "bank", 1)]
        [DataRow(new[] { "Danske Bank", "Danske Bank" }, "bank", 2)]
        [DataRow(new[] { "Danske Bank", "Danske Bank", "Danske Bank" }, "bank", 3)]
        public void Count_CanCountWordFrequencyFromMultipleTexts(string[] text, string key, int expectedCount)
        {
            WordFrequencyCounter counter = new WordFrequencyCounter(new string[] { "" });
            var result = counter.Count(text);
            if (expectedCount != 0)
            {
                Assert.AreEqual(expectedCount, result.FrequencyCounter[key.ToUpper()]);
            }
            else
            {
                Assert.ThrowsException<KeyNotFoundException>(() =>
                _ = result.FrequencyCounter[key.ToUpper()]);
            }
        }
    }
}

