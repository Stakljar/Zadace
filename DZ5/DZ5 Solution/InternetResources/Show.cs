using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetResources
{
    public class Show
    {
        private string name;
        private int id;
        private string language;
        private List<string> genres;
        public List<Season> seasons;
        public string summary;
        public Image image;
        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
        public string Language { get => language; set => language = value; }
        public List<string> Genres { get => genres; set => genres = value; }
        public List<Season> Seasons { get => seasons; set => seasons = value; }
        public string Summary { get => summary; set => summary = value; }
        public string Image { get => image.Original; set => image.Original = value; }

        public override string ToString()
        {
            string spacing = ", ";
            string  overview = $"\n\n\n\n\n\n\n\n\n\n\nName: {Name}\nLanguage: {Language}\nGenre: {string.Join(spacing, Genres)}\n\nDescription:\n";
            if (summary == null || summary == "")
                summary = "No description accessible.";
            for (int i = 0; i < Summary.Length; i++)
            {     
                overview += Summary[i];
                if (i % 75 == 0 && i!=0)
                {
                    if (summary[i] != ' ' && summary[i + 1] != ' ')
                        overview += "-";
                      overview += "\n";
                }
            }
            return overview;
        }       

    }
}
