using System.Collections.Generic;
using System.Threading.Tasks;

namespace SplittingTheBill.Libraries.Contract
{
	/// <summary>
	/// With this interface we can have different implementations 
	/// for each type of layout of the input file
	/// 
	/// In execution time the client class will process according 
	/// to the selected layout
	/// </summary>
	/// 
	public interface IProcessorTrip
	{
		void ProcessTripFile();
		void CreateQueueTrip();
		void ProcessQueueTrips();
		void PrintTrip();
		string GetOutputPathFile();
		Queue<string> GetLines();
	}
}