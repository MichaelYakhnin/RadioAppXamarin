using MusicApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MusicApp.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
    public class FavoritesEventArgs : EventArgs
    {
        public Music SelectedMusic { get; set; }
        public FavoritesEventArgs(Music music)
        {
            SelectedMusic = music;
        }
    }
}
