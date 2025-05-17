using CommunityToolkit.Mvvm.ComponentModel;
using System;
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
    }
}
