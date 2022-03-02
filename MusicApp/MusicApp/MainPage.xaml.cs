using MusicApp.Interfaces;
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
        private void ToolbarItemKiev_Clicked(object sender, EventArgs e)
        {
            var viewModel = (MainViewModel)BindingContext;
            viewModel.MusicList = viewModel.GetKievMusics();
            viewModel.StationType = StationType.Ukraine;
            viewModel.FavoritesList = viewModel.GetFavorites(StationType.Ukraine);
        }
        protected override bool OnBackButtonPressed()
        {
            if (Application.Current.MainPage.Navigation.NavigationStack.Count == 1)//navigation is MainPage.Navigation
                DependencyService.Get<IAndroidMethods>().CloseApp();
            return base.OnBackButtonPressed();
        }

    }
}
