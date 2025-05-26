
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentalHealthApp.ViewModels
{
    public partial class FeelingViewModel : ObservableObject
    {

        [ObservableProperty]
        List<string> fullDescriptionList = new() { "" };

        [ObservableProperty]
        List<int> marksList = new() { 0 };

        [ObservableProperty]
        List<string> descriptionsList = new() { "" };

        [ObservableProperty]
        int emojiStatus = 0;
        [ObservableProperty]
        string emojiDescription;
        [ObservableProperty]
        string description;

        public FeelingViewModel()
        {
            LoadEmojies();
        }

        [RelayCommand]
        async void LoadEmojies()
        {
            var feelings = await App.Database.GetListOfFeelings();
            foreach (var item in feelings)
            {
                MarksList.Add(item.FeelingMark);
                DescriptionsList.Add(item.FeelingName);
                FullDescriptionList.Add(item.FeelingMark.ToString() + "." + " " + item.FeelingName);
            }
        }

        [RelayCommand]
        async void WriteFeelingTODB()
        {

            System.Globalization.CultureInfo.CurrentCulture.ClearCachedData();
            DateTime dateTimeNow = new DateTime();
            dateTimeNow = DateTime.UtcNow + TimeZoneInfo.Local.BaseUtcOffset;

            

            string currentDate = dateTimeNow.ToString("dd/MM/yyyy");

            string currentTime = dateTimeNow.ToString("HH:mm");

            var feelingToCalendar = await App.Database.WriteFeelingsToDB(currentDate, currentTime, EmojiStatus,Description);

            EmojiStatus = 0;
            Description = "";
            EmojiDescription = "";

        }
    }
}
