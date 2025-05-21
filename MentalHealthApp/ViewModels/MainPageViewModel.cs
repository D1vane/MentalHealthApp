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
            new () {NameOfPage = "Медитации", ImagePath = "meditations_mainpage.jpg"},
            new () {NameOfPage = "Дыхательные техники", ImagePath = "breathes_mainpage.jpg"},
        ];
        [ObservableProperty]
        private ObservableCollection<Models.MainPageModel> usefulInfo =
        [
            new () {NameOfPage = "Для чтения", ImagePath = "reading_mainpage.jpg"},
            new () {NameOfPage = "Позитивное мышление", ImagePath = "thinking_mainpage.jpg"},
        ];
        [ObservableProperty]
        private ObservableCollection<Models.MainPageModel> selfControl =
        [
            new () {NameOfPage = "Оценка самочувствия", ImagePath = "feeling_mainpage.jpg"},
            new () {NameOfPage = "Оценка сна", ImagePath = "sleep_mainpage.jpg"},
            new () {NameOfPage = "Список задач", ImagePath = "planner_mainpage.jpg"},
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
            else if (param.ToString() == "Медитации")
                Shell.Current.GoToAsync("MeditationList");
            else if (param.ToString() == "Дыхательные техники")
                Shell.Current.GoToAsync("BreatheList");
            else if (param.ToString() == "Оценка самочувствия")
                Shell.Current.GoToAsync("Feeling");
            else if (param.ToString() == "Оценка сна")
                Shell.Current.GoToAsync("Sleep");

        }
    }
}
