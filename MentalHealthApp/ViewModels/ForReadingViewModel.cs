using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using MentalHealthApp.Models;
using CommunityToolkit.Mvvm.Input;

namespace MentalHealthApp.ViewModels
{
    public partial class ForReadingViewModel : ObservableObject
    {

        [ObservableProperty]
        private ObservableCollection<CategoryModel> cats;

        [ObservableProperty]
        private ObservableCollection<ForReadingModel> work;

        [ObservableProperty]
        private ObservableCollection<ForReadingModel> study;

        [ObservableProperty]
        private ObservableCollection<ForReadingModel> health;

        [ObservableProperty]
        private ObservableCollection<ForReadingModel> life;



        public ForReadingViewModel()
        {
            LoadReadings();
        }


     
        [RelayCommand]
        private async void LoadReadings()
        {
            
            var cats = await App.Database.GetListOfCats();
            if (cats.Any())
            {
                Cats = new ObservableCollection<CategoryModel>(cats);

                var work = await App.Database.GetListOfReading(1);
                Work = new ObservableCollection<ForReadingModel>(work.Readings);

                var study = await App.Database.GetListOfReading(2);
                Study = new ObservableCollection<ForReadingModel>(study.Readings);

                var health = await App.Database.GetListOfReading(3);
                Health = new ObservableCollection<ForReadingModel>(health.Readings);

                var life = await App.Database.GetListOfReading(4);
                Life = new ObservableCollection<ForReadingModel>(life.Readings);
            }

            
        }

        [RelayCommand]
        private void GetSubTopicName(object parametr)
        {
            var param = parametr as object[];
            var subTpc = param[0];
            var tPc = param[1];
            var mntsCount = param[2];
            var imagePath = param[3];
            var themes = param[4];
            var content = param[5];
            Shell.Current.GoToAsync($"ForReadingSelected", new Dictionary<string, object>
            {
                ["topicName"] = tPc,
                ["subTopicName"] = subTpc,
                ["minutes"] = mntsCount,
                ["imagePath"] = imagePath,
                ["themes"] = themes,
                ["content"] = content
            });
        }
    }
}
