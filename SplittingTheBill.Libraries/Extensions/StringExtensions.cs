using System.Text.RegularExpressions;

namespace System
{
    public static class StringExtensions
    {
		/// <summary>
		/// Check if a string is a numeric value
		/// </summary>
		/// <param name="Value">Input string</param>
		/// <returns></returns>
		public static Boolean IsNumeric(this String Value)
		{
			return Regex.IsMatch(Value, @"^-?\d*[0-9]?(|.\d*[0-9]|,\d*[0-9])?$");
		}
	}
}
