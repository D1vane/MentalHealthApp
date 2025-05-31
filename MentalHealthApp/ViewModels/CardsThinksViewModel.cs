
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MentalHealthApp.Models;
using Microsoft.Maui.Controls.Shapes;
using SQLiteNetExtensionsAsync.Extensions;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MentalHealthApp.ViewModels
{
    [QueryProperty("STName", "subTopicName")]
    [QueryProperty("TName","topicName")]
    [QueryProperty("FromFavourite", "IsFavourite")]
    public partial class CardsThinksViewModel : ObservableObject
    {
        [ObservableProperty]
        private string sTName;
        [ObservableProperty]
        private string tName;

        [ObservableProperty]
        int fromFavourite;

        [ObservableProperty]
        private ObservableCollection<PosThModel> thCards;

        partial void OnSTNameChanged(string value)
        {
            if (FromFavourite == 0)
                LoadThinks();
        }
        partial void OnFromFavouriteChanged(int value)
        {
            LoadThinks();
        }

        [RelayCommand]
        private async void LoadThinks()
        {
            var cards = await App.Database.GetListOfThinks(STName);
            if (FromFavourite == 0)
            {
                
                ThCards = new ObservableCollection<PosThModel>(cards.Thinks);
            }
            else
            {
                ThCards = new ObservableCollection<PosThModel>(cards.Thinks.Where(x=>x.isFavourite == 1));
            }

        }

        [RelayCommand]
        public async void PosThinkFavouriteStatusUpdate(object id)
        {
            PosThModel thinkModel = await App.Database.Connection.GetWithChildrenAsync<PosThModel>((int)id);
            PosThModel think = ThCards.Where(x=>x.ThinkID==thinkModel.ThinkID).First();
            int index = ThCards.IndexOf(think);
            think.isFavourite = (think.isFavourite == 0) ? 1 : 0;
            ThCards[index] = think;
            await App.Database.Connection.UpdateWithChildrenAsync(think);
        }

    }
}
