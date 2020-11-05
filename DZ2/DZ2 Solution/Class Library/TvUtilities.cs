using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Library
{
    public static class TvUtilities
    {
        static int count = 10;
        public static double GenerateRandomScore()
        {
            Random random = new Random();
            double randomNumber = (random.Next(100000, 1000000)) / 100000.0;
            return randomNumber;
        }
        public static Episode Parse(string line)
        {
            string[] lines = line.Split(',');
            int viewers = int.Parse(lines[0]);
            double totalScore = double.Parse(lines[1]);
            double maxScore = double.Parse(lines[2]);
            int number = int.Parse(lines[3]);
            TimeSpan duration = TimeSpan.Parse(lines[4]);
            string name = lines[5];
            return new Episode(viewers, totalScore, maxScore, new Description(number, duration, name));
        }

        public static void Sort(Episode[] episodes)
        {
            int sorted = 1;
            Episode support = null;
            while (sorted != 0)
            {
                sorted = 0;
                for (int i = 0; i < episodes.Length - 1; i++)
                {
                    if (episodes[i] < episodes[i + 1])
                    {
                        sorted = 1;
                        support = episodes[i];
                        episodes[i] = episodes[i + 1];
                        episodes[i + 1] = support;
                    }

                }

            }
        }
    }
}
