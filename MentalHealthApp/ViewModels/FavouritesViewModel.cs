

using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace MentalHealthApp.ViewModels
{
    public partial class FavouritesViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Models.FavouriteModel> favs =
            [
            //new () {NameOfFav = "Медитации", AllTasks = 2},
            //new () {NameOfFav = "Дыхательные техники", AllTasks = 0},
            //new () {NameOfFav = "Полезная информация", AllTasks = 3},
            //new () {NameOfFav = "Позитивное мышление", AllTasks = 4},
            ];
    }
}
