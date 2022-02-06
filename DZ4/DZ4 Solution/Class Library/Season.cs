using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Class_Library
{
    public class Season : IEnumerable<Episode>
    {
        List<Episode> episodes;
        int season;

        public Season() 
        {
            season = 0;
            episodes = new List<Episode>();
        }
        
        public Season(int season, List<Episode> list)
        {
            episodes = new List<Episode>();
            episodes.AddRange(list);
            this.season = season;
        }
        
        public Season(Season other)
        {
            episodes = new List<Episode>();
            foreach (var item in other)
            {
                string[] lines = item.ToString().Split(',');
                int viewers = int.Parse(lines[0]);
                double totalScore = double.Parse(lines[1]);
                double maxScore = double.Parse(lines[2]);
                int lineUpNumber = int.Parse(lines[3]);
                TimeSpan duration = TimeSpan.Parse(lines[4]);
                string name = lines[5];
                episodes.Add(new Episode(viewers, totalScore, maxScore, new Description(lineUpNumber, duration, name)));
            }
            season = other.season;
        }
        
        IEnumerator<Episode> IEnumerable<Episode>.GetEnumerator()
        {
            return ((IEnumerable<Episode>)episodes).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)episodes).GetEnumerator();
        }

        public void Add(Episode episode)
        {
            episodes.Add(episode);
        }
        
        public void Remove(string name)
        {
            int checker = 0;
            for (int i = 0; i < episodes.Count; i++)
                if (episodes[i].ToString().Contains(name))
                {
                    checker = 1;
                    episodes.Remove(episodes[i]);
                    i--;
                }
            if (checker == 0)
                throw new TvException("No such episode found.", name);
                    
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
        {
            int totalViewers = 0;
            TimeSpan totalDuration = new TimeSpan(0, 0, 0);
            string currentLine;
            string[] currentLines;
            TimeSpan duration;
            string output = $"Season {season}:\n";
            output += "=================================================\n";

            foreach (Episode episode in episodes)
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
            output += "=================================================\n";
            return output;
        }
    }
}
