﻿using MusicApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MusicApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerPage : ContentPage
    {
        public PlayerPage()
        {
            InitializeComponent();            
        }

        public void PlayerPage_AddToFavorite(object sender, FavoritesEventArgs e)
        {
            DisplayAlert("Alert","Added to favorites","Ok");
        }
    }
}