using SplittingTheBill.Libraries.Tools;
using NUnit.Framework;

namespace SplittingTheBill.Test
{
    public class CheckFileFormatTests
    {
		[TestCase(@"C:\Test\expenses.txt", true)]
		[TestCase(@"C:\Test\expensesError.txt", false)]
		[TestCase(@"C:\Test\expenses2.txt", true)]
		public void CheckFile_AsOnlyNumericValues(string stringPath, bool expectedResult)
		{
			bool result = FileTools.FileAsOnlyNumericValues(stringPath);
			Assert.AreEqual(expectedResult, result);
		}
	}
}
