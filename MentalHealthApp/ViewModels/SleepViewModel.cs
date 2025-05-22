using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MentalHealthApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentalHealthApp.ViewModels
{
    public partial class SleepViewModel : ObservableObject
    {

        [ObservableProperty]
        string arrowImage = "doublearrowdown_icon.png";
        [ObservableProperty]
        bool factorsVisibility = false;
        [ObservableProperty]
        ObservableCollection<SleepModel> factorsBeforeSleep;
        [ObservableProperty]
        ObservableCollection<SleepModel> sleepFactors;
        //[RelayCommand]
        //void OpenDescription()
        //{
        //    if (ArrowImage == "doublearrowdown_icon.png")
        //    {
        //        FactorsVisibility = true;
        //        ArrowImage = "doublearrowup_icon.png";
        //        FactorsBeforeSleep =
        //            [
        //                new () {FactorName = "Гаджет", ImagePath = "phone_icon.png"},
        //            new () {FactorName = "Легкий перекус", ImagePath = "donut_icon.png"},
        //            new () {FactorName = "Тяжелая пища", ImagePath = "doubledonut_icon.png"},
        //            new () {FactorName = "Кофеин", ImagePath = "coffee_icon.png"},
        //            new () {FactorName = "Никотин", ImagePath = "thumbdown_icon.png"},
        //            new () {FactorName = "Алкоголь", ImagePath = "alchocol_icon.png"},
        //            new () {FactorName = "Сильный стресс", ImagePath = "facepalm_icon.png"},
        //            new () {FactorName = "Умственная нагрузка", ImagePath = "loader_icon.png"},
        //            new () {FactorName = "Физическая нагрузка", ImagePath = "basketball_icon.png"},
        //            new () {FactorName = "Выпито много воды", ImagePath = "droplet_icon.png"},
        //            new () {FactorName = "Прием лекарств", ImagePath = "plus_icon.png"},
        //            new () {FactorName = "Помещение проветрено", ImagePath = "wind_icon.png"},
        //            new () {FactorName = "Чтение книги", ImagePath = "bookopen_icon.png"},
        //            new () {FactorName = "Прогулка на воздухе", ImagePath = "cloud_icon.png"},
        //            new () {FactorName = "Теплый душ", ImagePath = "raincloud_icon.png"},
        //            new () {FactorName = "Спокойная музыка", ImagePath = "headphones_icon.png"},
        //        ];
        //        SleepFactors =
        //            [
        //            new () {FactorName = "Посторонние звуки", ImagePath = "volume2_icon.png"},
        //            new () {FactorName = "Нарушение темноты", ImagePath = "sun_icon.png"},
        //            new () {FactorName = "Нарушение режима", ImagePath = "crossedclock_icon.png"},
        //        ];
        //    }
        //    else
        //    {
        //        FactorsVisibility = false;
        //        ArrowImage = "doublearrowdown_icon.png";
        //        FactorsBeforeSleep.Clear();
        //        SleepFactors.Clear();
        //    }
            
        //}
    }
}
