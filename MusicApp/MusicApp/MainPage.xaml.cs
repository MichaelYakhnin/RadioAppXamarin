using MusicApp.ViewModel;
using System;
using System.ComponentModel;
using Xamarin.Forms;

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
        }

        private void ToolbarItemMoscow_Clicked(object sender, EventArgs e)
        {
            var viewModel = (MainViewModel)BindingContext;
            viewModel.MusicList = viewModel.GetMoscowMusics();
        }
    }
}
