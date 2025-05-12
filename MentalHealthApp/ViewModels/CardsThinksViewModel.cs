
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MentalHealthApp.Models;
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
        private ObservableCollection<PosThCardsModel> thCards = new()
        {
            new () {NegThink = "Все плохо обо мне думают", PosThink = "Я хороший", NameOfCategory = "Работа"},
            new () {NegThink = "Все плохо обо мне думают", PosThink = "Я хороший",NameOfCategory = "Работа"},
            new () {NegThink = "Все плохо обо мне думают", PosThink = "Я хороший",NameOfCategory = "Работа"},
            new () {NegThink = "Все плохо обо мне думают", PosThink = "Я хороший",NameOfCategory = "Работа"},
            new () {NegThink = "Все плохо обо мне думают", PosThink = "Я хороший",NameOfCategory = "Работа"},
        };

    }
}
