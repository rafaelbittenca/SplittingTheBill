using System;
using System.IO;
using System.Threading.Tasks;

namespace SplittingTheBill.Libraries.Tools
{
    public class FileTools
    {
		/// <summary>
		/// Reads all file and check if the lines have only numeric values
		/// </summary>
		/// <param name="path">File path</param>
		/// <returns></returns>
		public static bool FileAsOnlyNumericValues(string path)
		{
			bool isCorrect = true;
			string line = "";
			
			using (Stream file = File.Open(path, FileMode.Open))
			using (StreamReader reader = new StreamReader(file))
			{
				while (isCorrect && line != "0")
				{
					line = reader.ReadLine();
					if (!line.IsNumeric())
						isCorrect = false;
				}
			}
			return isCorrect;
		}

		/// <summary>
		/// Delete file from specific path, check if you have permission on directory
		/// </summary>
		/// <param name="pathFile"></param>
		public static void DeleteFileOutput(string pathFile)
		{
			try
			{
				if (File.Exists(pathFile))
					File.Delete(pathFile);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error while trying to delete file. {0}", ex.Message);
			}
		}
	}
}
