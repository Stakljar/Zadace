using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Class_Library
{
    public static class TvUtilities
    {
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
            int lineUpNumber = int.Parse(lines[3]);
            TimeSpan duration = TimeSpan.Parse(lines[4]);
            string name = lines[5];
            return new Episode(viewers, totalScore, maxScore, new Description(lineUpNumber, duration, name));
        }

        public static void Sort(Episode[] episodes)
        {

            Episode temp = null;
            for (int i = 1; i < episodes.Length; i++)
            {
                temp = episodes[i];
                int j = i - 1;
                while (j >= 0 && episodes[j].GetAverageScore() < temp.GetAverageScore())
                {
                    episodes[j + 1] = episodes[j];
                    j = j - 1;
                }
                episodes[j + 1] = temp;

            }
        }
        public static Episode[] LoadEpisodesFromFile(string fileName)
        {
            string[] episodesInputs = File.ReadAllLines(fileName);
            Episode[] episodes = new Episode[episodesInputs.Length];
            for(int i = 0; i < episodesInputs.Length; i++)
            {
                string[] currentLines = episodesInputs[i].Split(',');
                int viewers = int.Parse(currentLines[0]);
                double totalScore = double.Parse(currentLines[1]);
                double maxScore = double.Parse(currentLines[2]);
                int lineUpNumber = int.Parse(currentLines[3]);
                TimeSpan duration = TimeSpan.FromMinutes(int.Parse(currentLines[4]));
                string name = currentLines[5];
                episodes[i] = new Episode(viewers, totalScore, maxScore, new Description(lineUpNumber, duration, name));
            }
            return episodes;
        }
    }
}
