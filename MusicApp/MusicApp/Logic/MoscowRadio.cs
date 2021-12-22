using MusicApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MusicApp.Logic
{
    public static class MoscowRadio
    {
        public static async Task<ObservableCollection<Music>> GetStationsListAsync()
        {
            var list = new ObservableCollection<Music>();
            using (var stream = await FileSystem.OpenAppPackageFileAsync("msk.json"))
            {
                using (var reader = new StreamReader(stream))
                {
                    try
                    {
                        var fileContents = reader.ReadToEnd();
                        var stationsList = JsonConvert.DeserializeObject<ObservableCollection<Music>>(fileContents);
                        return stationsList;
                    }
                    catch(Exception ex)
                    {
                        var errpr = ex.Message;
                        return null;
                    }
                    
                }
            }
        }
    }
}
