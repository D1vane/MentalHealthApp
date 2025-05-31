using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MentalHealthApp.Models;
using SQLiteNetExtensionsAsync.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MentalHealthApp.ViewModels
{
    [QueryProperty ("FromFavourite","IsFavourite")]
    public partial class MeditationListViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<MeditationModel> mList;
        [ObservableProperty]
        string minDate = DateTime.Now.ToString("MM/dd/yyyy");
        [ObservableProperty]
        string selectedDate = DateTime.Now.ToString("MM/dd/yyyy");
        [ObservableProperty]
        int meditationID;
        [ObservableProperty]
        int fromFavourite;

        public MeditationListViewModel()
        {
            LoadMeditations();
        }

        partial void OnFromFavouriteChanged(int value)
        {
            LoadMeditations();
        }
        [RelayCommand]
        private async void LoadMeditations()
        {
            if (FromFavourite == 0)
            {
                var meditationsTemp = await App.Database.GetListOfMeditations();
                if (meditationsTemp.Any())
                {
                    MList = new ObservableCollection<MeditationModel>(meditationsTemp);
                }
            }
            else
            {
                var meditationsTemp = await App.Database.Connection.Table<MeditationModel>().Where(x=>x.IsFavourite==FromFavourite).ToListAsync();
                if (meditationsTemp.Any())
                {
                    MList = new ObservableCollection<MeditationModel>(meditationsTemp);
                }
            }
            
        }
        [RelayCommand]
        void GetMeditationID(object id)
        {
            MeditationID = (int)id;

        }

        [RelayCommand]
        void GetFavouriteStatus(object id)
        {
            MeditationID = (int)id;
            MeditationFavouriteStatusUpdate();
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
            var favourite = param[6];
            Shell.Current.GoToAsync($"Meditation", new Dictionary<string, object>
            {
                ["meditationName"] = subTpc,
                ["meditationTime"] = tPc,
                ["meditationLevel"] = mntsCount,
                ["imagePath"] = imgPath,
                ["content"] = content,
                ["guide"] = guide,
                ["favourite"] = favourite
            });
        }

        public async void AddMeditationToDB()
        {
            string text = Convert.ToDateTime(SelectedDate).ToString("dd/MM/yyyy");
            var today = await App.Database.GetCurrentDay(text.Split('/'));
            MeditationModel meditationModel = MList.Where(x => x.MeditationID == MeditationID).First();
            today.Meditations.Add(meditationModel);
            await App.Database.Connection.UpdateWithChildrenAsync(today);
        }

        public async void MeditationFavouriteStatusUpdate()
        {
            MeditationModel meditationModel = MList.Where(x => x.MeditationID == MeditationID).First();
            int index = MList.IndexOf(meditationModel);
            meditationModel.IsFavourite = (meditationModel.IsFavourite == 0) ? 1 : 0;
            MList[index] = meditationModel;
            await App.Database.Connection.UpdateWithChildrenAsync(meditationModel);
   
        }

    }
}
