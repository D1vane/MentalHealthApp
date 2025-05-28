using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MentalHealthApp.Models;
using SQLiteNetExtensionsAsync.Extensions;
using System.Collections.ObjectModel;

namespace MentalHealthApp.ViewModels
{
    public partial class PlannerViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<TaskModel> tasks = new();
        [ObservableProperty]
        private ObservableCollection<TaskModel> completedTasks = new();

        [ObservableProperty]
        private TaskModel selectedItem;

        [ObservableProperty]
        private TaskModel task;
        [ObservableProperty]
        int allTasksCount = 0;
        [ObservableProperty]
        string[] calendarDate = (DateTime.UtcNow + TimeZoneInfo.Local.BaseUtcOffset).ToString("dd/MM/yyyy").Split('/');


        public PlannerViewModel()
        {
            GetListOfTasks();
        }

        /// <summary>
        /// Добавление новой задачи в список
        /// </summary>
        [RelayCommand]
        public void AddTask()
        {
            GetNewTask();
            AllTasksCount++;
        }
        /// <summary>
        /// Удаление задачи из списка
        /// </summary>

        [RelayCommand]
        private void RemoveTask(object param)
        {
            RemoveTaskFromDB((int)param);
            Tasks.Remove(Tasks.Where(x => x.TaskID == (int)param).First());
            AllTasksCount = Tasks.Count + CompletedTasks.Count;
        }
        [RelayCommand]
        private void RemoveCompletedTask(object param)
        {
            RemoveTaskFromDB((int)param);
            CompletedTasks.Remove(CompletedTasks.Where(x => x.TaskID == (int)param).First());
            AllTasksCount = Tasks.Count + CompletedTasks.Count;
        }
        /// <summary>
        /// Отметка выполненной задачи
        /// </summary>

        [RelayCommand]
        private void CompletedTask(object param)
        {
            var task = Tasks.Where(x => x.TaskID == (int)param).First();
            task.IsComplete = 1;
            CompletedTasks.Add(task);
            Tasks.Remove(task);
            AllTasksCount = Tasks.Count + CompletedTasks.Count;
            UpdateTasksInDB();
        }
        [RelayCommand]
        private void UnCompletedTask(object param)
        {
            var task = CompletedTasks.Where(x => x.TaskID == (int)param).First();
            task.IsComplete = 0;
            Tasks.Add(task);
            CompletedTasks.Remove(task);
            AllTasksCount = Tasks.Count + CompletedTasks.Count;
            UpdateTasksInDB();
        }

        public async void UpdateTasksInDB()
        {
            foreach (var item in Tasks)
            {
                await App.Database.Connection.UpdateWithChildrenAsync(item);
            }
            foreach (var item in CompletedTasks)
            {
                await App.Database.Connection.UpdateWithChildrenAsync(item);
            }
        }
        async void GetListOfTasks()
        {
            Tasks.Clear();
            CompletedTasks.Clear();
            var dateWithTasks = await App.Database.GetTasksFromACurrentDay(DateTime.UtcNow + TimeZoneInfo.Local.BaseUtcOffset);
            if (dateWithTasks != null && dateWithTasks.Tasks.Count != 0)
            {
                foreach (var task in dateWithTasks.Tasks.Cast<TaskModel>())
                {
                    if (task.IsComplete == 0)
                    {
                        Tasks.Add(task);
                        AllTasksCount++;

                    }

                    else
                    {
                        CompletedTasks.Add(task);

                        AllTasksCount++;

                    }
                }
            }
            else
            {
                GetNewTask();
                AllTasksCount++;
            }
        }
        async void GetNewTask()
        {
            string formatedDate = (DateTime.UtcNow + TimeZoneInfo.Local.BaseUtcOffset).ToString("dd/MM/yyyy");
            var currentDate = await App.Database.Connection.Table<CalendarModel>().Where(x => x.FullDate == formatedDate).FirstOrDefaultAsync();
            if (currentDate == null)
            {
                await App.Database.Connection.InsertAsync(new CalendarModel { FullDate = formatedDate });
                currentDate = await App.Database.Connection.Table<CalendarModel>().Where(x => x.FullDate == formatedDate).FirstOrDefaultAsync();
            }

            await App.Database.Connection.InsertWithChildrenAsync(new TaskModel() { IsComplete = 0, CalendarDay = currentDate, TaskText = "" });
            var newTask = await App.Database.Connection.GetWithChildrenAsync<CalendarModel>(currentDate.DayID);

            Tasks.Add(newTask.Tasks.Last());
        }

        async void RemoveTaskFromDB(int id)
        {
            var taskForDelete = await App.Database.Connection.GetWithChildrenAsync<TaskModel>(id);
            await App.Database.Connection.DeleteAsync(taskForDelete);
        }
    }
}
