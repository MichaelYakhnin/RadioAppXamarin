using MusicApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MusicApp.Logic
{
    public static class IsraelRadio
    {
        public static async Task<ObservableCollection<Music>> GetStationsListAsync()
        {
            var list = new ObservableCollection<Music>();
            using (var stream = await FileSystem.OpenAppPackageFileAsync("isr.json"))
            {
                using (var reader = new StreamReader(stream))
                {
                    try
                    {
                        var fileContents = reader.ReadToEnd();
                        var stationsList = JsonConvert.DeserializeObject<ObservableCollection<Music>>(fileContents);
                        return stationsList;
                    }
                    catch (Exception ex)
                    {
                        var errpr = ex.Message;
                        return null;
                    }

                }
            }
        }
    }
}
