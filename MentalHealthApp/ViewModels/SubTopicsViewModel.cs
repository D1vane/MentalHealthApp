
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MentalHealthApp.Models;
using Microsoft.Maui.Controls.Shapes;
using SQLiteNetExtensionsAsync.Extensions;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MentalHealthApp.ViewModels
{
    [QueryProperty("FromFavourite", "IsFavourite")]
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

        public SubTopicsViewModel()
        {
            LoadSubTopics();
        }

        partial void OnFromFavouriteChanged(int value)
        {
            LoadSubTopics();
        }
        [RelayCommand]
        private async void LoadSubTopics()
        {

            var cats = await App.Database.GetListOfCats();
            Cats = new ObservableCollection<CategoryModel>(cats);
            if (cats.Any())
            {


                if (FromFavourite == 0)
                {


                    var work = await App.Database.GetListOfSubTopics(1);
                    Work = new ObservableCollection<ThemeModel>(work.Themes);

                    var study = await App.Database.GetListOfSubTopics(2);
                    Study = new ObservableCollection<ThemeModel>(study.Themes);

                    var health = await App.Database.GetListOfSubTopics(3);
                    Health = new ObservableCollection<ThemeModel>(health.Themes);

                    var life = await App.Database.GetListOfSubTopics(4);
                    Life = new ObservableCollection<ThemeModel>(life.Themes);

                }
                else
                {
                    var work = await App.Database.GetListOfSubTopics(1);
                    CategoryModel tempWork = new CategoryModel()
                    {
                        CategoryID = work.CategoryID,
                        NameOfCategory = work.NameOfCategory,
                        Themes = new()
                    };

                    for (int i = 0; i < work.Themes.Count; i++)
                    {
                        var themesWithChildren = await App.Database.Connection.GetWithChildrenAsync<ThemeModel>(work.Themes[i].ThemeID);
                        var favouriteThinks = themesWithChildren.Thinks.Where(x => x.isFavourite == 1).ToList();
                        if (favouriteThinks.Count > 0)
                        {
                            tempWork.Themes.Add(work.Themes[i]);
                            tempWork.Themes.Last().Thinks = favouriteThinks;
                        }

                    }
                    Work = new ObservableCollection<ThemeModel>(tempWork.Themes);
                    if (Work.Count == 0)
                    {
                        Work = null;
                        IsAddedTextWork = true;
                    }


                    var study = await App.Database.GetListOfSubTopics(2);
                    CategoryModel tempStudy = new CategoryModel()
                    {
                        CategoryID = study.CategoryID,
                        NameOfCategory = study.NameOfCategory,
                        Themes = new()
                    };

                    for (int i = 0; i < study.Themes.Count; i++)
                    {
                        var themesWithChildren = await App.Database.Connection.GetWithChildrenAsync<ThemeModel>(study.Themes[i].ThemeID);
                        var favouriteThinks = themesWithChildren.Thinks.Where(x => x.isFavourite == 1).ToList();
                        if (favouriteThinks.Count > 0)
                        {
                            tempStudy.Themes.Add(study.Themes[i]);
                            tempStudy.Themes.Last().Thinks = favouriteThinks;
                        }

                    }
                    Study = new ObservableCollection<ThemeModel>(tempStudy.Themes);
                    if (Study.Count == 0)
                    {
                        Study = null;
                        IsAddedTextStudy = true;
                    }


                    var health = await App.Database.GetListOfSubTopics(3);
                    CategoryModel tempHealth = new CategoryModel()
                    {
                        CategoryID = health.CategoryID,
                        NameOfCategory = health.NameOfCategory,
                        Themes = new()
                    };

                    for (int i = 0; i < health.Themes.Count; i++)
                    {
                        var themesWithChildren = await App.Database.Connection.GetWithChildrenAsync<ThemeModel>(health.Themes[i].ThemeID);
                        var favouriteThinks = themesWithChildren.Thinks.Where(x => x.isFavourite == 1).ToList();
                        if (favouriteThinks.Count > 0)
                        {
                            tempHealth.Themes.Add(health.Themes[i]);
                            tempHealth.Themes.Last().Thinks = favouriteThinks;
                        }

                    }
                    Health = new ObservableCollection<ThemeModel>(tempHealth.Themes);
                    if (Health.Count == 0)
                    {
                        Health = null;
                        IsAddedTextHealth = true;
                    }

                    var life = await App.Database.GetListOfSubTopics(4);
                    CategoryModel tempLife = new CategoryModel()
                    {
                        CategoryID = life.CategoryID,
                        NameOfCategory = life.NameOfCategory,
                        Themes = new()
                    };

                    for (int i = 0; i < life.Themes.Count; i++)
                    {
                        var themesWithChildren = await App.Database.Connection.GetWithChildrenAsync<ThemeModel>(life.Themes[i].ThemeID);
                        var favouriteThinks = themesWithChildren.Thinks.Where(x => x.isFavourite == 1).ToList();
                        if (favouriteThinks.Count > 0)
                        {
                            tempLife.Themes.Add(life.Themes[i]);
                            tempLife.Themes.Last().Thinks = favouriteThinks;
                        }

                    }
                    Life = new ObservableCollection<ThemeModel>(tempLife.Themes);
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
            Shell.Current.GoToAsync($"PositiveThinkingCards", new Dictionary<string, object>
            {
                ["topicName"] = tPc,
                ["subTopicName"] = subTpc,
                ["IsFavourite"] = FromFavourite
            });
        }
    }
}
