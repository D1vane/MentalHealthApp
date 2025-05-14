using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MentalHealthApp.Models;
using System.Collections.ObjectModel;

namespace MentalHealthApp.ViewModels
{
    public partial class PlannerViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<PlannerTaskModel> tasks = new();
        [ObservableProperty]
        private ObservableCollection<PlannerTaskModel> completedTasks = new();

        [ObservableProperty]
        private PlannerTaskModel selectedItem;

        [ObservableProperty]
        private PlannerTaskModel task;
       
        /// <summary>
        /// Добавление новой задачи в список
        /// </summary>
        [RelayCommand]
        private void AddTask()
        {
            if (Tasks.Count > 0)
                foreach (var temptask in Tasks)
                    temptask.IsNew = false;
            Tasks.Add(new PlannerTaskModel { TextTask = "Прогулка с собакой", TimeOfTask = "19:30",IsNew = true });
        }
        /// <summary>
        /// Удаление задачи из списка
        /// </summary>

        [RelayCommand]
        private void RemoveTask()
        {
            Tasks.RemoveAt(0);
        }
        [RelayCommand]
        private void RemoveCompletedTask()
        {
            CompletedTasks.RemoveAt(0);
        }
        /// <summary>
        /// Отметка выполненной задачи
        /// </summary>

        [RelayCommand]
        private void CompletedTask()
        {
            CompletedTasks.Add(Tasks[0]);
            Tasks.RemoveAt(0);
        }
        [RelayCommand]
        private void UnCompletedTask()
        {
            Tasks.Add(CompletedTasks[0]);
            CompletedTasks.RemoveAt(0); 
        }
    }
}
