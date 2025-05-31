using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MentalHealthApp.Models;
using Microsoft.Maui.Controls.Shapes;
using SQLiteNetExtensionsAsync.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentalHealthApp.ViewModels
{
    [QueryProperty("FromFavourite", "IsFavourite")]
    [QueryProperty("MonthAndYear", "givenMonthAndYear")]
    [QueryProperty("CurrentDay", "givenDay")]
    public partial class BreatheListViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<BreatheModel> breathes;

        [ObservableProperty]
        string minDate = DateTime.Now.ToString("MM/dd/yyyy");
        [ObservableProperty]
        string selectedDate = DateTime.Now.ToString("MM/dd/yyyy");

        [ObservableProperty]
        int breatheID;

        [ObservableProperty]
        int fromFavourite;

        [ObservableProperty]
        int currentDay;
        [ObservableProperty]
        string monthAndYear;
        [ObservableProperty]
        string fullDate;
        public BreatheListViewModel()
        {
            LoadBreathes();
        }
        partial void OnFromFavouriteChanged(int value)
        {
            LoadBreathes();
        }
        partial void OnCurrentDayChanged(int value)
        {
            if (value < 10)
                FullDate = "0" + value.ToString() + "/" + MonthAndYear;
            else
                FullDate = value.ToString() + "/" + MonthAndYear;
            LoadBreathes();
        }
        [RelayCommand]
        private async void LoadBreathes()
        {
            if (FromFavourite == 0)
            {
                if (CurrentDay == 0)
                {
                    var breathesTemp = await App.Database.GetListOfBreathes();
                    if (breathesTemp.Any())
                    {
                        Breathes = new ObservableCollection<BreatheModel>(breathesTemp);
                    }
                }
                else
                {
                    var curDay = await App.Database.GetCurrentDay(FullDate.Split('/'));
                    if (curDay.Breathes.Count > 0)
                    {
                        Breathes = new ObservableCollection<BreatheModel>(curDay.Breathes);
                    }
                }
                
            }
            else
            {
                var breathesTemp = await App.Database.Connection.Table<BreatheModel>().Where(x => x.IsFavourite == FromFavourite).ToListAsync();
                if (breathesTemp.Any())
                {
                    Breathes = new ObservableCollection<BreatheModel>(breathesTemp);
                }
            }
            
        }

        [RelayCommand]
        void GetBreatheID(object id)
        {
            BreatheID = (int)id;

        }

        [RelayCommand]
        void GetFavouriteStatus(object id)
        {
            BreatheID = (int)id;
            BreatheFavouriteStatusUpdate();
        }
        [RelayCommand]
        void GoToBreathe(object parameter)
        {
            var param = parameter as object[];

            var nameOfBreathe = param[0];
            var loopDuration = param[1];
            var guideText = param[2];
            var favourite = param[3];

            Shell.Current.GoToAsync($"Breathe", new Dictionary<string, object>
            {
                ["breatheName"] = nameOfBreathe,
                ["loopDuration"] = loopDuration,
                ["minutes"] = new TimeSpan(0, 0, (int)loopDuration).Multiply(10).Minutes,
                ["seconds"] = new TimeSpan(0, 0, (int)loopDuration).Multiply(10).Seconds,
                ["guide"] = guideText,
                ["favourite"] = favourite
            });
        }

        public async void AddBreatheToDB()
        {
            string text = Convert.ToDateTime(SelectedDate).ToString("dd/MM/yyyy");
            var today = await App.Database.GetCurrentDay(text.Split('/'));
            BreatheModel breatheModel = Breathes.Where(x => x.BreatheID == BreatheID).First();
            today.Breathes.Add(breatheModel);
            await App.Database.Connection.UpdateWithChildrenAsync(today);
        }

        public async void BreatheFavouriteStatusUpdate()
        {
            BreatheModel breatheModel = Breathes.Where(x => x.BreatheID == BreatheID).First();
            int index = Breathes.IndexOf(breatheModel);
            breatheModel.IsFavourite = (breatheModel.IsFavourite == 0) ? 1 : 0;
            Breathes[index] = breatheModel;
            await App.Database.Connection.UpdateWithChildrenAsync(breatheModel);

        }
    }
}
