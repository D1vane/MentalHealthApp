using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentalHealthApp.ViewModels
{
    [QueryProperty("Minutes", "minutes")]
    [QueryProperty("Seconds", "seconds")]
    [QueryProperty("LoopCount", "loopCount")]
    [QueryProperty("CurrentLoop", "loopCount")]
    [QueryProperty("Name", "name")]
    public partial class StartedBreatheViewModel: ObservableObject
    {
        int countSeconds = 0;

        [ObservableProperty]
        int minutes;
        [ObservableProperty]
        int seconds;
        [ObservableProperty]
        int loopCount;
        [ObservableProperty]
        string name;
        [ObservableProperty]
        double progressBarLength = 0.0;
        [RelayCommand]
        void GoBack (object parameter)
        {
            var param = parameter as object[];
            var nameOfBreathe = param[0];
            Shell.Current.GoToAsync($"Breathe", new Dictionary<string, object>
            {
                ["breatheName"] = nameOfBreathe,
                ["duration"] = 16,
                ["minutes"] = new TimeSpan(0, 0, 16).Multiply(10).Minutes,
                ["seconds"] = new TimeSpan(0, 0, 16).Multiply(10).Seconds,
            });
        }

        public StartedBreatheViewModel()
        {
            //Thread.Sleep(500);
            //TimerCallback tm = new TimerCallback(CountBack);
            //MainThread.BeginInvokeOnMainThread(() =>
            //{
            //    var time = new System.Threading.Timer(tm, Seconds, TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(1));
            //});
        }
        void CountBack(object obj)
        {
            if (Minutes != 0 || Seconds != 0)
            {
                if (Seconds != 0)
                {
                    MainThread.InvokeOnMainThreadAsync(() =>
                    {
                    });
                    Seconds--;
                    countSeconds++;
                    if (countSeconds == 16)
                    {
                        LoopCount--;
                        countSeconds = 0;
                    }
                    //ProgressBarLength = (ProgressBarLength == 1) ? ProgressBarLength = 0 : ProgressBarLength += 0.25;
                }
                else
                {
                    MainThread.InvokeOnMainThreadAsync(() =>
                    {
                    });
                    Minutes--;
                    Seconds = 59;
                    countSeconds++;
                    if (countSeconds == 16)
                    {
                        LoopCount--;
                        countSeconds = 0;
                    }
                }
            }
            else
            {
                MainThread.InvokeOnMainThreadAsync(() =>
                {
                });
            }

        }
    }
}
