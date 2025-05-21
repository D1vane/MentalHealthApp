using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentalHealthApp.ViewModels
{
    [QueryProperty("TName", "topicName")]
    [QueryProperty("STName", "subTopicName")]
    [QueryProperty("Minutes", "minutes")]
    [QueryProperty("ImagePath", "imagePath")]
    [QueryProperty("Themes", "themes")]
    [QueryProperty("Content", "content")]
    public partial class ForReadingSelectedViewModel : ObservableObject
    {
        [ObservableProperty]
        string tName;

        [ObservableProperty]
        string sTName;

        [ObservableProperty]
        string minutes;
        [ObservableProperty]
        string imagePath;

        [ObservableProperty]
        string themes;

        [ObservableProperty]
        string content;
    }
}
