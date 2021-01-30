using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetResources
{
    public class Season
    {
        private int number;
        private int id;
        private List<Episode> episodes;

        public int Number { get => number; set => number = value; }
        public int Id { get => id; set => id = value; }
        public List<Episode> Episodes { get => episodes; set => episodes = value; }

        public override string ToString()
        {
            return $"Season {Number}. ";
        }
    }
}
