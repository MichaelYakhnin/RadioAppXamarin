using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace MusicApp.Logic
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string FavoritesKey = "favorites_key";
        private static readonly string SettingsDefault = string.Empty;

        #endregion


        public static string FavoriteSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(FavoritesKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(FavoritesKey, value);
            }
        }

    }
}

