using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
    [QueryProperty("FavouriteImage", "favourite")]
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
        // 2 как заглушка, чтобы OnFavouriteItemChanged всегда работало (в другом случае при значении 0 не работает)
        [ObservableProperty]
        int favouriteImage = 2;
        [ObservableProperty]
        string favouriteText;

        partial void OnFavouriteImageChanged(int value)
        {
            FavouriteText = (value == 1) ? "Удалить из избранного" : "Добавить в избранное";
        }

        public async void AddReadingToDB()
        {
            string text = Convert.ToDateTime(SelectedDate).ToString("dd/MM/yyyy");
            var today = await App.Database.GetCurrentDay(text.Split('/'));
            ForReadingModel readingModel = await App.Database.Connection.Table<ForReadingModel>().Where(x => x.ReadingName == STName).FirstAsync();
            today.Readings.Add(readingModel);
            await App.Database.Connection.UpdateWithChildrenAsync(today);
        }

        [RelayCommand]
        public async void ReadingFavouriteStatusUpdate()
        {
            ForReadingModel reading = await App.Database.Connection.Table<ForReadingModel>().Where(x => x.ReadingName == STName).FirstAsync();
            ForReadingModel readingModel = await App.Database.Connection.GetWithChildrenAsync<ForReadingModel>(reading.InformationID);
            readingModel.isFavourite = (readingModel.isFavourite == 0) ? 1 : 0;
            FavouriteImage = (FavouriteImage == 0) ? 1 : 0;
            FavouriteText = (FavouriteImage == 1) ? "Удалить из избранного" : "Добавить в избранное";
            await App.Database.Connection.UpdateWithChildrenAsync(readingModel);
        }
    }
}
