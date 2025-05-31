using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using MentalHealthApp.Models;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Maui.Core.Extensions;

namespace MentalHealthApp.ViewModels
{
    [QueryProperty("FromFavourite", "IsFavourite")]
    [QueryProperty("MonthAndYear", "givenMonthAndYear")]
    [QueryProperty("CurrentDay", "givenDay")]
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

        [ObservableProperty]
        int currentDay;
        [ObservableProperty]
        string monthAndYear;
        [ObservableProperty]
        string fullDate;


        public ForReadingViewModel()
        {
            LoadReadings();
        }

        partial void OnFromFavouriteChanged(int value)
        {
            LoadReadings();
        }

        partial void OnCurrentDayChanged(int value)
        {
            if (value < 10)
                FullDate = "0" + value.ToString() + "/" + MonthAndYear;
            else
                FullDate = value.ToString() + "/" + MonthAndYear;
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
                    if (CurrentDay == 0)
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
                        var curDay = await App.Database.GetCurrentDay(FullDate.Split('/'));
                        if (curDay.Readings.Count > 0)
                        {
                            Work = curDay.Readings.Where(x => x.CategoryID == 1).ToList().ToObservableCollection();
                            Study = curDay.Readings.Where(x => x.CategoryID == 2).ToList().ToObservableCollection();
                            Health = curDay.Readings.Where(x => x.CategoryID == 3).ToList().ToObservableCollection();
                            Life = curDay.Readings.Where(x => x.CategoryID == 4).ToList().ToObservableCollection();
                            //foreach (var item in curDay.Readings)
                            //{
                            //    switch (item.CategoryID)
                            //    {
                            //        case 1:
                            //            if (Work == null)
                            //                Work = new ObservableCollection<ForReadingModel>() { item };
                            //            else
                            //                Work.Add(item);
                            //            break;
                            //        case 2:
                            //            if (Study == null)
                            //                Study = new ObservableCollection<ForReadingModel>() { item };
                            //            else
                            //                Study.Add(item);
                            //            break;
                            //        case 3:
                            //            if (Health == null)
                            //                Health = new ObservableCollection<ForReadingModel>() { item };
                            //            else
                            //                Health.Add(item);
                            //            break;
                            //        case 4:
                            //            if (Life == null)
                            //                Life = new ObservableCollection<ForReadingModel>() { item };
                            //            else
                            //                Life.Add(item);
                            //            break;
                            //        default:
                            //            break;
                            //    }
                            //}
                            CheckCatsFill();
                        }
                    }

                }
                else
                {
                    var work = await App.Database.GetListOfReading(1);
                    var listOfWorks = work.Readings.Where(x => x.isFavourite == 1).ToList();
                    Work = new ObservableCollection<ForReadingModel>(listOfWorks);



                    var study = await App.Database.GetListOfReading(2);
                    Study = new ObservableCollection<ForReadingModel>(study.Readings.Where(x => x.isFavourite == 1).ToList());



                    var health = await App.Database.GetListOfReading(3);
                    Health = new ObservableCollection<ForReadingModel>(health.Readings.Where(x => x.isFavourite == 1).ToList());


                    var life = await App.Database.GetListOfReading(4);
                    Life = new ObservableCollection<ForReadingModel>(life.Readings.Where(x => x.isFavourite == 1).ToList());


                    CheckCatsFill();
                }

            }

        }
        void CheckCatsFill()
        {
            if (Work != null)
                if (Work.Count == 0)
                {
                    Work = null;
                    IsAddedTextWork = true;
                }

            if (Study != null)
                if (Study.Count == 0)
                {
                    Study = null;
                    IsAddedTextStudy = true;
                }
            if (Health != null)
                if (Health.Count == 0)
                {
                    Health = null;
                    IsAddedTextHealth = true;
                }
            if (Life != null)
                if (Life.Count == 0)
                {
                    Life = null;
                    IsAddedTextLife = true;
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
