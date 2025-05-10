
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
        private ObservableCollection<Categories> cats = new()
        {
            new() {NameOfCategory = "Работа"},
            new() {NameOfCategory = "Учеба"},
            new() {NameOfCategory = "Здоровье"},
            new() {NameOfCategory = "Быт"}

        };

        [ObservableProperty]
        private ObservableCollection<SubTopic> work = new()
        {
            new () {SubTopicName = "Отношения с начальником" } ,
                new () {SubTopicName = "Отношения с коллегами" },
                new() {SubTopicName = "Новый рабочий день"},
                new () {SubTopicName = "Производительность"}
        };
        [ObservableProperty]
        private ObservableCollection<SubTopic> study = new()
        {
            new () {SubTopicName = "Отношения с учителем"},
                new () {SubTopicName = "Отношения с одноклассниками"},
                new() {SubTopicName = "Первый учебный день" },
                new () {SubTopicName = "Успеваемость"}
        };
        [ObservableProperty]
        private ObservableCollection<SubTopic> health = new()
        {
            new () {SubTopicName = "Тревожное состояние" },
                new () {SubTopicName = "Личная гигиена"},
                new() {SubTopicName = "Здоровый образ жизни" },
                new () {SubTopicName = "Мысли о старости"}
        };
        [ObservableProperty]
        private ObservableCollection<SubTopic> life = new()
        {
            new () {SubTopicName = "Отношения с семьей"} ,
                new () {SubTopicName = "Личные обязанности"},
                new() {SubTopicName = "Домашние животные" },
                new () {SubTopicName = "Внимание ребенку" }
        };
        [ObservableProperty]
        private ObservableCollection<PosThCards> thCards = new()
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
