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
    public partial class MeditationListViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<MeditationModel> mList;

        public MeditationListViewModel()
        {
            LoadMeditations();
        }

        [RelayCommand]
        private async void LoadMeditations()
        {

            var meditationsTemp = await App.Database.GetListOfMeditations();
            if (meditationsTemp.Any())
            {
                MList = new ObservableCollection<MeditationModel>(meditationsTemp);
            }
        }

        [RelayCommand]
        private void GetMeditationName(object parametr)
        {
            var param = parametr as object[];
            var subTpc = param[0];
            var tPc = param[1];
            var mntsCount = param[2];
            var imgPath = param[3];
            var content = param[4];
            var guide = param[5];
            Shell.Current.GoToAsync($"Meditation", new Dictionary<string, object>
            {
                ["meditationName"] = subTpc,
                ["meditationTime"] = tPc,
                ["meditationLevel"] = mntsCount,
                ["imagePath"] = imgPath,
                ["content"] = content,
                ["guide"] = guide
            });
        }
    }
}
