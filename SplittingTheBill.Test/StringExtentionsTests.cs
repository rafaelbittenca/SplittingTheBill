using System;
using NUnit.Framework;

namespace SplittingTheBill.Test
{
	public class StringExtentionsTests
	{
		[TestCase("123", true)]
		[TestCase("@123/", false)]
		[TestCase("15.00", true)]
		[TestCase("6.75", true)]
		[TestCase("9,20", true)]
		[TestCase("Abc123", false)]
		public void CheckString_IsNumeric(string input, bool expectedResult)
		{
			var result = input.IsNumeric();
			Assert.AreEqual(expectedResult, result);
		}
	}
}
