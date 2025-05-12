

using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace MentalHealthApp.ViewModels
{
    public partial class FavouritesViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Models.FavouriteModel> favs =
            [
            new () {NameOfFav = "Медитации"},
            new () {NameOfFav = "Дыхательные техники"},
            new () {NameOfFav = "Советы и цитаты"},
            new () {NameOfFav = "Полезная информация"},
            new () {NameOfFav = "Позитивное мышление"},
            ];
    }
}
