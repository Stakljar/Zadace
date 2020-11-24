using System;

namespace Class_Library
{
    public class Episode
    {
        private int viewers;
        private double totalScore;
        private double maxScore;
        Description description;
        public Episode() : this(0, 0, 0, new Description())
        {

        }
        public Episode(int viewers, double totalScore, double maxScore, Description description)
        {
            this.viewers = viewers;
            this.totalScore = totalScore;
            this.maxScore = maxScore;
            this.description = description;
        }
        public void AddView(double random)
        {
            viewers++;
            totalScore += random;
            if (maxScore < random) maxScore = random;

        }
        public double GetMaxScore()
        {
            return maxScore;
        }
        public double GetAverageScore()
        {
            return totalScore / viewers;
        }
        public int GetViewerCount()
        {
            return viewers;
        }
        public override string ToString()
        {
            return $"{viewers},{totalScore.ToString("F4")},{maxScore.ToString("F2")},{description}";
        }
        public static bool operator <(Episode a, Episode b)
        {
            if (a.GetAverageScore() > b.GetAverageScore())
                return false;
            else return true;
        }
        public static bool operator >(Episode a, Episode b)
        {
            if (a.GetAverageScore() > b.GetAverageScore())
                return true;
            else return false;
        }
    }
}
