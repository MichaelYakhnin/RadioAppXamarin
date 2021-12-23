using MusicApp.Logic;
using MusicApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using static MusicApp.Model.Lib;

namespace MusicApp.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public StationType StationType { get; set; }
        public MainViewModel()
        {
            musicList = GetIsraelMusics();
            favoritesList = GetFavorites(StationType.Israel);
            recentMusic = musicList.FirstOrDefault();
            StationType = StationType.Israel;
        }

        ObservableCollection<Radio> musicList;
        public ObservableCollection<Radio> MusicList
        {
            get { return musicList; }
            set
            {
                musicList = value;
                OnPropertyChanged();
            }
        }

        ObservableCollection<Radio> favoritesList = new ObservableCollection<Radio>();
        public ObservableCollection<Radio> FavoritesList
        {
            get { return favoritesList; }
            set
            {
                favoritesList = value;
                OnPropertyChanged();
            }
        }

        private Radio recentMusic;
        public Radio RecentMusic
        {
            get { return recentMusic; }
            set
            {
                recentMusic = value;
                OnPropertyChanged();
            }
        }

        private Radio selectedMusic;
        public Radio SelectedMusic
        {
            get { return selectedMusic; }
            set
            {
                selectedMusic = value;
                OnPropertyChanged();
            }
        }
        private Radio selectedFavorite;
        public Radio SelectedFavorite
        {
            get { return selectedFavorite; }
            set
            {
                selectedFavorite = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectionCommand => new Command(PlayMusic);
        
        private void PlayMusic(object obj)
        {
            if((string)obj == "Favorite" && selectedFavorite != null)
            {
                RecentMusic = selectedFavorite;
                
                var viewModel = new PlayerViewModel(selectedFavorite, favoritesList);
                var playerPage = new PlayerPage { BindingContext = viewModel };
                
                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PopAsync();
                navigation.PushAsync(playerPage, true);
            }
            if ((string)obj == "Regular" && selectedMusic != null)
            {
                RecentMusic = selectedMusic;
                
                var viewModel = new PlayerViewModel(selectedMusic, musicList) ;
                var playerPage = new PlayerPage { BindingContext = viewModel };
                viewModel.AddToFavorite += OnAddToFavorite;
                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PopAsync();
                navigation.PushAsync(playerPage, true);
            }
        }

        private void OnAddToFavorite(object sender, FavoritesEventArgs e)
        {
            switch (StationType)
            {
                case StationType.Israel:
                    FavoritesList.Add(e.SelectedStation);
                    var list = string.Join(",", FavoritesList.Select(x => x.Name));
                    Settings.IsrFavoriteSettings = list;
                    break;
                case StationType.Russian:
                    FavoritesList.Add(e.SelectedStation);
                    var listRu = string.Join(",", FavoritesList.Select(x => x.Name));
                    Settings.RuFavoriteSettings = listRu;
                    break;
                default:
                    break;
            }
        }

        public ObservableCollection<Radio> GetFavorites(StationType stationType)
        {
            switch (StationType)
            {
                case StationType.Israel:
                    var list = MusicList.Where(x => Settings.IsrFavoriteSettings.Split(',').Any(y => y == x.Name)).ToList();
                    return new ObservableCollection<Radio>(list);
                case StationType.Russian:
                    var listRu = MusicList.Where(x => Settings.RuFavoriteSettings.Split(',').Any(y => y == x.Name));
                    return new ObservableCollection<Radio>(listRu);
                default:
                    break;
            }
            return null;
        }

        public ObservableCollection<Radio> GetMoscowMusics()
        {
            return MoscowRadio.GetStationsListAsync().Result;
        }
        public ObservableCollection<Radio> GetIsraelMusics()
        {
            return IsraelRadio.GetStationsListAsync().Result;
        }
    }
}