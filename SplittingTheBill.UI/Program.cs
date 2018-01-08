using SplittingTheBill.Libraries.Concret;
using SplittingTheBill.Libraries.Contract;
using System;
using System.IO;

namespace SplittingTheBill.UI
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Console.Write("Please, inform the input File: ");
				var pathFile = Console.ReadLine();

				if (File.Exists(pathFile))
				{
					ContextProcessor proc = new ContextProcessor(new TripsProcessor(pathFile));
					proc.ProcessTripFile();
					Console.WriteLine("Processed!! Press ENTER to close.");
				}
				else
				{
					Console.WriteLine("File do not exists");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("It was not possible to process the file, check the content. {0}", ex.Message);
			}
			Console.ReadLine();
		}
	}
}
