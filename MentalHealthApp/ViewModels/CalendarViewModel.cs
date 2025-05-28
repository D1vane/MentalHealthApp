
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MentalHealthApp.Models;
using SQLiteNetExtensionsAsync.Extensions;
using System.Collections.ObjectModel;
using static System.Convert;

namespace MentalHealthApp.ViewModels
{
    public partial class CalendarViewModel : ObservableObject
    {


        [ObservableProperty]
        private DateTime startDate = new DateTime(ToInt32(DateTime.Today.Year), ToInt32(DateTime.Today.Month), 1);

        [ObservableProperty]
        private DateTime endDate = new DateTime(ToInt32(DateTime.Today.Year), ToInt32(DateTime.Today.Month) + 1, 1);
        [ObservableProperty]
        int numOfDayWeek = (int)(new DateTime(ToInt32(DateTime.Today.Year), ToInt32(DateTime.Today.Month), 1).DayOfWeek + 6) % 7;

        [ObservableProperty]
        ObservableCollection<FavouriteModel> cats = new();

        [ObservableProperty]
        private ObservableCollection<CalendarModel> fullMonth = new();
        [ObservableProperty]
        private CalendarModel calendarModel;

        [RelayCommand]
        private void SwipeToTheLeft()
        {
            StartDate = StartDate.AddMonths(-1);
            EndDate = EndDate.AddMonths(-1);
            NumOfDayWeek = (int)(StartDate.DayOfWeek + 6) % 7;
            FIllTheList();
        }
        [RelayCommand]
        private void SwipeToTheRight()
        {
            StartDate = StartDate.AddMonths(1);
            EndDate = EndDate.AddMonths(1);
            NumOfDayWeek = (int)(StartDate.DayOfWeek + 6) % 7;
            FIllTheList();
        }
        /// <summary>
        /// Заполнение числами в соответствии с днями недели
        /// </summary>
        public async void FIllTheList()
        {

            FullMonth.Clear();
            switch (NumOfDayWeek)
            {
                case 0:
                    {
                        GetDays();
                        break;
                    }
                case 1:
                    {
                        FullMonth.Add(new());
                        GetDays();
                        break;
                    }
                case 2:
                    {
                        FullMonth.Add(new());
                        FullMonth.Add(new());
                        GetDays();
                        break;
                    }
                case 3:
                    {
                        for (int i = 0; i < NumOfDayWeek; i++)
                        {
                            FullMonth.Add(new());
                        }
                        GetDays();
                        break;
                    }
                case 4:
                    {
                        for (int i = 0; i < NumOfDayWeek; i++)
                        {
                            FullMonth.Add(new());
                        }
                        GetDays();
                        break;
                    }
                case 5:
                    {
                        for (int i = 0; i < NumOfDayWeek; i++)
                        {
                            FullMonth.Add(new());
                        }
                        GetDays();
                        break;
                    }

                case 6:
                    {
                        for (int i = 0; i < NumOfDayWeek; i++)
                        {
                            FullMonth.Add(new());
                        }
                        GetDays();
                        break;
                    }
                default:
                    break;
            }
            if (StartDate.Month == DateTime.Today.Month)
                CalendarModel = FullMonth[NumOfDayWeek + DateTime.Today.Day - 1];


        }

        async void GetDays()
        {
            var currentMonth = await App.Database.Connection.Table<CalendarModel>().Where(x => x.FullDate.EndsWith(StartDate.ToString("MM/yyyy"))).ToListAsync();
            if (currentMonth.Count > 0 && currentMonth != null)
                for (var i = StartDate; i < EndDate; i = i.AddDays(1))
                {
                    if (currentMonth.Contains(new CalendarModel() { FullDate = i.ToString("dd/MM/yyyy") }))
                    {
                        var currentDay = currentMonth.Where(x => x.FullDate == i.ToString("dd/MM/yyyy")).FirstOrDefault();
                        var dayWithChildren = await App.Database.Connection.GetWithChildrenAsync<CalendarModel>(currentDay.DayID);
                        if (dayWithChildren.Meditations.Count != 0)
                        {
                            Cats.Add(new FavouriteModel { NameOfFav = "Медитации", AllTasks = dayWithChildren.Meditations.Count });
                        }
                        if (dayWithChildren.Breathes.Count != 0)
                        {
                            Cats.Add(new FavouriteModel { NameOfFav = "Дыхательные техники", AllTasks = dayWithChildren.Breathes.Count });
                        }
                        if (dayWithChildren.Sleep != null)
                        {
                            Cats.Add(new FavouriteModel { NameOfFav = "Отмеченный сон" });
                        }
                        if (dayWithChildren.Feelings.Count != 0)
                        {
                            Cats.Add(new FavouriteModel { NameOfFav = "Отмеченные самочувствия", AllTasks = dayWithChildren.Feelings.Count });
                        }
                        if (dayWithChildren.Tasks.Count != 0)
                        {
                            Cats.Add(new FavouriteModel
                            {
                                NameOfFav = "Список задач",
                                AllTasks = dayWithChildren.Tasks.Count,
                                CompletedTasks = dayWithChildren.Tasks.Where(x => x.IsComplete == 1).Count()
                            });
                        }
                        if (dayWithChildren.Readings.Count != 0)
                        {
                            Cats.Add(new FavouriteModel { NameOfFav = "Для чтения", AllTasks = dayWithChildren.Readings.Count });
                        }

                    }
                }
        }


    }
}
