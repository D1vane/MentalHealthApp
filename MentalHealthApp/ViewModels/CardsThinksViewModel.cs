
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MentalHealthApp.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MentalHealthApp.ViewModels
{
    [QueryProperty("STName", "subTopicName")]
    public partial class CardsThinksViewModel : ObservableObject
    {
        [ObservableProperty]
        private string sTName;
        
        [ObservableProperty]
        private ObservableCollection<PosThCards> thCards = new()
        {
            new () {NegThink = "Все плохо обо мне думают", PosThink = "Я хороший", NameOfCategory = "Работа"},
            new () {NegThink = "Все плохо обо мне думают", PosThink = "Я хороший",NameOfCategory = "Работа"},
            new () {NegThink = "Все плохо обо мне думают", PosThink = "Я хороший",NameOfCategory = "Работа"},
            new () {NegThink = "Все плохо обо мне думают", PosThink = "Я хороший",NameOfCategory = "Работа"},
            new () {NegThink = "Все плохо обо мне думают", PosThink = "Я хороший",NameOfCategory = "Работа"},
        };

    }
}
