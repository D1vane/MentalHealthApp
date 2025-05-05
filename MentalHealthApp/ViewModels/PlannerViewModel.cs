using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MentalHealthApp.Models;
using System.Collections.ObjectModel;

namespace MentalHealthApp.ViewModels
{
    public partial class PlannerViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<PlannerTask> tasks = new();

        [ObservableProperty]
        private PlannerTask selectedItem;

        [ObservableProperty]
        private PlannerTask task;

        [RelayCommand]
        private void AddTask()
        {
            Tasks.Add(new PlannerTask
            {
                TextTask = "Погулять с собакой",
                TimeOfTask = "19:30"
            });
            
        }
        [RelayCommand]
        private void RemoveTask()
        {

            if (Tasks.Contains(SelectedItem))
                Tasks.Remove(SelectedItem);
        }
    }
}
