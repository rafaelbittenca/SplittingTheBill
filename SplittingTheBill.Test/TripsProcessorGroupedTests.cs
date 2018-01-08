using NUnit.Framework;
using SplittingTheBill.Libraries.Concret;
using SplittingTheBill.Libraries.Contract;

namespace SplittingTheBill.Test
{
	/// <summary>
	/// *** Test input layout 2 ***
	/// </summary>
	public class TripsProcessorGroupedTests
    {
		[TestCase(@"C:\Test\expensesGrouped.txt", 12)]
		public void Check_CreateTripQueue_ReturnCorretNumberLines_FromFileGrouped(string pathFile, int countLines)
		{
			ContextProcessor proc = new ContextProcessor(new TripsProcessorGrouped(pathFile));
			proc.CreateQueueTrip();
			Assert.AreEqual(countLines, proc.GetLines().Count);
		}

		[TestCase(@"C:\Test\expensesGrouped.txt", @"C:\Test\expensesGroupedExpected.test")]
		public void Check_FileTripGroupedProcessor_HasExpectedResult(string inputFile, string expectedFileResult)
		{
			ContextProcessor proc = new ContextProcessor(new TripsProcessorGrouped(inputFile));
			proc.ProcessTripFile();
			Libraries.Tools.FileAssert.AreEqual(expectedFileResult, proc.Context.GetOutputPathFile());
		}
	}
}
