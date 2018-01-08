using NUnit.Framework;
using SplittingTheBill.Libraries.Contract;
using SplittingTheBill.Libraries.Concret;

namespace SplittingTheBill.Test
{
	/// <summary>
	/// *** Test input layout 1 ***
	/// </summary>
	public class TripsProcessorTests
    {
		[TestCase(@"C:\Test\expenses.txt", 20)]
		[TestCase(@"C:\Test\expenses2.txt", 31)]
		public void Check_CreateTripQueue_ReturnCorretNumberLines_FromFile(string pathFile, int countLines)
		{
			ContextProcessor proc = new ContextProcessor(new TripsProcessor(pathFile));
			proc.CreateQueueTrip();
			Assert.AreEqual(countLines, proc.GetLines().Count);
		}

		[TestCase(@"C:\Test\expenses.txt", @"C:\Test\expensesExpected.test")]
		public void Check_FileTripProcessor_HasExpectedResult(string inputFile, string expectedFileResult)
		{
			ContextProcessor proc = new ContextProcessor(new TripsProcessor(inputFile));
			proc.ProcessTripFile();
			Libraries.Tools.FileAssert.AreEqual(expectedFileResult, proc.Context.GetOutputPathFile());
		}
	}
}
