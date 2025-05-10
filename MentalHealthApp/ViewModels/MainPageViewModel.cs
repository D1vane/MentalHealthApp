

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;


namespace MentalHealthApp.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Models.MainPage> relax = new()
        {
            new () {NameOfPage = "Медитации"},
            new () {NameOfPage = "Дыхательные техники"},
            new () {NameOfPage = "Видеозаписи"},
            new () {NameOfPage = "Аудиозаписи"},
        };
        [ObservableProperty]
        private ObservableCollection<Models.MainPage> usefulInfo = new()
        {
            new () {NameOfPage = "Для чтения"},
            new () {NameOfPage = "Позитивное мышление"},
        };
        [ObservableProperty]
        private ObservableCollection<Models.MainPage> selfControl = new()
        {
            new () {NameOfPage = "Оценка самочувствия"},
            new () {NameOfPage = "Оценка сна"},
            new () {NameOfPage = "Список задач"},
            new () {NameOfPage = "Подключить умные часы"},
        };
        [RelayCommand]
        private void GoToNextPage (object param)
        {
            // Получить по названию имя пути и перейти по нему (пока через if)
            if (param == "Позитивное мышление")
                Shell.Current.GoToAsync("PositiveThinking");
            else if (param == "Список задач")
                Shell.Current.GoToAsync("Planner");
        }
    }
}
