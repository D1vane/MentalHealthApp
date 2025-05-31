
using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MentalHealthApp.Models;
using SQLiteNetExtensionsAsync.Extensions;
using System.Collections.ObjectModel;
using System.Xml.Linq;
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
        private ObservableCollection<DayAtCalendarModel> fullMonth = new();

        [ObservableProperty]
        bool isHasTasks = false;
        [ObservableProperty]
        string todayEvents = "";

        [ObservableProperty]
        string startDateToString = new DateTime(ToInt32(DateTime.Today.Year), ToInt32(DateTime.Today.Month), 1).ToString("MM/yyyy");
        [ObservableProperty]
        string[] arrStartDateToString = new DateTime(ToInt32(DateTime.Today.Year), ToInt32(DateTime.Today.Month), 1).ToString("MM/yyyy").Split('/');
        [ObservableProperty]
        DayAtCalendarModel selectedDay;

        public CalendarViewModel()
        {
            FIllTheList();
            
        }


        [RelayCommand]
        private void SwipeToTheLeft()
        {
            StartDate = StartDate.AddMonths(-1);
            EndDate = EndDate.AddMonths(-1);
            ArrStartDateToString = StartDate.ToString("MM/yyyy").Split('/');
            NumOfDayWeek = (int)(StartDate.DayOfWeek + 6) % 7;
            FIllTheList();
        }
        [RelayCommand]
        private void SwipeToTheRight()
        {
            StartDate = StartDate.AddMonths(1);
            EndDate = EndDate.AddMonths(1);
            ArrStartDateToString = StartDate.ToString("MM/yyyy").Split('/');
            NumOfDayWeek = (int)(StartDate.DayOfWeek + 6) % 7;
            FIllTheList();
        }
        [RelayCommand]
        private void GetListOfTasks(object day)
        {

            SelectedDay = FullMonth[numOfDayWeek + (int)day - 1];
            var getFullMonth = FullMonth.Where(x => x.CurrentDay == (int)day).FirstOrDefault();
            if (getFullMonth.ListOfEvents != null)
            {
                
                Cats = getFullMonth.ListOfEvents.ToObservableCollection();
                string dateText;
                if (SelectedDay.CurrentDay < 10)
                    dateText = "0" + SelectedDay.CurrentDay.ToString() + "/" + StartDate.ToString("MM");
                else
                    dateText = SelectedDay.CurrentDay.ToString() + "/" + StartDate.ToString("MM");
                TodayEvents = $"События на {dateText}\t({Cats.Count})";
            }
            else
            {
                TodayEvents = "У вас ничего не запланировано на этот день";
                Cats = new();
            }
                
        }

        [RelayCommand]
        private void FromCalendarToPage(object param)
        {
            var parameter = param as object[];
            
            switch (parameter[0].ToString())
            {
                case "Медитации":
                    Shell.Current.GoToAsync($"MeditationList", new Dictionary<string, object>
                    {
                        ["givenMonthAndYear"] = parameter[1],
                        ["givenDay"] = parameter[2]
                    });
                    break;
                case "Дыхательные техники":
                    Shell.Current.GoToAsync($"BreatheList", new Dictionary<string, object>
                    {
                        ["givenMonthAndYear"] = parameter[1],
                        ["givenDay"] = parameter[2]
                    });
                    break;
                case "Отмеченный сон":
                    Shell.Current.GoToAsync($"Sleep", new Dictionary<string, object>
                    {
                        ["givenMonthAndYear"] = parameter[1],
                        ["givenDay"] = parameter[2]
                    });
                    break;
                case "Отмеченные самочувствия":
                    Shell.Current.GoToAsync($"ExistingFeeling", new Dictionary<string, object>
                    {
                        ["givenMonthAndYear"] = parameter[1],
                        ["givenDay"] = parameter[2]
                    });
                    break;
                case "Список задач":
                    Shell.Current.GoToAsync($"Planner", new Dictionary<string, object>
                    {
                        ["givenMonthAndYear"] = parameter[1],
                        ["givenDay"] = parameter[2]
                    });
                    break;
                case "Для чтения":
                    Shell.Current.GoToAsync($"ForReading", new Dictionary<string, object>
                    {
                        ["givenMonthAndYear"] = parameter[1],
                        ["givenDay"] = parameter[2]
                    });
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Заполнение числами в соответствии с днями недели
        /// </summary>
        public async void FIllTheList()
        {
            Cats.Clear();
            TodayEvents = "";
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
                        FullMonth.Add(new() { IsHasTasks = false, CurrentDay = null });
                        GetDays();
                        break;
                    }
                case 2:
                    {
                        FullMonth.Add(new() { IsHasTasks = false, CurrentDay = null });
                        FullMonth.Add(new() { IsHasTasks = false, CurrentDay = null });
                        GetDays();
                        break;
                    }
                case 3:
                    {
                        for (int i = 0; i < NumOfDayWeek; i++)
                        {
                            FullMonth.Add(new() { IsHasTasks = false, CurrentDay = null });
                        }
                        GetDays();
                        break;
                    }
                case 4:
                    {
                        for (int i = 0; i < NumOfDayWeek; i++)
                        {
                            FullMonth.Add(new() { IsHasTasks = false, CurrentDay = null });
                        }
                        GetDays();
                        break;
                    }
                case 5:
                    {
                        for (int i = 0; i < NumOfDayWeek; i++)
                        {
                            FullMonth.Add(new() { IsHasTasks = false, CurrentDay = null });
                        }
                        GetDays();
                        break;
                    }

                case 6:
                    {
                        for (int i = 0; i < NumOfDayWeek; i++)
                        {
                            FullMonth.Add(new() { IsHasTasks = false, CurrentDay = null });
                        }
                        GetDays();
                        break;
                    }
                default:
                    break;
            }
            
        }

        async void GetDays()
        {
            string checkDate = StartDate.ToString("MM/yyyy");
            var currentMonth = await App.Database.Connection.Table<CalendarModel>().Where(x => x.FullDate.EndsWith(checkDate)).ToListAsync();

            for (var i = StartDate; i < EndDate; i = i.AddDays(1))
            {
                DayAtCalendarModel dayAtCalendar = new DayAtCalendarModel();
                dayAtCalendar.IsHasTasks = false;
                dayAtCalendar.CurrentDay = i.Day;
                if (currentMonth.Count > 0 && currentMonth != null)
                {
                    string checkFullDate = i.ToString("dd/MM/yyyy");
                    var getFullDate = currentMonth.Where(x => x.FullDate == checkFullDate).FirstOrDefault();
                    if (getFullDate != null)
                    {
                        var dayWithChildren = await App.Database.Connection.GetWithChildrenAsync<CalendarModel>(getFullDate?.DayID);
                        if (dayWithChildren.Meditations.Count != 0)
                        {
                            if (dayAtCalendar.ListOfEvents == null)
                                dayAtCalendar.ListOfEvents = new List<FavouriteModel>() { new() { NameOfFav = "Медитации", Description = $"Запланировано практик: {dayWithChildren.Meditations.Count}" } };
                            else
                                dayAtCalendar.ListOfEvents.Add(new FavouriteModel { NameOfFav = "Медитации", Description = $"Запланировано практик: {dayWithChildren.Meditations.Count}" });
                            dayAtCalendar.IsHasTasks = true;
                        }
                        if (dayWithChildren.Breathes.Count != 0)
                        {
                            if (dayAtCalendar.ListOfEvents == null)
                                dayAtCalendar.ListOfEvents = new List<FavouriteModel>() { new() { NameOfFav = "Дыхательные техники", Description = $"Запланировано практик: {dayWithChildren.Breathes.Count}" } };
                            else
                                dayAtCalendar.ListOfEvents.Add(new FavouriteModel { NameOfFav = "Дыхательные техники", Description = $"Запланировано практик: {dayWithChildren.Breathes.Count}" });
                            dayAtCalendar.IsHasTasks = true;
                        }
                        if (dayWithChildren.Sleep != null)
                        {
                            if (dayAtCalendar.ListOfEvents == null)
                                dayAtCalendar.ListOfEvents = new List<FavouriteModel>() { new() { NameOfFav = "Отмеченный сон" } };
                            else
                                dayAtCalendar.ListOfEvents.Add(new FavouriteModel { NameOfFav = "Отмеченный сон" });
                            dayAtCalendar.IsHasTasks = true;
                        }
                        if (dayWithChildren.Feelings.Count != 0)
                        {
                            if (dayAtCalendar.ListOfEvents == null)
                                dayAtCalendar.ListOfEvents = new List<FavouriteModel>() { new() { NameOfFav = "Отмеченные самочувствия", Description = $"Отмечено самочувствий: {dayWithChildren.Feelings.Count}" } };
                            else
                                dayAtCalendar.ListOfEvents.Add(new FavouriteModel { NameOfFav = "Отмеченные самочувствия", Description = $"Отмечено самочувствий: {dayWithChildren.Feelings.Count}" });
                            dayAtCalendar.IsHasTasks = true;
                        }
                        if (dayWithChildren.Tasks.Count != 0)
                        {
                            if (dayAtCalendar.ListOfEvents == null)
                                dayAtCalendar.ListOfEvents = new List<FavouriteModel>() {new ()
                                {
                                    NameOfFav = "Список задач",
                                    Description = $"Выполнено задач {dayWithChildren.Tasks.Where(x => x.IsComplete == 1).Count()} / {dayWithChildren.Tasks.Count}"
                                } };
                            else
                                dayAtCalendar.ListOfEvents.Add(new FavouriteModel
                                {
                                    NameOfFav = "Список задач",
                                    Description = $"Выполнено задач {dayWithChildren.Tasks.Where(x => x.IsComplete == 1).Count()} / {dayWithChildren.Tasks.Count}"
                                });
                            dayAtCalendar.IsHasTasks = true;
                        }
                        if (dayWithChildren.Readings.Count != 0)
                        {
                            if (dayAtCalendar.ListOfEvents == null)
                                dayAtCalendar.ListOfEvents = new List<FavouriteModel>() { new() { NameOfFav = "Для чтения", 
                                    Description = $"Запланировано прочитать статей: {dayWithChildren.Readings.Count}" } };
                            else
                                dayAtCalendar.ListOfEvents.Add(new FavouriteModel { NameOfFav = "Для чтения", 
                                    Description = $"Запланировано прочитать статей: {dayWithChildren.Readings.Count}" }); ;
                            dayAtCalendar.IsHasTasks = true;
                        }

                    }
                }

                FullMonth.Add(dayAtCalendar);
            }
            if (StartDate.Month == DateTime.Today.Month)
            {
                SelectedDay = FullMonth[numOfDayWeek + DateTime.Today.Day - 1];
                GetListOfTasks(ToInt32(DateTime.Today.Day));
            }
                
            else
                SelectedDay = null;
            
        }


    }
}
