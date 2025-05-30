using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MentalHealthApp.Models;
using Microsoft.Maui.Controls.Shapes;
using SQLiteNetExtensionsAsync.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentalHealthApp.ViewModels
{
    public partial class BreatheListViewModel : ObservableObject
    {
        
        
        [ObservableProperty]
        ObservableCollection<BreatheModel> breathes;
        [ObservableProperty]
        string minDate = DateTime.Now.ToString("MM/dd/yyyy");
        [ObservableProperty]
        string selectedDate = DateTime.Now.ToString("MM/dd/yyyy");
        [ObservableProperty]
        int breatheID;
        public BreatheListViewModel()
        {
            LoadBreathes();
        }

        [RelayCommand]
        private async void LoadBreathes()
        {

            var breathesTemp = await App.Database.GetListOfBreathes();
            if (breathesTemp.Any())
            {
                Breathes = new ObservableCollection<BreatheModel>(breathesTemp);
            }
        }

        [RelayCommand]
        void GetBreatheID(object id)
        {
            BreatheID = (int)id;

        }
        [RelayCommand]
        void GoToBreathe(object parameter)
        {
            var param = parameter as object[];

            var nameOfBreathe = param[0];
            var loopDuration = param[1];
            var guideText = param[2];

            Shell.Current.GoToAsync($"Breathe", new Dictionary<string, object>
            {
                ["breatheName"] = nameOfBreathe,
                ["loopDuration"] = loopDuration,
                ["minutes"] = new TimeSpan(0, 0, (int)loopDuration).Multiply(10).Minutes,
                ["seconds"] = new TimeSpan(0, 0, (int)loopDuration).Multiply(10).Seconds,
                ["guide"] = guideText
            });
        }

        public async void AddBreatheToDB()
        {
            string text = Convert.ToDateTime(SelectedDate).ToString("dd/MM/yyyy");
            var today = await App.Database.GetCurrentDay(text.Split('/'));
            BreatheModel breatheModel = Breathes.Where(x => x.BreatheID == BreatheID).First();
            today.Breathes.Add(breatheModel);
            await App.Database.Connection.UpdateWithChildrenAsync(today);
        }
    }
}
