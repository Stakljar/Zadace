using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using InternetResources;

namespace DZ5
{
    public partial class MainWindow : Window
    {
        Show show = new Show();
        Season currentSeason;
        int checker = 0;

        public MainWindow()
        {
            InitializeComponent();
            Seasons.Visibility = Visibility.Collapsed;
            Episodes.Visibility = Visibility.Collapsed;
            Back.Visibility = Visibility.Collapsed;
            ShowInfo.Visibility = Visibility.Visible;
            SeasonsList.Visibility = Visibility.Collapsed;
            EpisodesList.Visibility = Visibility.Collapsed;

        }

        private void SearchTitle_Click(object sender, RoutedEventArgs e)
        {
            ShowImage.Visibility = Visibility.Visible;
            SeasonsList.Visibility = Visibility.Collapsed;
            EpisodesList.Visibility = Visibility.Collapsed;
            ShowInfo.Visibility = Visibility.Visible;
            Seasons.Visibility = Visibility.Visible;
            Episodes.Visibility = Visibility.Collapsed;
            Back.Visibility = Visibility.Collapsed;
            show = InternetServices.ReadFromApi(ShowInput.Text);
            List<string> showAsList = new List<string> { show.ToString() };
            currentSeason = null;
            ShowInfo.ItemsSource = showAsList;
            try
            {
                ShowImage.Source = new BitmapImage(new Uri(show.image.Medium, UriKind.Absolute));
                //potrebno isključiti kvačicu za exception da breaka program ako se dogodi iznimka
            }
            catch (NullReferenceException exception)
            {
                ShowImage.Source = new BitmapImage(new Uri("https://i.postimg.cc/R0Fs4V3x/EeH5lW.jpg", UriKind.Absolute));
                //vrane su zanimljive
            }
            ShowInfo.Items.Refresh();
            EpisodesList.Items.Refresh();
            SeasonsList.Items.Refresh();
        }
        private void Seasons_Click(object sender, RoutedEventArgs e)
        {
            SeasonsList.Visibility = Visibility.Visible;
            EpisodesList.Visibility = Visibility.Collapsed;
            ShowImage.Visibility = Visibility.Collapsed;
            ShowInfo.Visibility = Visibility.Collapsed;
            Seasons.Visibility = Visibility.Collapsed;
            Episodes.Visibility = Visibility.Visible;
            Back.Visibility = Visibility.Visible;
            SeasonsList.ItemsSource = show.Seasons;
            checker = 1;
        }
        private void SeasonList_SelectionChanged(object sender, RoutedEventArgs e)
        {
            currentSeason = SeasonsList.SelectedItem as Season;
        }
        private void Episodes_Click(object sender, RoutedEventArgs e)
        {
            EpisodesList.Visibility = Visibility.Visible;
            ShowInfo.Visibility = Visibility.Collapsed;
            SeasonsList.Visibility = Visibility.Collapsed;
            Episodes.Visibility = Visibility.Collapsed;
            if(currentSeason!=null)
                EpisodesList.ItemsSource = currentSeason.Episodes;
            else
            {
                List<string> replacement = new List<string>() { "No seasons selected." };
                EpisodesList.ItemsSource = replacement;
            }
            checker = 0;
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (checker == 0)
            {
                Episodes.Visibility = Visibility.Visible;
                EpisodesList.Visibility = Visibility.Collapsed;
                ShowInfo.Visibility = Visibility.Collapsed;
                SeasonsList.Visibility = Visibility.Visible;
                checker = 1;
            }
            else
            {
                Episodes.Visibility = Visibility.Collapsed;
                ShowInfo.Visibility = Visibility.Visible;
                Seasons.Visibility = Visibility.Visible;
                Back.Visibility = Visibility.Collapsed;
                EpisodesList.Visibility = Visibility.Collapsed;
                ShowInfo.Visibility = Visibility.Visible;
                SeasonsList.Visibility = Visibility.Collapsed;
                ShowImage.Visibility = Visibility.Visible;

            }
        }
    }
}
