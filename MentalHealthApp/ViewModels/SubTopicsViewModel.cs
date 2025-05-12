
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MentalHealthApp.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MentalHealthApp.ViewModels
{
    public partial class SubTopicsViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<CategoryModel> cats = new()
        {
            new() {NameOfCategory = "Работа"},
            new() {NameOfCategory = "Учеба"},
            new() {NameOfCategory = "Здоровье"},
            new() {NameOfCategory = "Быт"}

        };

        [ObservableProperty]
        private ObservableCollection<PosThModel> work = new()
        {
            new () {SubTopicName = "Отношения с начальником" } ,
                new () {SubTopicName = "Отношения с коллегами" },
                new() {SubTopicName = "Новый рабочий день"},
                new () {SubTopicName = "Производительность"}
        };
        [ObservableProperty]
        private ObservableCollection<PosThModel> study = new()
        {
            new () {SubTopicName = "Отношения с учителем"},
                new () {SubTopicName = "Отношения с одноклассниками"},
                new() {SubTopicName = "Первый учебный день" },
                new () {SubTopicName = "Успеваемость"}
        };
        [ObservableProperty]
        private ObservableCollection<PosThModel> health = new()
        {
            new () {SubTopicName = "Тревожное состояние" },
                new () {SubTopicName = "Личная гигиена"},
                new() {SubTopicName = "Здоровый образ жизни" },
                new () {SubTopicName = "Мысли о старости"}
        };
        [ObservableProperty]
        private ObservableCollection<PosThModel> life = new()
        {
            new () {SubTopicName = "Отношения с семьей"} ,
                new () {SubTopicName = "Личные обязанности"},
                new() {SubTopicName = "Домашние животные" },
                new () {SubTopicName = "Внимание ребенку" }
        };
        [ObservableProperty]
        private ObservableCollection<PosThCardsModel> thCards = new()
        {
            new () {NegThink = "Все плохо обо мне думают", PosThink = "Я хороший", NameOfCategory = "Работа"},
            new () {NegThink = "Все плохо обо мне думают", PosThink = "Я хороший",NameOfCategory = "Работа"},
            new () {NegThink = "Все плохо обо мне думают", PosThink = "Я хороший",NameOfCategory = "Работа"},
            new () {NegThink = "Все плохо обо мне думают", PosThink = "Я хороший",NameOfCategory = "Работа"},
            new () {NegThink = "Все плохо обо мне думают", PosThink = "Я хороший",NameOfCategory = "Работа"},
        };
        [RelayCommand]
        private void GetSubTopicName(object parametr)
        {
            var param = parametr as object[];
            var subTpc = param[0];
            var tPc = param[1];
            Shell.Current.GoToAsync($"PositiveThinkingCards", new Dictionary<string, object>
            {["topicName"] = tPc,
                ["subTopicName"] = subTpc});
        }
    }
}
