using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplittingTheBill.Libraries.Contract
{
	public class ContextProcessor
	{
		public IProcessorTrip Context { set; get; }

		public ContextProcessor(IProcessorTrip _context)
		{
			Context = _context;
		}

		public void ProcessTripFile()
		{
			Context.ProcessTripFile();
		}

		public void CreateQueueTrip()
		{
			Context.CreateQueueTrip();
		}

		public void ProcessQueueTrips()
		{
			Context.ProcessQueueTrips();
		}

		public void PrintTrip()
		{
			Context.PrintTrip();
		}

		public string GetOutputPathFile()
		{
			return Context.GetOutputPathFile();
		}

		public Queue<string> GetLines()
		{
			return Context.GetLines();
		}
	}
}
