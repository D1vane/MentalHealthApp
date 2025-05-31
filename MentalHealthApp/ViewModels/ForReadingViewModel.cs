using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using MentalHealthApp.Models;
using CommunityToolkit.Mvvm.Input;

namespace MentalHealthApp.ViewModels
{
    [QueryProperty("FromFavourite", "IsFavourite")]
    public partial class ForReadingViewModel : ObservableObject
    {

        [ObservableProperty]
        private ObservableCollection<CategoryModel> cats = new();

        [ObservableProperty]
        private ObservableCollection<ForReadingModel> work;

        [ObservableProperty]
        private ObservableCollection<ForReadingModel> study;

        [ObservableProperty]
        private ObservableCollection<ForReadingModel> health;

        [ObservableProperty]
        private ObservableCollection<ForReadingModel> life;

        [ObservableProperty]
        int fromFavourite;
        [ObservableProperty]
        bool isAddedTextWork = false;
        [ObservableProperty]
        bool isAddedTextStudy = false;
        [ObservableProperty]
        bool isAddedTextLife = false;
        [ObservableProperty]
        bool isAddedTextHealth = false;


        public ForReadingViewModel()
        {
            LoadReadings();
        }

        partial void OnFromFavouriteChanged(int value)
        {
            LoadReadings();
        }
        [RelayCommand]
        private async void LoadReadings()
        {
            var cats = await App.Database.GetListOfCats();
            Cats = new ObservableCollection<CategoryModel>(cats);
            if (cats.Any())
            {


                if (FromFavourite == 0)
                {
                    

                    var work = await App.Database.GetListOfReading(1);
                    Work = new ObservableCollection<ForReadingModel>(work.Readings);

                    var study = await App.Database.GetListOfReading(2);
                    Study = new ObservableCollection<ForReadingModel>(study.Readings);

                    var health = await App.Database.GetListOfReading(3);
                    Health = new ObservableCollection<ForReadingModel>(health.Readings);

                    var life = await App.Database.GetListOfReading(4);
                    Life = new ObservableCollection<ForReadingModel>(life.Readings);

                }
                else
                {
                    var work = await App.Database.GetListOfReading(1);
                    var listOfWorks = work.Readings.Where(x => x.isFavourite == 1).ToList();
                    Work = new ObservableCollection<ForReadingModel>(listOfWorks);
                    if (Work.Count == 0)
                    {
                        Work = null;
                        IsAddedTextWork = true;
                    }
                        

                    var study = await App.Database.GetListOfReading(2);
                    Study = new ObservableCollection<ForReadingModel>(study.Readings.Where(x => x.isFavourite == 1).ToList());
                    if (Study.Count == 0)
                    {
                        Study = null;
                        IsAddedTextStudy = true;
                    }
                        
                        
                    var health = await App.Database.GetListOfReading(3);
                    Health = new ObservableCollection<ForReadingModel>(health.Readings.Where(x => x.isFavourite == 1).ToList());
                    if (Health.Count == 0)
                    {
                        Health = null;
                        IsAddedTextHealth = true;
                    }
                        
                    var life = await App.Database.GetListOfReading(4);
                    Life = new ObservableCollection<ForReadingModel>(life.Readings.Where(x => x.isFavourite == 1).ToList());
                    if (Life.Count == 0)
                    {
                        Life = null;
                        IsAddedTextLife = true;
                    }
                        

                }

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
            var favourite = param[6];
            Shell.Current.GoToAsync($"ForReadingSelected", new Dictionary<string, object>
            {
                ["topicName"] = tPc,
                ["subTopicName"] = subTpc,
                ["minutes"] = mntsCount,
                ["imagePath"] = imagePath,
                ["themes"] = themes,
                ["content"] = content,
                ["favourite"] = favourite
            });
        }
    }
}
