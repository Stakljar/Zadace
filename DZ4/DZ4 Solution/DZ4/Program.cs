using System;
using System.Collections.Generic;
using Class_Library;

namespace DZ4
{
    class Program
    {
        static void Main(string[] args)
        {   /*Umjesto pokazivača i dinamički alociranog polja u klasi koja predstavlja sezonu potrebno je rabiti List<Episode>. 
            Omogućite iteriranje po sezoni korištenjem foreach petlje. Omogućite dodavanje novih epizoda na kraj sezone te uklanjanje epizoda iz sezone po imenu.
                U slučaju da kod brisanja ne postoji niti jedna epizoda s navedenim imenom, baciti kao iznimku objekt vlastite klase izvedene iz klase Exception. 
                Za sezonu definirajte odgovarajući konstruktor kopije tako da obavlja duboko kopiranje. 
                Implementirajte sve potrebne klase i njihove metode kako bi se testni program u nastavku mogao ispravno izvesti.*/

            // Assume that the number of rows in the text file is always at least 10. 
            // Assume a valid input file.
            string fileName = "shows.tv";

            IPrinter printer = new ConsolePrinter();
            printer.Print($"Reading data from file {fileName}");

            List<Episode> episodes = TvUtilities.LoadEpisodesFromFile(fileName);
            Season season = new Season(1, episodes);

            printer.Print(season.ToString());
            foreach (var episode in season)
            {
                episode.AddView(TvUtilities.GenerateRandomScore());
            }
            printer.Print(season.ToString());

            Season copy = new Season(season);
            copy[0].AddView(1.0);
            if (copy[0].GetAverageScore() == season[0].GetAverageScore())
            {
                printer.Print("This is not the correct copy implementation!");
            }

            try
            {
                season.Remove("Pilot");
                season.Remove("Nope");
            }
            catch (TvException e)
            {
                printer.Print($"{e.Message}, Name: {e.Title}");
            }
            printer.Print(season.ToString());
        }
    }
}
