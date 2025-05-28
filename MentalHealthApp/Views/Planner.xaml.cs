using MentalHealthApp.ViewModels;


namespace MentalHealthApp;

public partial class Planner : ContentPage
{
    PlannerViewModel plannerVM;
    public Planner()
    {
        InitializeComponent();
        plannerVM = new PlannerViewModel();
        BindingContext = plannerVM;
    }

    private void Entry_Completed(object sender, EventArgs e)
    {
        plannerVM.UpdateTasksInDB();
        plannerVM.AddTask();
    }
}
