using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using MentalHealthApp.Models;
using CommunityToolkit.Mvvm.Input;

namespace MentalHealthApp.ViewModels
{
    public partial class ForReadingViewModel : ObservableObject
    {
        MentalHealthAppDB db;

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
            Task.Run(async () =>
            {
                var cats = await db.GetListOfCats();               
                if (cats.Any())
                {
                    Cats = new ObservableCollection<CategoryModel>(cats);
                }

                var work = await db.GetListOfReading(Cats[0].CategoryID);
                if (work.Any())
                {
                    Work = new ObservableCollection<ForReadingModel>(work);   
                }

                var study = await db.GetListOfReading(Cats[1].CategoryID);
                if (work.Any())
                {
                    Study = new ObservableCollection<ForReadingModel>(study);
                }

                var health = await db.GetListOfReading(Cats[2].CategoryID);
                if (work.Any())
                {
                    Health = new ObservableCollection<ForReadingModel>(health);
                }

                var life = await db.GetListOfReading(Cats[3].CategoryID);
                if (work.Any())
                {
                    Life = new ObservableCollection<ForReadingModel>(life);
                }
            });
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

        public async Task<List<ForReadingModel>> GetListOfReadings(int )
        {
            return await db.Connection.Table<ForReadingModel>().Where;
        }
    }
}
