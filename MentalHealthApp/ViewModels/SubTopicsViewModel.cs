
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
        private ObservableCollection<PosThCardsModel> work;
        [ObservableProperty]
        private ObservableCollection<PosThCardsModel> study;
        [ObservableProperty]
        private ObservableCollection<PosThCardsModel> health;
        [ObservableProperty]
        private ObservableCollection<PosThCardsModel> life;
        [ObservableProperty]
        private ObservableCollection<PosThCardsModel> thCards;

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
            }

            var work = await App.Database.GetListOfSubTopics(Cats[0].CategoryID);
            if (work.Any())
            {
                Work = new ObservableCollection<PosThCardsModel>(work);
            }

            var study = await App.Database.GetListOfSubTopics(Cats[1].CategoryID);
            if (study.Any())
            {
                Study = new ObservableCollection<PosThCardsModel>(study);
            }

            var health = await App.Database.GetListOfSubTopics(Cats[2].CategoryID);
            if (health.Any())
            {
                Health = new ObservableCollection<PosThCardsModel>(health);
            }

            var life = await App.Database.GetListOfSubTopics(Cats[3].CategoryID);
            if (life.Any())
            {
                Life = new ObservableCollection<PosThCardsModel>(life);
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
