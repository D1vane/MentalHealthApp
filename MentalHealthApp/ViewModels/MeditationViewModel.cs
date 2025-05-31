using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MentalHealthApp.Models;
using SQLiteNetExtensionsAsync.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentalHealthApp.ViewModels
{
    [QueryProperty("FavouriteImage", "favourite")]
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
        [ObservableProperty]
        string minDate = DateTime.Now.ToString("MM/dd/yyyy");
        [ObservableProperty]
        string selectedDate = DateTime.Now.ToString("MM/dd/yyyy");
        [ObservableProperty]
        int favouriteImage = 2;
        [ObservableProperty]
        string favouriteText;
        partial void OnFavouriteImageChanged(int value)
        {
            FavouriteText = (value == 1) ? "Удалить из избранного" : "Добавить в избранное";
        }

        public async void AddMeditationToDB()
        {
            string text = Convert.ToDateTime(SelectedDate).ToString("dd/MM/yyyy");
            var today = await App.Database.GetCurrentDay(text.Split('/'));
            MeditationModel meditationModel = await App.Database.Connection.Table<MeditationModel>().Where(x=>x.MeditationName==MName).FirstAsync();
            today.Meditations.Add(meditationModel);
            await App.Database.Connection.UpdateWithChildrenAsync(today);
        }
        [RelayCommand]
        public async void MeditationFavouriteStatusUpdate()
        {
            MeditationModel meditationModel = await App.Database.Connection.Table<MeditationModel>().Where(x=>x.MeditationName==MName).FirstAsync();
            meditationModel.IsFavourite = (meditationModel.IsFavourite == 0) ? 1 : 0;
            FavouriteImage = (FavouriteImage == 0) ? 1 : 0;
            FavouriteText = (FavouriteImage == 1) ? "Удалить из избранного" : "Добавить в избранное";
            await App.Database.Connection.UpdateWithChildrenAsync(meditationModel);
        }
    }
}
