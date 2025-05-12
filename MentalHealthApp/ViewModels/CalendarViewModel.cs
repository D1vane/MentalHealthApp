
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MentalHealthApp.Models;
using System.Collections.ObjectModel;


namespace MentalHealthApp.ViewModels
{
    public partial class CalendarViewModel : ObservableObject
    {


        [ObservableProperty]
        private DateTime startDate = new DateTime(Convert.ToInt32(DateTime.Today.Year), Convert.ToInt32(DateTime.Today.Month), 1);

        [ObservableProperty]
        private DateTime endDate = new DateTime(Convert.ToInt32(DateTime.Today.Year), Convert.ToInt32(DateTime.Today.Month)+1, 1);
        [ObservableProperty]
        int numOfDayWeek = (int)(new DateTime(Convert.ToInt32(DateTime.Today.Year), Convert.ToInt32(DateTime.Today.Month), 1).DayOfWeek + 6) % 7;


        [ObservableProperty]
        private ObservableCollection<CalendarModel> fullMonth = new();

        [RelayCommand]
        private void SwipeToTheLeft ()
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
        public void FIllTheList()
        {
            FullMonth.Clear();
            switch (NumOfDayWeek)
            {
                case 0:
                    {
                        for (var i = StartDate; i < EndDate; i = i.AddDays(1))
                        {
                            FullMonth.Add(new() { CurrentDay = i.Day.ToString() });
                        }
                        break;
                    }
                case 1:
                    {
                        FullMonth.Add(new());
                        for (var i = StartDate; i < EndDate; i = i.AddDays(1))
                        {
                            FullMonth.Add(new() { CurrentDay = i.Day.ToString() });
                        }
                        break;
                    }
                case 2:
                    {
                        FullMonth.Add(new());
                        FullMonth.Add(new());
                        for (var i = StartDate; i < EndDate; i = i.AddDays(1))
                        {
                            FullMonth.Add(new() { CurrentDay = i.Day.ToString() });
                        }
                        break;
                    }
                case 3:
                    {
                        for (int i = 0; i < NumOfDayWeek; i++)
                        {
                            FullMonth.Add(new());
                        }
                        for (var i = StartDate; i < EndDate; i = i.AddDays(1))
                        {
                            FullMonth.Add(new() { CurrentDay = i.Day.ToString() });
                        }
                        break;
                    }
                case 4:
                    {
                        for (int i = 0; i < NumOfDayWeek; i++)
                        {
                            FullMonth.Add(new());
                        }
                        for (var i = StartDate; i < EndDate; i = i.AddDays(1))
                        {
                            FullMonth.Add(new() { CurrentDay = i.Day.ToString() });
                        }
                        break;
                    }
                case 5:
                    {
                        for (int i = 0; i < NumOfDayWeek; i++)
                        {
                            FullMonth.Add(new());
                        }
                        for (var i = StartDate; i < EndDate; i = i.AddDays(1))
                        {
                            FullMonth.Add(new() { CurrentDay = i.Day.ToString() });
                        }
                        break;
                    }

                case 6:
                    {
                        for (int i = 0; i < NumOfDayWeek; i++)
                        {
                            FullMonth.Add(new());
                        }
                        for (var i = StartDate; i < EndDate; i = i.AddDays(1))
                        {
                            FullMonth.Add(new() { CurrentDay = i.Day.ToString() });
                        }
                        break;
                    }
                default:
                    break;
            }

        }

        public void FIllTheList(DateTime startDate, DateTime endDate)
        {
            FullMonth.Clear();
            switch (NumOfDayWeek)
            {
                case 0:
                    {
                        for (var i = startDate; i < endDate; i = i.AddDays(1))
                        {
                            FullMonth.Add(new() { CurrentDay = i.Day.ToString() });
                        }
                        break;
                    }
                case 1:
                    {
                        FullMonth.Add(new());
                        for (var i = startDate; i < endDate; i = i.AddDays(1))
                        {
                            FullMonth.Add(new() { CurrentDay = i.Day.ToString() });
                        }
                        break;
                    }
                case 2:
                    {
                        FullMonth.Add(new());
                        FullMonth.Add(new());
                        for (var i = startDate; i < endDate; i = i.AddDays(1))
                        {
                            FullMonth.Add(new() { CurrentDay = i.Day.ToString() });
                        }
                        break;
                    }
                case 3:
                    {
                        for (int i = 0; i < numOfDayWeek; i++)
                        {
                            FullMonth.Add(new());
                        }
                        for (var i = startDate; i < endDate; i = i.AddDays(1))
                        {
                            FullMonth.Add(new() { CurrentDay = i.Day.ToString() });
                        }
                        break;
                    }
                case 4:
                    {
                        for (int i = 0; i < numOfDayWeek; i++)
                        {
                            FullMonth.Add(new());
                        }
                        for (var i = startDate; i < endDate; i = i.AddDays(1))
                        {
                            FullMonth.Add(new() { CurrentDay = i.Day.ToString() });
                        }
                        break;
                    }
                case 5:
                    {
                        for (int i = 0; i < numOfDayWeek; i++)
                        {
                            FullMonth.Add(new());
                        }
                        for (var i = startDate; i < endDate; i = i.AddDays(1))
                        {
                            FullMonth.Add(new() { CurrentDay = i.Day.ToString() });
                        }
                        break;
                    }

                case 6:
                    {
                        for (int i = 0; i < numOfDayWeek; i++)
                        {
                            FullMonth.Add(new());
                        }
                        for (var i = startDate; i < endDate; i = i.AddDays(1))
                        {
                            FullMonth.Add(new() { CurrentDay = i.Day.ToString() });
                        }
                        break;
                    }
                default:
                    break;
            }

        }

    }
}
