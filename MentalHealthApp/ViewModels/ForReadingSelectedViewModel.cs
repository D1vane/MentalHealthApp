using CommunityToolkit.Mvvm.ComponentModel;
using MentalHealthApp.Models;
using SQLiteNetExtensionsAsync.Extensions;
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

        [ObservableProperty]
        string minDate = DateTime.Now.ToString("MM/dd/yyyy");
        [ObservableProperty]
        string selectedDate = DateTime.Now.ToString("MM/dd/yyyy");

        public async void AddReadingToDB()
        {
            string text = Convert.ToDateTime(SelectedDate).ToString("dd/MM/yyyy");
            var today = await App.Database.GetCurrentDay(text.Split('/'));
            ForReadingModel readingModel = await App.Database.Connection.Table<ForReadingModel>().Where(x => x.ReadingName == STName).FirstAsync();
            today.Readings.Add(readingModel);
            await App.Database.Connection.UpdateWithChildrenAsync(today);
        }
    }
}
