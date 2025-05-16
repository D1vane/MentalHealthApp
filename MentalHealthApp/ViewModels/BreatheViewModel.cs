using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
    }
}
