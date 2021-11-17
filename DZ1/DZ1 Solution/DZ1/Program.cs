using System;
using System.Collections.Generic;
using System.Text;
using Class_Library;

namespace Dz1
{
	public class Program
	{
		static double GenerateRandomScore()
		{
			Random random = new Random();
			double randomNumber = (random.Next(100000, 1000000)) / 100000.0;
			return randomNumber;
		}

		public static void Main(String[] args)
		{
			Episode ep1, ep2;
			ep1 = new Episode();
			ep2 = new Episode(10, 64.39, 8.7);
			int viewers = 10;
			for (int i = 0; i < viewers; i++)
			{
				ep1.AddView(GenerateRandomScore());
				Console.WriteLine(ep1.GetMaxScore());
			}
			if (ep1.GetAverageScore() > ep2.GetAverageScore())
			{
				Console.WriteLine($"Viewers: {ep1.GetViewerCount()}");
			}
			else
			{
				Console.WriteLine($"Viewers: {ep2.GetViewerCount()}");
			}
		}
	}
}
