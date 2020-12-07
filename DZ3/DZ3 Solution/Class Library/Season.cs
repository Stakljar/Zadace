using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Library
{
    public class Season
    {
        Episode[] episodes;
        int season;
        public Season() : this(0, null)
        {

        }
        public Season(int season, Episode[] episodes)
        {
            this.episodes = episodes;
            this.season = season;
        }
        public int Length
        {
            get
            {
                return episodes.Length;
            }
        }
        public Episode this[int wordIndex]
        {
            get
            {
                return episodes[wordIndex];
            }
            set
            {
                episodes[wordIndex] = value;
            }                
        }
        public override string ToString()
        {   int totalViewers = 0;
            TimeSpan totalDuration = new TimeSpan(0, 0, 0);
            string currentLine;
            string[] currentLines;
            TimeSpan duration;
            string output = $"Season {season}:\n";
            output += "=================================================\n";
           
            foreach(Episode episode in episodes)
            {
                currentLine = episode.ToString();
                currentLines = currentLine.Split(',');
                duration = TimeSpan.Parse(currentLines[4]);
                totalDuration += duration;
                output += $"{episode.ToString()}\n";
                totalViewers += episode.GetViewerCount();
            }
            output += "Report:\n";
            output += "=================================================\n";
            output += $"Total viewers: {totalViewers}\n";
            output += $"Total duration: {totalDuration}\n";
            return output;
        }
        

    }
}
