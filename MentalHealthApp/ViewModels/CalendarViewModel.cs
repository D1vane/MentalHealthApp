
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MentalHealthApp.Models;
using System.Collections.ObjectModel;
using static System.Convert;

namespace MentalHealthApp.ViewModels
{
    public partial class CalendarViewModel : ObservableObject
    {


        [ObservableProperty]
        private DateTime startDate = new DateTime(ToInt32(DateTime.Today.Year), ToInt32(DateTime.Today.Month), 1);

        [ObservableProperty]
        private DateTime endDate = new DateTime(ToInt32(DateTime.Today.Year), ToInt32(DateTime.Today.Month)+1, 1);
        [ObservableProperty]
        int numOfDayWeek = (int)(new DateTime(ToInt32(DateTime.Today.Year), ToInt32(DateTime.Today.Month), 1).DayOfWeek + 6) % 7;

        [ObservableProperty]
        ObservableCollection<FavouriteModel> cats =
            [
            new () {NameOfFav = "Задачи на день", AllTasks = 3, CompletedTasks = 1},
            new () {NameOfFav = "Медитации", AllTasks = 2, CompletedTasks = 0},
            new () {NameOfFav = "Дыхательные техники", AllTasks = 1, CompletedTasks = 0}
            ];

        [ObservableProperty]
        private ObservableCollection<CalendarModel> fullMonth = new();
        [ObservableProperty]
        private CalendarModel calendarModel;

        [RelayCommand]
        private void SwipeToTheLeft ()
        {
            StartDate = StartDate.AddMonths(-1);
            EndDate = EndDate.AddMonths(-1);
            NumOfDayWeek = (int)(StartDate.DayOfWeek + 6) % 7;
            //FIllTheList();
        }
        [RelayCommand]
        private void SwipeToTheRight()
        {
            StartDate = StartDate.AddMonths(1);
            EndDate = EndDate.AddMonths(1);
            NumOfDayWeek = (int)(StartDate.DayOfWeek + 6) % 7;
            //FIllTheList();
        }
        /// <summary>
        /// Заполнение числами в соответствии с днями недели
        /// </summary>
        //public void FIllTheList()
        //{
        //    FullMonth.Clear();
        //    bool haveTask = false;
        //    switch (NumOfDayWeek)
        //    {
        //        case 0:
        //            {
        //                for (var i = StartDate; i < EndDate; i = i.AddDays(1))
        //                {
        //                    if (i.Day.ToString() == "18")
        //                        haveTask = true;
        //                    FullMonth.Add(new() { CurrentDay = i.Day.ToString(), TaskCount = (haveTask == true) ? 5.ToString() : ""});
        //                    haveTask = false;
        //                }
        //                break;
        //            }
        //        case 1:
        //            {
        //                FullMonth.Add(new());
        //                for (var i = StartDate; i < EndDate; i = i.AddDays(1))
        //                {
        //                    if (i.Day.ToString() == "18")
        //                        haveTask = true;
        //                    FullMonth.Add(new() { CurrentDay = i.Day.ToString(), TaskCount = (haveTask == true) ? 5.ToString() : "" });
        //                    haveTask = false;
        //                }
        //                break;
        //            }
        //        case 2:
        //            {
        //                FullMonth.Add(new());
        //                FullMonth.Add(new());
        //                for (var i = StartDate; i < EndDate; i = i.AddDays(1))
        //                {
        //                    if (i.Day.ToString() == "18")
        //                        haveTask = true;
        //                    FullMonth.Add(new() { CurrentDay = i.Day.ToString(), TaskCount = (haveTask == true) ? 5.ToString() : "" });
        //                    haveTask = false;
        //                }
        //                break;
        //            }
        //        case 3:
        //            {
        //                for (int i = 0; i < NumOfDayWeek; i++)
        //                {
        //                    FullMonth.Add(new());
        //                }
        //                for (var i = StartDate; i < EndDate; i = i.AddDays(1))
        //                {
        //                    if (i.Day.ToString() == "18")
        //                        haveTask = true;
        //                    FullMonth.Add(new() { CurrentDay = i.Day.ToString(), TaskCount = (haveTask == true) ? 5.ToString() : "" });
        //                    haveTask = false;
        //                }
        //                break;
        //            }
        //        case 4:
        //            {
        //                for (int i = 0; i < NumOfDayWeek; i++)
        //                {
        //                    FullMonth.Add(new());
        //                }
        //                for (var i = StartDate; i < EndDate; i = i.AddDays(1))
        //                {
        //                    if (i.Day.ToString() == "18")
        //                        haveTask = true;
        //                    FullMonth.Add(new() { CurrentDay = i.Day.ToString(), TaskCount = (haveTask == true) ? 5.ToString() : "" });
        //                    haveTask = false;
        //                }
        //                break;
        //            }
        //        case 5:
        //            {
        //                for (int i = 0; i < NumOfDayWeek; i++)
        //                {
        //                    FullMonth.Add(new());
        //                }
        //                for (var i = StartDate; i < EndDate; i = i.AddDays(1))
        //                {
        //                    if (i.Day.ToString() == "18")
        //                        haveTask = true;
        //                    FullMonth.Add(new() { CurrentDay = i.Day.ToString(), TaskCount = (haveTask == true) ? 5.ToString() : "" });
        //                    haveTask = false;
        //                }
        //                break;
        //            }

        //        case 6:
        //            {
        //                for (int i = 0; i < NumOfDayWeek; i++)
        //                {
        //                    FullMonth.Add(new());
        //                }
        //                for (var i = StartDate; i < EndDate; i = i.AddDays(1))
        //                {
        //                    if (i.Day.ToString() == "18")
        //                        haveTask = true;
        //                    FullMonth.Add(new() { CurrentDay = i.Day.ToString(), TaskCount = (haveTask == true) ? 5.ToString() : "" });
        //                    haveTask = false;
        //                }
        //                break;
        //            }
        //        default:
        //            break;
        //    }
        //    if (StartDate.Month == DateTime.Today.Month)
        //    CalendarModel = FullMonth[NumOfDayWeek + DateTime.Today.Day - 1];
            

        //}

        

    }
}
