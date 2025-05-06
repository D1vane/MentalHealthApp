using MentalHealthApp.ViewModels;


namespace MentalHealthApp;

public partial class Planner : ContentPage
{

    public Planner()
    {
        InitializeComponent();
        BindingContext = new PlannerViewModel();
    }

}
