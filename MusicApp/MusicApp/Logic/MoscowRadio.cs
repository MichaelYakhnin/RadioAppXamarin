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
        public static async Task<ObservableCollection<Radio>> GetStationsListAsync()
        {
            var list = new ObservableCollection<Radio>();
            using (var stream = await FileSystem.OpenAppPackageFileAsync("msk.json"))
            {
                using (var reader = new StreamReader(stream))
                {
                    try
                    {
                        var fileContents = reader.ReadToEnd();
                        var stationsList = JsonConvert.DeserializeObject<ObservableCollection<Radio>>(fileContents);
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
