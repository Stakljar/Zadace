using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetResources
{
    public class Episode
    {
        private string name;
        private int number;
        private string summary;
        private int season;
        public string Name { get => name; set => name = value; }
        public int Number { get => number; set => number = value; }
        public int Season { get => season; set => season = value; }
        public string Summary { get => summary; set => summary = value; }

        public override string ToString()
        {
            int i;
            string overview = $"Episode {Number}. {Name}\n\n";
            if (summary == null || summary == "")
                summary = "No preview accessible.";
            for (i = 0; i < Summary.Length - 1 ; i++)
            {
                overview += Summary[i];
                if (i % 75 == 0 && i != 0)
                {
                    if (summary[i] != ' ' && summary[i + 1] != ' ' && summary[i] != '.' && summary[i + 1 ] != '.' && summary[i] != ',' && summary[i + 1] != ',' && summary[i] != '?' && summary[i + 1] != '?')
                        overview += "-";
                    overview += "\n";
                }
            }
            overview += Summary[i];
            overview += "\n";
            return overview;
        }

    }
}
