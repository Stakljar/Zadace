using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace InternetResources
{
    public static class InternetServices
    {
        public static Show ReadFromApi(string showTitle)
        {
            string netService = string.Empty;
            Show show;
            try
            {
                netService = new WebClient().DownloadString("http://api.tvmaze.com/singlesearch/shows?q=" + showTitle);
                show = JsonConvert.DeserializeObject<Show>(netService);
            }
            catch (WebException e)
            {
                show = new Show();
                show.Name = "Unknown";
                show.Language = "Non existent";
                show.Genres = new List<string> { "N/A" };
                show.Summary = "No description available.";
            }
            if(show.Summary == null)
            {
                show.Summary = "No description accessible.";
            }
            for (int i = 0; i < show.Summary.Length - 3; i++)
            {

                if (show.Summary[i] == '<' && show.Summary[i + 1] == '/')
                {
                    show.Summary = show.Summary.Remove(i, 4);
                    if(i != 0) i--;
                }
                if (show.Summary[i] == '<' && show.Summary[i + 2] == '>')
                {
                    show.Summary = show.Summary.Remove(i, 3);
                    if(i != 0) i--;
                }
            }
            try
            {
                netService = new WebClient().DownloadString("http://api.tvmaze.com/shows/" + $"{show.Id}" + "/seasons");
                show.Seasons = JsonConvert.DeserializeObject<List<Season>>(netService);

            }
            catch (WebException e)
            {
                show.Seasons = new List<Season> { new Season() };
                show.Seasons[0].Number = 0;
            }
            catch (JsonSerializationException e)
            {
                show.Seasons = new List<Season> { new Season() };
                show.Seasons[0].Number = 0;



            }
            List<Episode> wholeShowEpisodes = new List<Episode>();
            try
            {
                netService = new WebClient().DownloadString("http://api.tvmaze.com/shows/" + $"{show.Id}" + "/episodes");
                wholeShowEpisodes = JsonConvert.DeserializeObject<List<Episode>>(netService);
            }
            catch (WebException e)
            {
                wholeShowEpisodes.Add(new Episode());
                wholeShowEpisodes[0].Summary = "No preview available.";

            }
            for (int i = 0; i < wholeShowEpisodes.Count; i++)
            {
                if (wholeShowEpisodes[i].Summary == null)
                {
                    wholeShowEpisodes[i].Summary = "No preview accessible.";
                }
                for (int j = 0; j < wholeShowEpisodes[i].Summary.Length - 3; j++)
                {

                    if (wholeShowEpisodes[i].Summary[j] == '<' && wholeShowEpisodes[i].Summary[j + 1] == '/')
                    {
                        wholeShowEpisodes[i].Summary = wholeShowEpisodes[i].Summary.Remove(j, 4);
                        if(j != 0) j--;

                    }
                    if (wholeShowEpisodes[i].Summary[j] == '<' && wholeShowEpisodes[i].Summary[j + 2] == '>')
                    {
                        wholeShowEpisodes[i].Summary = wholeShowEpisodes[i].Summary.Remove(j, 3);
                        if(j != 0) j--;

                    }
                }
            }

            foreach (var season in show.Seasons)
            {
                List<Episode> seasonEpisodes = new List<Episode>();
                foreach (var episode in wholeShowEpisodes)
                {
                    if (season.Number == episode.Season)
                    {
                        seasonEpisodes.Add(episode);
                    }
                }
                season.Episodes = seasonEpisodes;
            }
            return show;
        }
    }
}
