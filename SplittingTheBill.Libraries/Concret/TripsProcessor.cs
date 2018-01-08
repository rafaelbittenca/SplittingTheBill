using SplittingTheBill.Libraries.Contract;
using SplittingTheBill.Libraries.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SplittingTheBill.Libraries.Concret
{
	/// <summary>
	/// *** Layout implementation - challenge scenario ***
	/// </summary>
	public class TripsProcessor : IProcessorTrip
    {
		private string pathFile;
		private string newPathFile;
		private Queue<string> lines; 
		private List<decimal> chargesPerPerson; 

		public TripsProcessor(string pathFile)
		{
			this.pathFile = pathFile;
			lines = new Queue<string>();
			chargesPerPerson = new List<decimal>();
			newPathFile = string.Format("{0}{1}", this.pathFile, ".out");
		}

		public void ProcessTripFile()
		{
			if (!FileTools.FileAsOnlyNumericValues(pathFile))
				throw new Exception("Incorrect format file.");
			FileTools.DeleteFileOutput(newPathFile);
			CreateQueueTrip();
			ProcessQueueTrips();
		}

		public void CreateQueueTrip()
		{
			string currentLine = null;
			using (Stream file = File.Open(pathFile, FileMode.Open))
			using (StreamReader reader = new StreamReader(file))
			{
				while ((currentLine = reader.ReadLine()) != null)
				{
					if (currentLine != "0")
						lines.Enqueue(currentLine);
				}
			}
		}

		public void ProcessQueueTrips()
		{
			int people = 0;
			int charges = 0;
			decimal totalCharges = 0;
			string currentLine = "";

			if (lines.Count > 0)
			{
				people = int.Parse(lines.Dequeue());
				while (people > 0)
				{
					charges = int.Parse(lines.Dequeue());
					while (charges > 0)
					{
						currentLine = lines.Dequeue();
						totalCharges += decimal.Parse(currentLine.Replace(".", ","));
						charges -= 1;
					}
					//add total to the list
					chargesPerPerson.Add(totalCharges);
					totalCharges = 0;
					people -= 1;
				}

				//print/process for each trip list
				PrintTrip();

				//clear to process the next trip
				chargesPerPerson.Clear();

				//call process again until no more trips
				ProcessQueueTrips();
			}
		}

		public void PrintTrip()
		{
			using (StreamWriter writer = new StreamWriter(newPathFile, true))
			{
				// Apply lambda to get the average of all items minus the value of each item in the list
				var newList = chargesPerPerson.Select(c => chargesPerPerson.Average() - c).ToList();

				// Write in the new file checking whether value is positive or negative
				foreach (var e in newList)
					writer.WriteLine(e < 0 ? "(${0})" : "${0}", Math.Round(e, 2).ToString().Replace("-", ""));
				writer.WriteLine("");
			}
		}

		public string GetOutputPathFile()
		{
			return newPathFile;
		}

		public Queue<string> GetLines()
		{
			return lines;
		}
	}
}
