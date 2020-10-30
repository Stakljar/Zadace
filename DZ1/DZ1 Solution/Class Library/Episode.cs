using System;

namespace Class_Library
{
    public class Episode
    {
        private int viewers;
        private double totalScore;
        private double maxScore;
        public Episode()
        {

        }
        public Episode(int viewers, double totalScore, double maxScore)
        {
            this.viewers = viewers;
            this.totalScore = totalScore;
            this.maxScore = maxScore;
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

    }
}
