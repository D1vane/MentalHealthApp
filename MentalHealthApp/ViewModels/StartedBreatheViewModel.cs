using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MentalHealthApp.Views;
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
    public partial class StartedBreatheViewModel : ObservableObject
    {
        int countSeconds = 0;
        IDispatcherTimer timer;
        [ObservableProperty]
        int minutes;
        [ObservableProperty]
        int seconds;
        [ObservableProperty]
        int loopCount;
        [ObservableProperty]
        string name;
        [RelayCommand]
        void GoBack(object parameter)
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
            timer.Stop();
        }

        public StartedBreatheViewModel()
        {
            CountBack();
        }
        async void CountBack()
        {
            

            timer = Application.Current.Dispatcher.CreateTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (s, e) =>
            {
                if (Minutes != 0 || Seconds != 0)
                {
                    if (Seconds != 0)
                    {
                        Seconds--;
                        countSeconds++;
                        if (countSeconds == 16)
                        {
                            LoopCount--;
                            countSeconds = 0;
                        }
                    }
                    else
                    {
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
                    timer.Stop();
                    
                }
            };
            timer.Start();

        }
    }
}
