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
        double progressBarTop = 0.0;
        [ObservableProperty]
        double progressBarBot = 0.0;
        [ObservableProperty]
        double progressBarRight = 0.0;
        [ObservableProperty]
        double progressBarLeft = 0.0;
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
            Thread.Sleep(500);
            TimerCallback tm = new TimerCallback(CountBack);
            MainThread.BeginInvokeOnMainThread(() =>
            {
                var time = new System.Threading.Timer(tm, Seconds, TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(1));
            });
        }
        async void CountBack(object obj)
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
                    if (countSeconds <= 4)
                        ProgressBarTop += 0.25;
                    else if (countSeconds > 4 && countSeconds <=8)
                        ProgressBarRight += 0.25;
                    else if (countSeconds > 8 && countSeconds <= 12)
                        ProgressBarBot += 0.25;
                    else if (countSeconds > 12 && countSeconds <= 17)
                    {
                        ProgressBarLeft += 0.25;
                        if (countSeconds == 16)
                        {
                            LoopCount--;
                            
                        }
                        else if (countSeconds == 17)
                        {
                            countSeconds = 1;
                            ProgressBarTop = 0.25;
                            ProgressBarBot = ProgressBarLeft = ProgressBarRight = 0;
                        }
                    }
                }
                else
                {
                    MainThread.InvokeOnMainThreadAsync(() =>
                    {
                    });
                    Minutes--;
                    Seconds = 59;
                    countSeconds++;
                    if (countSeconds <= 4)
                        ProgressBarTop += 0.25;
                    else if (countSeconds > 4 && countSeconds <= 8)
                        ProgressBarRight += 0.25;
                    else if (countSeconds > 8 && countSeconds <= 12)
                        ProgressBarBot += 0.25;
                    else if (countSeconds > 12 && countSeconds <= 17)
                    {
                        ProgressBarLeft += 0.25;
                        if (countSeconds == 16)
                        {
                            LoopCount--;

                        }
                        else if (countSeconds == 17)
                        {
                            countSeconds = 1;
                            ProgressBarTop = 0.25;
                            ProgressBarBot = ProgressBarLeft = ProgressBarRight = 0;
                        }
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
