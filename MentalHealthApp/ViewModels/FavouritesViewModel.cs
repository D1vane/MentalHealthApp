

using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using MentalHealthApp.Models;
using SQLiteNetExtensionsAsync.Extensions;
using CommunityToolkit.Mvvm.Input;
namespace MentalHealthApp.ViewModels
{
    public partial class FavouritesViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<FavouriteModel> favs = new();

        [ObservableProperty]
        private List<MeditationModel> meditations = new();

        [ObservableProperty]
        private List<BreatheModel> breathes = new();

        [ObservableProperty]
        private List<ForReadingModel> readings = new();

        [ObservableProperty]
        private List<PosThModel> thinks = new();
        public FavouritesViewModel()
        {
            GetFavourites();
        }

        async void GetFavourites()
        {
            Meditations = await App.Database.Connection.Table<MeditationModel>().Where(x => x.IsFavourite == 1).ToListAsync();
            Breathes = await App.Database.Connection.Table<BreatheModel>().Where(x => x.IsFavourite == 1).ToListAsync();
            Readings = await App.Database.Connection.Table<ForReadingModel>().Where(x => x.isFavourite == 1).ToListAsync();
            Thinks = await App.Database.Connection.Table<PosThModel>().Where(x => x.isFavourite == 1).ToListAsync();

            for (int i = 0; i < Thinks.Count; i++)
            {
                Thinks[i] = await App.Database.Connection.GetWithChildrenAsync<PosThModel>(Thinks[i].ThinkID);
            }
            for (int i = 0; i < Readings.Count; i++)
            {
                Readings[i] = await App.Database.Connection.GetWithChildrenAsync<ForReadingModel>(Readings[i].InformationID);
            }

            if (Meditations.Count > 0)
                Favs.Add(new() { NameOfFav = "Медитации", Description = $"Сохранено медитаций: {Meditations.Count}" });
            if (Breathes.Count > 0)
                Favs.Add(new() { NameOfFav = "Дыхательные техники", Description = $"Сохранено техник: {Breathes.Count}" });
            if (Readings.Count > 0)
                Favs.Add(new() { NameOfFav = "Статьи для чтения", Description = $"Сохранено статей: {Readings.Count}" });
            if (Thinks.Count > 0)
                Favs.Add(new() { NameOfFav = "Позитивное мышление", Description = $"Сохранено мыслей: {Thinks.Count}" });
        }

        [RelayCommand]
        private void FromFavouriteToPage(object param)
        {

            switch (param.ToString())
            {
                case "Медитации":
                    Shell.Current.GoToAsync($"MeditationList", new Dictionary<string, object>
                    {
                        ["IsFavourite"] = 1
                    });
                    break;
                case "Дыхательные техники":
                    Shell.Current.GoToAsync($"BreatheList", new Dictionary<string, object>
                    {
                        ["IsFavourite"] = 1
                    });
                    break;
                case "Позитивное мышление":
                    Shell.Current.GoToAsync($"PositiveThinking", new Dictionary<string, object>
                    {
                        ["IsFavourite"] = 1
                    });
                    break;
                case "Статьи для чтения":
                    Shell.Current.GoToAsync($"ForReading", new Dictionary<string, object>
                    {
                        ["IsFavourite"] = 1
                    });
                    break;
                default:
                    break;
            }
        }
    }
}
