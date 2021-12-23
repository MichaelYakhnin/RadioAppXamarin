using MusicApp.ViewModel;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using static MusicApp.Model.Lib;

namespace MusicApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ToolbarItemIsrael_Clicked(object sender, EventArgs e)
        {
            var viewModel = (MainViewModel)BindingContext;
            viewModel.MusicList = viewModel.GetIsraelMusics();
            viewModel.StationType = StationType.Israel;
            viewModel.FavoritesList = viewModel.GetFavorites(StationType.Israel);
        }

        private void ToolbarItemMoscow_Clicked(object sender, EventArgs e)
        {
            var viewModel = (MainViewModel)BindingContext;
            viewModel.MusicList = viewModel.GetMoscowMusics();
            viewModel.StationType = StationType.Russian;
            viewModel.FavoritesList = viewModel.GetFavorites(StationType.Russian);
        }
    }
}
