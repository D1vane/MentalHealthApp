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
    public partial class SleepViewModel : ObservableObject
    {

        [ObservableProperty]
        string arrowImage = "doublearrowdown_icon.png";
        [ObservableProperty]
        string todayOrAnotherDaySleep;

        [ObservableProperty]
        bool factorsVisibility = false;

        [ObservableProperty]
        bool allVisibility = true;

        [ObservableProperty]
        bool alreadyMarkedVisibility = false;

        [ObservableProperty]
        string alreadyMarkedText = "";

        [ObservableProperty]
        string[] sleepTime = new string[2];

        [ObservableProperty]
        int currentDay;

        [ObservableProperty]
        string monthAndYear;

        [ObservableProperty]
        string fullDate = DateTime.Today.ToString("dd/MM/yyyy");

        [ObservableProperty]
        ObservableCollection<SleepFactorsModel> factorsBeforeSleep;

        [ObservableProperty]
        ObservableCollection<SleepFactorsModel> sleepFactors;

        [ObservableProperty]
        string sleepDescription = "";
        [ObservableProperty]
        string factorsDescription = "Факторы, влияющие на сон не указаны";
        [ObservableProperty]
        bool markedFactorsVisibility = false;

        List<SleepFactorsModel> factsBfrSlp = new List<SleepFactorsModel>();

        List<SleepFactorsModel> sleepFctrs = new List<SleepFactorsModel>();

        public SleepViewModel()
        {
            IsAlreadyMarked();
        }

        partial void OnCurrentDayChanged(int value)
        {
            if (value < 10)
                FullDate = "0" + value.ToString() + "/" + MonthAndYear;
            else
                FullDate = value.ToString() + "/" + MonthAndYear;

            IsAlreadyMarked();
        }

        async void IsAlreadyMarked()
        {
            var today = await App.Database.GetCurrentDay(FullDate.Split('/'));
            if (today != null)
            {
                var currentDate = await App.Database.Connection.GetWithChildrenAsync<CalendarModel>(today.DayID);
                if (currentDate.Sleep != null)
                {
                    var currentSleep = await App.Database.Connection.GetWithChildrenAsync<SleepModel>(currentDate.Sleep.SleepID);
                    AllVisibility = false;
                    FactorsVisibility = false;
                    AlreadyMarkedVisibility = true;
                    if (FullDate == DateTime.Today.ToString("dd/MM/yyyy"))
                    {
                        AlreadyMarkedText = "Вы сегодня уже отметили свой сон,\nвозвращайтесь завтра!";
                        TodayOrAnotherDaySleep = "Сегодня вы спали:";
                    }
                        
                    else
                    {
                        AlreadyMarkedText = "";
                        TodayOrAnotherDaySleep = $"{FullDate} вы спали:";
                    }
                        
                    SleepTime = currentSleep.SleepDuration.Split(':');
                    if (currentSleep.Factors != null)
                    {
                        MarkedFactorsVisibility = false;
                        SleepFactors = currentSleep.Factors.ToObservableCollection();
                    }

                    else
                        MarkedFactorsVisibility = true;
                    SleepDescription = currentSleep.SleepDescription;
                    if (SleepDescription == "")
                        SleepDescription = "Описание отсутствует";
                }
                else
                    GetListOfFactors();
            }
            
        }

        async void GetListOfFactors()
        {
            var fctrs = await App.Database.GetListOfFactors();

            foreach (var item in fctrs)
            {
                if (item.IsBeforeSleep == 0)
                    sleepFctrs.Add(item);

                else
                    factsBfrSlp.Add(item);
            }
        }
        [RelayCommand]
        void OpenDescription()
        {
            if (ArrowImage == "doublearrowdown_icon.png")
            {
                FactorsVisibility = true;
                ArrowImage = "doublearrowup_icon.png";
                FactorsBeforeSleep = factsBfrSlp.ToObservableCollection();
                SleepFactors = sleepFctrs.ToObservableCollection();
            }
            else
            {
                FactorsVisibility = false;
                ArrowImage = "doublearrowdown_icon.png";
                FactorsBeforeSleep.Clear();
                SleepFactors.Clear();
            }

        }


        public async void WriteSleepToDB(string hours, string minutes, List<SleepFactorsModel> selectedFactorsBeforeSleep,
            List<SleepFactorsModel> selectedSleepFactors)
        {
            SleepModel mySleep = new SleepModel();
            mySleep.SleepDuration = new TimeOnly(Convert.ToInt32(hours), Convert.ToInt32(minutes)).ToString("HH:mm");
            if (selectedFactorsBeforeSleep != null)
                mySleep.Factors = selectedFactorsBeforeSleep;
            if (selectedSleepFactors != null)
                if (mySleep.Factors != null)
                    mySleep.Factors.AddRange(selectedSleepFactors);
                else
                {
                    mySleep.Factors = selectedSleepFactors;
                }
            mySleep.SleepDescription = SleepDescription;
            var date = await App.Database.WriteSleepToDB(mySleep);
            IsAlreadyMarked();
        }
    }
}
