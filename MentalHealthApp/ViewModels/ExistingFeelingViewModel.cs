using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MentalHealthApp.Models;
using SQLiteNetExtensionsAsync.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentalHealthApp.ViewModels
{
    [QueryProperty("MonthAndYear", "givenMonthAndYear")]
    [QueryProperty("CurrentDay", "givenDay")]
    public partial class ExistingFeelingViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<FeelingAllInfo> existingFeelings = new();

        [ObservableProperty]
        int currentDay;

        [ObservableProperty]
        string monthAndYear;
        [ObservableProperty]
        string fullDate;

        partial void OnCurrentDayChanged(int value)
        {
            string fullDate = "";
            if (value < 10)
                fullDate = "0" + value.ToString() + "/" + MonthAndYear;
            else
                fullDate = value.ToString() + "/" + MonthAndYear;
            LoadFeelings(fullDate);
        }

        [RelayCommand]
        async void LoadFeelings(string fullDate)
        {
            var date = await App.Database.GetCurrentDay(fullDate.Split('/'));
                var feelings = await App.Database.Connection.Table<FeelingToCalendar>().Where(x => x.DayID == date.DayID).ToListAsync();
            for (int i = 0; i < feelings.Count; i++)
            {
                    FeelingToCalendar tempInfo = feelings[i];
                    var tempModel = await App.Database.Connection.Table<FeelingModel>().Where(x=>x.FeelingID == tempInfo.FeelingID).FirstOrDefaultAsync();
                    ExistingFeelings.Add(new FeelingAllInfo { Feeling = tempModel, FeelingInfo = tempInfo });
            }

            FullDate = fullDate;
        }
    }
}
