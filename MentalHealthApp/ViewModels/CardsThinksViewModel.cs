
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MentalHealthApp.Models;
using Microsoft.Maui.Controls.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MentalHealthApp.ViewModels
{
    [QueryProperty("STName", "subTopicName")]
    [QueryProperty("TName","topicName")]
    public partial class CardsThinksViewModel : ObservableObject
    {
        [ObservableProperty]
        private string sTName;
        [ObservableProperty]
        private string tName;

        [ObservableProperty]
        private ObservableCollection<PosThModel> thCards;

        public CardsThinksViewModel()
        {
            LoadThinks();
        }

        [RelayCommand]
        private async void LoadThinks()
        {
            var cards = await App.Database.GetListOfThinks(STName);
            if (cards.Any())
            {
                ThCards = new ObservableCollection<PosThModel>(cards);
            }
            else
            {
                var cardsNew = await App.Database.GetListOfThinks(STName);
                ThCards = new ObservableCollection<PosThModel>(cardsNew);
            }
        }

    }
}
