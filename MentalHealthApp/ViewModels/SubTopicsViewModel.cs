
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MentalHealthApp.Models;
using Microsoft.Maui.Controls.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MentalHealthApp.ViewModels
{
    public partial class SubTopicsViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<CategoryModel> cats;

        [ObservableProperty]
        private ObservableCollection<ThemeModel> work;
        [ObservableProperty]
        private ObservableCollection<ThemeModel> study;
        [ObservableProperty]
        private ObservableCollection<ThemeModel> health;
        [ObservableProperty]
        private ObservableCollection<ThemeModel> life;
        [ObservableProperty]
        private ObservableCollection<ThemeModel> thCards;

        public SubTopicsViewModel()
        {
            LoadSubTopics();
        }

        [RelayCommand]
        private async void LoadSubTopics()
        {

            var cats = await App.Database.GetListOfCats();
            if (cats.Any())
            {
                Cats = new ObservableCollection<CategoryModel>(cats);

                var work = await App.Database.GetListOfSubTopics(1);
                Work = new ObservableCollection<ThemeModel>(work.Themes);

                var study = await App.Database.GetListOfSubTopics(2);
                Study = new ObservableCollection<ThemeModel>(study.Themes);

                var health = await App.Database.GetListOfSubTopics(3);
                Health = new ObservableCollection<ThemeModel>(health.Themes);

                var life = await App.Database.GetListOfSubTopics(4);
                Life = new ObservableCollection<ThemeModel>(life.Themes);
            }

            
        }

        [RelayCommand]
        private void GetSubTopicName(object parametr)
        {
            var param = parametr as object[];
            var subTpc = param[0];
            var tPc = param[1];
            Shell.Current.GoToAsync($"PositiveThinkingCards", new Dictionary<string, object>
            {
                ["topicName"] = tPc,
                ["subTopicName"] = subTpc
            });
        }
    }
}
