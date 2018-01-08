using SplittingTheBill.Libraries.Tools;
using SplittingTheBill.Libraries.Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplittingTheBill.Libraries.Concret
{
	#region Explanation 2 Scenario 
	/// 
	/// <summary>
	/// 
	/// *** Example of different layout implementation - Just to show the sollution adopted ***
	/// 
	/// Let's imagine that the layout changed and the 2nd layout now has:
	/// 1 Line: Total people per trip
	/// 2 Line: Person Name
	/// 3 Line: Total grouped spent by this participant
	/// 
	/// Input:
	/// 3
	/// John
	/// 32.20
	/// Mark
	/// 23.10
	/// Rafael
	/// 26.90
	/// 2
	/// Mark
	/// 15.00
	/// John
	/// 12.35
	/// 
	/// Expected output : 
	/// John - ($4,80)
	/// Mark - $4,30
	/// Rafael - $0,50
	/// Mark - ($1,32)
	/// John - $1,32
	/// 
	/// You just need to implement the same interface/contract
	/// And in runtime choose the layout to use
	/// 
	/// </summary>
	/// 
	#endregion

	public class TripsProcessorGrouped : IProcessorTrip
	{
		private string pathFile;
		private string newPathFile;
		private Queue<string> lines;
		private Dictionary<string, decimal> chargesPerPerson;
		
		public TripsProcessorGrouped(string pathFile)
		{
			this.pathFile = pathFile;
			lines = new Queue<string>();
			chargesPerPerson = new Dictionary<string, decimal>();
			newPathFile = string.Format("{0}{1}", this.pathFile, ".out");
		}

		public void ProcessTripFile()
		{
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
			string name = "";
			int people = 0;
			decimal totalCharges = 0;
			string currentLine = "";

			if (lines.Count > 0)
			{
				people = int.Parse(lines.Dequeue());
				while (people > 0)
				{
					if (name == "")
					{
						name = lines.Dequeue();
					}
					else
					{
						currentLine = lines.Dequeue();
						totalCharges += decimal.Parse(currentLine.Replace(".", ","));
				
						//add total to the list
						chargesPerPerson.Add(name, totalCharges);
						totalCharges = 0;
						name = "";
						people -= 1;
					}
				}

				//print/process trip list
				PrintTrip();

				//clear to process the next trip
				chargesPerPerson.Clear();

				//call process again until any more trips
				ProcessQueueTrips();
			}
		}

		public void PrintTrip()
		{
			using (StreamWriter writer = new StreamWriter(newPathFile, true))
			{
				var average = chargesPerPerson.Average(c => c.Value);
				var newList = chargesPerPerson.ToDictionary(c => c.Key, c=> average - c.Value);
				foreach (var e in newList)
					writer.WriteLine(e.Value < 0 ? "{0} - (${1})" : "{0} - ${1}", e.Key, Math.Round(e.Value, 2).ToString().Replace("-", ""));
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
