using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using MentalHealthApp.Models;
using CommunityToolkit.Mvvm.Input;

namespace MentalHealthApp.ViewModels
{
    public partial class ForReadingViewModel : ObservableObject
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
        private ObservableCollection<ForReadingModel> work = new()
        {
            new () {SubTopicName = "Отношения с начальником", TimeForReading = 15} ,
                new () {SubTopicName = "Отношения с коллегами", TimeForReading = 10 },
                new() {SubTopicName = "Новый рабочий день", TimeForReading = 15},
                new () {SubTopicName = "Производительность", TimeForReading = 15}
        };
        [ObservableProperty]
        private ObservableCollection<ForReadingModel> study = new()
        {
            new () {SubTopicName = "Отношения с учителем", TimeForReading = 15},
                new () {SubTopicName = "Отношения с одноклассниками", TimeForReading = 15},
                new() {SubTopicName = "Первый учебный день", TimeForReading = 10 },
                new () {SubTopicName = "Успеваемость", TimeForReading = 15}
        };
        [ObservableProperty]
        private ObservableCollection<ForReadingModel> health = new()
        {
            new () {SubTopicName = "Тревожное состояние", TimeForReading = 15 },
                new () {SubTopicName = "Личная гигиена", TimeForReading = 15},
                new() {SubTopicName = "Здоровый образ жизни", TimeForReading = 15 },
                new () {SubTopicName = "Мысли о старости", TimeForReading = 15}
        };
        [ObservableProperty]
        private ObservableCollection<ForReadingModel> life = new()
        {
            new () {SubTopicName = "Отношения с семьей", TimeForReading = 15} ,
                new () {SubTopicName = "Личные обязанности", TimeForReading = 15},
                new() {SubTopicName = "Домашние животные", TimeForReading = 15 },
                new () {SubTopicName = "Внимание ребенку", TimeForReading = 15 }
        };

        [RelayCommand]
        private void GetSubTopicName(object parametr)
        {
            var param = parametr as object[];
            var subTpc = param[0];
            var tPc = param[1];
            var mntsCount = param[2];
            Shell.Current.GoToAsync($"ForReadingSelected", new Dictionary<string, object>
            {
                ["topicName"] = tPc,
                ["subTopicName"] = subTpc,
                ["minutes"] = mntsCount
            });
        }
    }
}
