

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;


namespace MentalHealthApp.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Models.MainPageModel> relax =
        [
            new () {NameOfPage = "Медитации"},
            new () {NameOfPage = "Дыхательные техники"},
        ];
        [ObservableProperty]
        private ObservableCollection<Models.MainPageModel> usefulInfo =
        [
            new () {NameOfPage = "Для чтения"},
            new () {NameOfPage = "Позитивное мышление"},
        ];
        [ObservableProperty]
        private ObservableCollection<Models.MainPageModel> selfControl =
        [
            new () {NameOfPage = "Оценка самочувствия"},
            new () {NameOfPage = "Оценка сна"},
            new () {NameOfPage = "Список задач"},
            new () {NameOfPage = "Подключить умные часы"},
        ];
        [RelayCommand]
        private void GoToNextPage (object param)
        {
            // Получить по названию имя пути и перейти по нему (пока через if)
            if (param.ToString() == "Позитивное мышление")
                Shell.Current.GoToAsync("PositiveThinking");
            else if (param.ToString() == "Список задач")
                Shell.Current.GoToAsync("Planner");
            else if (param.ToString() == "Для чтения")
                Shell.Current.GoToAsync("ForReading");
        }
    }
}
