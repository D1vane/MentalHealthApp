using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MentalHealthApp.Models;
using SQLiteNetExtensionsAsync.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentalHealthApp.ViewModels
{
    [QueryProperty("MName", "meditationName")]
    [QueryProperty("MTime", "meditationTime")]
    [QueryProperty("MLevel", "meditationLevel")]
    [QueryProperty("ImagePath", "imagePath")]
    [QueryProperty("Content", "content")]
    [QueryProperty("Guide", "guide")]
    public partial class MeditationViewModel : ObservableObject
    {
        [ObservableProperty]
        string mName;
        [ObservableProperty]
        int mTime;
        [ObservableProperty]
        int mLevel;
        [ObservableProperty]
        string imagePath;
        [ObservableProperty]
        string content;
        [ObservableProperty]
        string guide;
        [ObservableProperty]
        string minDate = DateTime.Now.ToString("MM/dd/yyyy");
        [ObservableProperty]
        string selectedDate = DateTime.Now.ToString("MM/dd/yyyy");

        public async void AddMeditationToDB()
        {
            string text = Convert.ToDateTime(SelectedDate).ToString("dd/MM/yyyy");
            var today = await App.Database.GetCurrentDay(text.Split('/'));
            MeditationModel meditationModel = await App.Database.Connection.Table<MeditationModel>().Where(x=>x.MeditationName==MName).FirstAsync();
            today.Meditations.Add(meditationModel);
            await App.Database.Connection.UpdateWithChildrenAsync(today);
        }
    }
}
