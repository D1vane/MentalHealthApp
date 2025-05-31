using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MentalHealthApp.Models;
using SQLiteNetExtensionsAsync.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MentalHealthApp.ViewModels
{
    [QueryProperty("Name", "breatheName")]
    [QueryProperty("Duration", "loopDuration")]
    [QueryProperty("Minutes", "minutes")]
    [QueryProperty("Seconds", "seconds")]
    [QueryProperty("Guide", "guide")]
    [QueryProperty("FavouriteImage", "favourite")]
    public partial class BreatheViewModel: ObservableObject
    {

        public BreatheViewModel()
        {
            TimeSpan allDuration = new TimeSpan(0, 0, Duration);
            allDuration = allDuration.Multiply(LoopNumbers);
            Minutes = allDuration.Minutes;
            Seconds = allDuration.Seconds;
        }

        [ObservableProperty]
        string name;
        [ObservableProperty]
        int duration;

        [ObservableProperty]
        int loopNumbers = 10;

        [ObservableProperty]
        int minutes;
        [ObservableProperty]
        int seconds;
        [ObservableProperty]
        string guide;
        [ObservableProperty]
        string minDate = DateTime.Now.ToString("MM/dd/yyyy");
        [ObservableProperty]
        string selectedDate = DateTime.Now.ToString("MM/dd/yyyy");
        [ObservableProperty]
        int favouriteImage = 2;
        [ObservableProperty]
        string favouriteText;

        partial void OnFavouriteImageChanged(int value)
        {
            FavouriteText = (value == 1) ? "Удалить из избранного" : "Добавить в избранное";
        }

        [RelayCommand]
        public void LoopsToTime()
        {
            TimeSpan allDuration = new TimeSpan(0, 0, Duration);
            allDuration = allDuration.Multiply(LoopNumbers);
            Minutes = allDuration.Minutes;
            Seconds = allDuration.Seconds;
        }


        [RelayCommand]
        void StartBreathe(object parameter)
        {
            var param = parameter as object[];

            var minutes = param[0];
            var seconds = param[1];
            var loopNumber = param[2];
            var name = param[3];

            Shell.Current.GoToAsync($"StartedBreathe", new Dictionary<string, object>
            {
                ["minutes"] = minutes,
                ["seconds"] = seconds,
                ["loopCount"] = loopNumber,
                ["name"] = name
            });
        }

        public async void AddBreatheToDB()
        {
            string text = Convert.ToDateTime(SelectedDate).ToString("dd/MM/yyyy");
            var today = await App.Database.GetCurrentDay(text.Split('/'));
            BreatheModel breatheModel = await App.Database.Connection.Table<BreatheModel>().Where(x=>x.NameOfBreathe==Name).FirstAsync();
            today.Breathes.Add(breatheModel);
            await App.Database.Connection.UpdateWithChildrenAsync(today);
        }

        [RelayCommand]
        public async void BreatheFavouriteStatusUpdate()
        {
            BreatheModel breatheModel = await App.Database.Connection.Table<BreatheModel>().Where(x => x.NameOfBreathe == Name).FirstAsync();
            breatheModel.IsFavourite = (breatheModel.IsFavourite == 0) ? 1 : 0;
            FavouriteImage = (FavouriteImage == 0) ? 1 : 0;
            FavouriteText = (FavouriteImage == 1) ? "Удалить из избранного" : "Добавить в избранное";
            await App.Database.Connection.UpdateWithChildrenAsync(breatheModel);
        }
    }
}
